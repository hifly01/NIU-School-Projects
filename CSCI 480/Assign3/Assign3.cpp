/*
Charles Alms
Assign3/Microshell program
due 2/20/20

Creates a basic mircoshell in C++ that uses Linux system calls.
There are various types of commands such as "about" which will
say who is it by and when.
*/

#include <iostream>
#include <iomanip>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <stdio.h>
#include <cstring>
#include <sys/stat.h>
#include <fcntl.h>

using namespace std;

/*
main: main part of the program
Takes nothing and returns nothing

Takes user input and executes the cammand from the input line
with execvp. Checks for special made characters that are not
reconized by execvp and uses dup() and open()
*/
int main()
{
	int arg = 10;		//size of 1 possible commands
	char input[1024];	//input for command line
	bool read = false;	//bools for the <+ and >+
	bool write = false;

	cout<<"480shell: ";	//initail output

	while (fgets(input,1024,stdin) != NULL)		//while the input line is not null
	{
		input[strlen(input) -1] = '\0';		//set the last index to null
		char* argv[arg];			//create a new array
		argv[0] = strtok(input, " ");		//store the command line into the argv array

		for(int i = 1; i < arg; i++)		//for loop for inserting values into argv
		{
			argv[i] = strtok(NULL, " ");	//clear the array at position i
			if(argv[i] == NULL)		//if it is null, set the index to NULL
			{
				argv[i] = NULL;
				break;			//break
			}
			else if(strcmp(argv[i], "<+") == 0)		//searches for <+
			{
				read = true;			//if it was found, set reading to true
			}
			else if(strcmp(argv[i], ">+") == 0)		//searches for >+
                	{
                	        write = true;		//if found, set write to true
                	}
		}


		if(strcmp(argv[0], "q") == 0 || strcmp(argv[0], "quit") == 0)	//if user wants to quit
		{
			exit(0);
		}



		else if(read == true)		//if read is true (has a <+)
		{
			char* firsthalf[arg];           //an array to hold the first command lines before >+
		        char* lasthalf[arg];            //end of the line after <+
			bool stopper = false;		//bool val to stop when the <+ is found
			int argindex = 0;       //second index to keep count of arguements after <+
			int i = 0;              //first index to keep count of arguements

			while(i < arg && argindex < arg)
			{
				firsthalf[i+1] = strtok(NULL, " ");	//make the next value NULL IMPORANT
				lasthalf[i+1] = strtok(NULL, " ");	//make the next value NULL IMPORNAT
				if(argv[argindex] == NULL)		//if the command line is over, break
				{
					break;
				}
               	        	else if(stopper == true)       //If its the second half of the line
                        	{
                               		lasthalf[i] = argv[argindex];		//set the second half = to the second half from the command line
                        	}
				else if(strcmp(argv[argindex], "<+") == 0)       //if <+
                        	{
					i = -1;			//make i = -1 because i++ is at the end
					stopper = true;		//mark the end of the first half
                        	}
				else if(stopper == false)	//If its the first half of the command
				{
					firsthalf[i] = argv[argindex];	//set the first half = first half of orginal command line
				}
				argindex++;		//increase the values by 1
				i++;
			}

        		pid_t pid1;	//pid
	        	int status;	//status for the fork
	        	if ((pid1 = fork()) < 0)	//if not child or parent
        		{
                		cout<<"ERROR: forking child process failed\n";
	               		exit(1);
        		}
			else if (pid1 == 0)	//if in the child, run the rest
	        	{
				if(lasthalf[1] != NULL)		//if there are too many arguments
				{
					cout<<"Too many arguments"<<endl;
					break;
				}

				int fileOpen = open(lasthalf[0], O_RDONLY);	//open the file from the lasthalf array

				if(fileOpen != -1)	//if end of file, close and duplicate it
				{
					close(0);
					dup(fileOpen);
				}

				if(execvp(*firsthalf, firsthalf)<0)	//if the execvp fails
				{
					cout<<"Error."<<endl;
					exit(1);
				}
	        	}
			else    //if in parent
		        {
		                while (wait(&status) != pid1);	//wait for child to finish
	        	}
			read = false;		//reset the read bool so it doesnt keep going back here

			for(int j =0; j<arg; j++)
			{
				firsthalf[j] = NULL;
				lasthalf[j] = NULL;
			}
		}



//----------------------------------------------------------------------------



		else if(write == true)		//if write is true (has >+)
                {

			char* firsthalf2[arg];           //an array to hold the first command lines before >+
	                char* lasthalf2[arg];            //end of the line
	       	        bool stopper2 = false;
       	        	int argindex2 = 0;       //second index to keep count of arguements after <+
                	int i2 = 0;              //first index to keep count of arguements

                	while(i2 < arg && argindex2 < arg)
                	{
                	        firsthalf2[i2+1] = strtok(NULL, " ");
				lasthalf2[+1] = strtok(NULL, " ");
                       		if(argv[argindex2] == NULL)
                        	{
                               		break;
                        	}
                        	else if(stopper2 == true)       //If its the second half
                        	{
                        	        lasthalf2[i2] = argv[argindex2];
                        	}
                        	else if(strcmp(argv[argindex2], ">+") == 0)       //if >+
                        	{
                                	i2 = -1;
                                	stopper2 = true;
                        	}

				else if(stopper2 == false)       //If its the first half
	                        {
        	                        firsthalf2[i2] = argv[argindex2];
        	                }
               	        	argindex2++;
               		        i2++;
                	}

                	pid_t pid2;
                	int status2;
			if ((pid2 = fork()) < 0)	//if not child or parent
	                {
        	                cout<<"ERROR: forking child process failed\n";
       				exit(1);
                	}
                	else if (pid2 == 0)	//if child
                	{
                        	if(lasthalf2[1] != NULL)
                        	{
                                	cout<<"Too many arguments"<<endl;
                                	break;
                        	}

				int fileOpen2 = open(lasthalf2[0], O_WRONLY | O_TRUNC | O_CREAT, S_IRUSR | S_IRGRP | S_IWGRP | S_IWUSR);

        	                        dup2(fileOpen2, 1);
					close(fileOpen2);

                        	if(execvp(*firsthalf2, firsthalf2)<0)		//if the command has an error
                        	{
                               		cout<<"Error."<<endl;
                                	exit(1);
                        	}
			 }
                else    //if in the child
                {
                        while (wait(&status2) != pid2);		//wait for child to finish
                }
			write = false;
                }




	else if(strcmp(argv[0], "about") == 0)		//if user wants to know about the program
	{
		cout<<"This shell program is the work of Charles, 2020" << endl;
	}

	else		//if not quit, about, or have any special symbols, execute the line
	{
		pid_t  pid;		//declaring pid and status
		int    status;
		if ((pid = fork()) < 0)		//if fork fails
		{
	          	cout<<"ERROR: forking child process failed\n";
	          	exit(1);
		}
	     	else if (pid == 0)		//if in child
		{
        	  	if (execvp(*argv, argv) < 0)		//if execvp fails
			{
				cout<<"ERROR: exec failed\n";
				exit(1);
  			}
		}
     		else		//if parent
		{
          		while (wait(&status) != pid);		//wait for child to finish
		}
	}

	cout<<"480shell: ";

	}


}		//end of program

