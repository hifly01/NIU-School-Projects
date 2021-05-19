/*
 Chalres Alms
 z1797837
 Assignment 8
 Due 11/20/20

 Purpose: this assignment will create a simple
 HTTP server in C++ that will allow the user to
 enter "GET" followed by a path to a file or
 directory and will display the contents of it
 to the client.

 GET /330/Assign8
*/

#include <unistd.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <iostream>
#include <arpa/inet.h>
#include <cstring>
#include <dirent.h>
#include <cstdlib>
#include <sys/stat.h>
#include <fcntl.h>
#include <string.h>

using namespace std;

/*
 chomp: returns nothing and takes in 1 char pointer

 purpose: removes trailing newline (\n and \r)
*/
void chomp(char *s)
{
	for(char *p = s + strlen(s)-1;
	  *p =='\r' || *p == '\n';
	  p--)
	*p = '\0';
}

/*
 main function that handles the server calls and
 calls other functions. Takes in 2 parameters as
 a command line
*/
int main(int argc, char *argv[])
{
	char buff[257];						//buffer for the directory
	int sock, newSock;
	struct sockaddr_in echoserver;				//address for server
	struct sockaddr_in echoclient;				//address for client
	socklen_t serverlen, clientlen;              		//create serverlen
	ssize_t received;					//will be the message that the client sends over
	ssize_t readIndex;					//will be for reading index.html
	ssize_t readFile;					//will be used for reading files
	char *commandln[2];					//used for spitting the command line

	if(argc != 3)						//if there is not a port number, GET, and directory
	{
		cout<<"ERROR: Please enter \"GET\" and a directory starting with a /"<<endl;
		exit(1);					//exit
	}

	DIR *dirp;						//used for directories
	struct dirent *dirEntry;				//used to read the directories

	//create tcp socket
	if((sock = socket(AF_INET, SOCK_STREAM, 0)) <0)		//if the socket fails
	{
		perror("Failed to create socket");
		exit(EXIT_FAILURE);
	}
	else
	{
		cerr<<"Socket created"<<endl;
	}

	memset(&echoserver, 0, sizeof(echoserver));		//clear struct
	echoserver.sin_family = AF_INET;			//internet ip
	echoserver.sin_addr.s_addr = INADDR_ANY;		//ip address
	echoserver.sin_port = htons(atoi(argv[1]));		//server port at the second argumnet

	serverlen = sizeof(echoserver);				//make the serverlen the size of the echo server

	//do the binding to the server
	if(bind(sock, (struct sockaddr *) &echoserver, serverlen) <0)
	{
		perror("Failed to bind server socket");
		exit(EXIT_FAILURE);
	}
	else
	{
		cerr<<"Binding complete"<<endl;
	}

	//listen for a certain amount of time
	if(listen(sock, 64) <0)
	{
		perror("Listening failure");
		exit(EXIT_FAILURE);
	}
	else
	{
		cerr<<"Listening..."<<endl;
	}

	clientlen = sizeof(echoclient);					//prevents errors
	//runs until the client is no longer connected
	while((newSock = accept(sock, (struct sockaddr *) &echoclient, &clientlen)) != -1)
	{
		if(fork())						//fork if in the parent
		{
			close(newSock);					//close newSock to continue looping
		}
		else
		{
			//check to see if we can read the buffer
                        if((received = read(newSock, buff, 256)) ==-1)		//received has the command line from the client that is to be passed in
                        {
                                perror("Read failed");
                                exit(2);

                        }
			else
			{
				cerr<<"Attempting to open "<<buff<<endl;
			}


			//make sure that the user typed "GET"
			commandln[0] = strtok(buff, " ");		//get the comamnd line from the buffer. commandln[0] will be whatever until a space
			if(strcmp(commandln[0], "GET") == 0)		//if they typed GET, continue
			{
				char message[] = "I have found your GET\n";	//write feedback to client
                                write(newSock, message, strlen(message));

				commandln[1] = strtok(NULL, "\n");	//commandln[1] will be the second half of the command line

				//check if the first char is a /
				if(commandln[1][0] != '/')
				{
					char message[] = "Must start off with /\n";
	                                write(newSock, message, strlen(message));
					exit(3);
				}
				else
				{
					char message[] = "I have found your /\n";     //write feedback to client
	                                write(newSock, message, strlen(message));
				}

				//check will use strstr to compare if the second half of the command line used .. ever
				char *check = strstr(commandln[1], "..");
				if(check != NULL)
				{
					char message[] = "you can not have .. anywhere in the command line\n";
	                                write(newSock, message, strlen(message));
                                        exit(3);
				}
				else
				{
					char message[] = "I have not found .. so you are good to go\n";     //write feedback to client
	                                write(newSock, message, strlen(message));
				}
				char *path = argv[2];                   //set the path to the second parameter from the input
				chomp(commandln[1]);			//call the chomp funciton

				strcat(path, commandln[1]);		//NEED THIS TO MAKE SURE THE PATH IS FORMATED CORRECTLY
				char *check2 = strstr(commandln[1], "index.html");	//used to see if "index.html" was used

//for reading any file
//--------------------------------------------------------------------------------------------------------------------------------
				struct stat fileBuff;				//used to see if the path leads to a file
				stat(path, &fileBuff);
				if(((fileBuff.st_mode & S_IFMT) == S_IFREG) ==true)		//used to test if the path leads to a file
				{
					char message[] = "I have found a file\n";
                                        write(newSock, message, strlen(message));

                                        int openFile;                                          //open the file first
       	                                if(openFile = open(path, O_RDONLY) <0)            //read only and if it does not work, send a message
               	                        {
                       	                        char message[] = "Could not open the file\n";
                               	                write(newSock, message, strlen(message));
                           		        exit(5);
                             		}
                                	else
                                	{
                                        	char message[] = "Opening file\n";
                                                write(newSock, message, strlen(message));

						cout<<path<<endl;
                                                char *cat[] = {"cat", path, 0};          //for printing the file

						/*
                                       		  dup2 will replace the cout and will instead send the listings to the client
                                          	  instead of out through standard output for the server
                                        	*/
                                        	if(dup2(newSock, 1) < 0)
                                        	{
                                        	        cerr<<"Dup2 failed";
                                        	        exit(4);
                                        	}
						//I know this isnt right but I dont understand why my read wasnt working. it wouldnt run
						execvp(cat[0], cat);

					/*	readFile = read(openFile, file, 256);		//read the file
						if(readFile == -1)                              //in case there was an error in the reading
                                                {
                                                        char message[] = "failed to read\n";
                                                        write(newSock, message, strlen(message));
                                                        exit(5);
                                                }
						else
						{
							char message[] = "Reading\n";
                                                        write(newSock, message, strlen(message));
						}

						file[readFile] = 0;				//clear out the ending
						cout.flush();					//in case of timing issues
						write(newSock, file, 256);			//write to the client*/
					}
					close(newSock);
				}


				//used to see if the user had typed "index.html" anywhere in their command line
				//runs the same was as .. did
//--------------------------------------------------------------------------------------------------------------
				else if(check2 != NULL)
				{
					char message[] = "I have found index.html\n";
                                        write(newSock, message, strlen(message));

					int openIndex;						//open the file first
					if(openIndex = open(path, O_RDONLY) <0)		//read only and if it does not work, send a message
					{
						char message[] = "Could not open index.html\n";
	                                        write(newSock, message, strlen(message));
						exit(5);
					}
					else
					{
						char message[] = "Opening index.html\n";
                                                write(newSock, message, strlen(message));

						cout<<path<<endl;
                                                char *cat[] = {"cat", path, 0};          //for printing the file

                                                /*
                                                  dup2 will replace the cout and will instead send the listings to the client
                                                  instead of out through standard output for the server
                                                */
                                                if(dup2(newSock, 1) < 0)
                                                {
                                                        cerr<<"Dup2 failed";
                                                        exit(4);
                                                }
                                                //I know this isnt right but I dont understand why my read wasnt working. it wouldnt run
                                                execvp(cat[0], cat);

/*
						char ftbr[256];					//create a new file to be read buffer

						while(readIndex = read(openIndex, ftbr, 256) != 0)	//while read succeeds
						{
							if(readIndex == -1)                                //in case there was an error in the reading
	                	                        {
								char message[] = "failed to read\n";
	                                	                write(newSock, message, strlen(message));
								exit(5);
                        	                	}
	                                	        else
		                                       	{
								char message[] = "Reading\n\n";
                	                                        write(newSock, message, strlen(message));

								readIndex = read(openIndex, ftbr, 256);
								write(newSock, ftbr, sizeof(readIndex));		//write the file to the client
							}
						}*/
					}
				}
//for reading directories
//---------------------------------------------------------------------------------------------------------------------------
				else
				{
					char message[] = "I did not find index.html. Continuing\n\n";
                                        write(newSock, message, strlen(message));

					//open the directory first
					dirp = opendir(path);			//opens the directory at the path
					if(dirp == 0)				//if it can not be opened
					{
						perror("can not find file/directory");
						char message[] = "Can not find file/direcory\n";     //write feedback to client
       		                                write(newSock, message, strlen(message));
						exit(EXIT_FAILURE);
					}

					/*
					  dup2 will replace the cout and will instead send the listings to the client
					  instead of out through standard output for the server
					*/
					if(dup2(newSock, 1) < 0)
					{
						cerr<<"Dup2 failed";
						exit(4);
					}

					//reading the dir
					while((dirEntry = readdir(dirp)) != NULL)		//loop through until no more directories are left
					{
						if(dirEntry->d_name[0] != '.')			//only show the ones without starting with .
						{
							cout<< dirEntry->d_name<<endl;		//send out all dirs to the client with dup2
						}
					}
				}
			}
			//if the input did not start with GET
			else
			{
				char message[] = "Must use GET\n";
				write(newSock, message, strlen(message));
				cerr<<"You must start with \"GET\""<<endl;
				exit(2);
			}
			closedir(dirp);							//close everything
			close(newSock);
			exit(0);
		}
		memset(buff, 0, sizeof(buff));						//clear the buffer to prevent possible errors

	}
	close(newSock);									//close newSock again just incase

	return 0;
}
