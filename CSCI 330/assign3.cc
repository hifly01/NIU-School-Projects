/**************************************************
Charles Alms
Assignment 3
Fall 2020
Due 9/18/20

Purpose: This assigment will create a program to
mimic the 'cat' command in linux by reading and
displaying any number of files of any size to the
users screen based on what the user inputs
**************************************************/
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <cstring>
using namespace std;

/*
Main function:

Takes the input files from the user and will print them out to the users screen
*/
int main(int argc, char *argv[])
{
	int fd;
	if(argc > 1)				//if th euser typed 1 or more files to be read
	{
		for(int n=1; n<argc; n++)	//loop to run through n times where n= number of files input
                {
			struct stat buf;	//create the stat
	        	int rc = stat(argv[n], &buf);
	        	if(rc==-1)		//if the stat fails
	        	{
	        	        perror("stat");
	        	        return 4;
	        	}

	        	char ftbr[buf.st_size];		//make the file to be read the size of buf from the stat
			if(argv[n] != "-")
			{
				fd = open(argv[n], O_RDONLY);			//open the file
			}
			if(fd==-1)					//in case there was an error in the opening
			{
				perror("opening");
				cout<<endl;
			}

			ssize_t reading, writing;			//ssize_t variables for read and write
			reading = read(fd, ftbr, buf.st_size);		//read the file with a size of whatever the buf stat size is
			if(reading ==-1)				//in case there was an error in the reading
			{
				perror("reading");
				cout<<endl;;
			}
			ftbr[reading] = 0;				//remove any extra space
			cout<<"\nfile number "<<n<<":"<<endl;		//print out the number of the file in the order
			cout.flush();					//helps keep the file clean in case of timing issues
			writing= write(1, ftbr, buf.st_size);		//writes out the file will all characters
		}
	}

	else					//if the user did not type at least 1 file
	{
		cout<<"There were no files to be read"<<endl;
		return 1;			//end th eprogram with a return code of 1
	}

	close(fd);		//close the file
	return 0;
}
