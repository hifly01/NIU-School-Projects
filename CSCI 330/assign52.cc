/****************************************************************
 Charles Alms
 Assignmet 5
 Due 10/23/20

 purpose: create a program that functions like a shell with using
 fork and pipe commands

 This assignment is very similar to a CSCI 480 assignment I had
 last semester with Hutchins. Difference is this takes 2 command
 lines and does not have special commands that changes a file
****************************************************************/
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
 main(): takes in nothing and returns an int. The purpose is to take
 2 commands from the user and pipe the first command into the second
 much like command1 | command2 on the shell
*/
int main()
{
        char command1[255], command2[255];					//chars of the users input up to 256 characters long
        int arg = 10;								//each argument is less than 10 characters
        int pipefd[2];								//for the pipe
        pid_t pid1, pid2;                                                       //pid
        int status;                                                             //status for the fork
        int exStatus, exStatus2;                                                //status for the exec command
	int i = 0;                                              		//use i as an index to loop through the command lines

        cout<<"Welcome to the shell program. To quit, type \"quit\"\n"<<endl;
        cout<<"command1: ";
        cin.getline(command1, 255);                                             //input command1 from user

        while(strcmp(command1, "quit") !=0)                                     //while loop to check if quit was entered
        {
                if(strcmp(command1, "quit") ==  0)                              //if command1 is quit, exit
                {
                        exit(0);
                }

                cout<<"command2: ";
                cin.getline(command2, 255);                                     //input for command2 from user

                if(strcmp(command2, "quit") ==  0)                              //if command2 is quit, exit
                {
			cout<<"quiting"<<endl;
                        exit(0);
                }

		char* argv[arg];                                        //create a new array for command 1
		char* argv2[arg];                                       //create a new array for command 2

		argv[i++] = strtok(command1, " ");			//use strtok on the next command

		while((argv[i] = strtok(NULL, " ")) != 0)		//loop through the command and preform strtok till it reaches the end
		{
			i++;						//increase to the nest position until it is null
		}

		i = 0;

		argv2[i++] = strtok(command2, " ");			//use strtok on the second command line

                while((argv2[i] = strtok(NULL, " ")) != 0)		//perform the same function as above but for the second command
                {
                        i++;
                }

/*
	this is what was causing errors
		command1[strlen(command1) -1] = '\0';                   //set the last index to null
                char* argv[arg];                                        //create a new array
                argv[0] = strtok(command1, " ");                        //store the command line into the argv array

                command2[strlen(command2) -1] = '\0';                   //set the last index to null
                char* argv2[arg];                                       //create a new array
                argv2[0] = strtok(command2, " ");                       //store the command line into the argv array

                for(int i = 1; i <arg; i++)                             //find the first command for command1
                {
			argv[i] = strtok(NULL, " ");			//clear the array at position 1
			if(argv[i] == NULL)				// if theres a null, set the index to NULL
			{
				argv[i] = NULL;
				break;
			}
                }

                for(int j = 1; j <arg; j++)                            //find the first command for command2
                {
			argv2[j] = strtok(NULL, " ");
                        if(argv2[j] == NULL)
                        {
				argv2[j] = NULL;
                                break;
                        }
                }
*/
//---------------------------------------------------------------------------------------
                if (pipe(pipefd) == -1)                           		//if the pipe fails
                {
                        cout<<"ERROR: piping process failed\n";
                        exit(1);
                }
//----------------------------------------------------------------------------------------

		if((pid1=fork()) <0)						//if the first fork fails
                {
                        cout<<"ERROR: forking child process 1 failed\n";
                        exit(1);

                }
                else if (pid1 == 0)                                     	//if in the child, run the rest
                {
                        close(pipefd[0]);					//close the read and write ends
                        dup2(pipefd[1], 1);					//call dup2 on the pipe
                        close(pipefd[1]);

                        if(exStatus = execvp(*argv, argv) < 0)                	//if the exec fails
                        {
                                cout<<"ERROR: can not run command1\n";
                                exit(1);
                        }
		}
                waitpid(-1, &status, 0);					//wait till the process finsihes

//---------------------------------------------------------------------------------------------------------

                if ((pid2 = fork()) < 0)        				//if not child or parent
                {
                        cout<<"ERROR: forking child process 2 failed\n";
                        exit(1);
                }
                else if (pid2 == 0)     					//if child
                {
                        close(pipefd[1]);					//close the read and write ends
                        dup2(pipefd[0], 0);					//preform dup2 on the pipe
                        close(pipefd[0]);

                        if(exStatus2 = execvp(*argv2, argv2) < 0)                //if the exec fails
                        {
                                cout<<"ERROR: can not run command2\n";
                                exit(1);
                        }
                }

                close(pipefd[0]);						//close the read and write ends of the pipe
                close(pipefd[1]);

		waitpid(-1, &status, 0);					//wait until the process finishes

	        cout<<"\ncommand1: ";						//required to continue looping till "quit" is typed
       	 	cin.getline(command1, 255);
	}
        return 0;
}

