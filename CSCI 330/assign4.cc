/***************************************************************************
 Charles Alms
 Assignment 4
 Due 10/2/20

 Purpose: take assignment 3 and add more arguments that can limit the size
 of the file being printed, shift the letters, and more.
***************************************************************************/
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <cstdlib>
#include <cstring>
#include "assign4.h"

using namespace std;

/*
Main function: Takes the input files from
the user and will print them out to the users screen
-s changes buffer size
-n changes the byte size
-c is how far we use caesar cipher
-r is rotate the bytes
-b is convert the values to binary
-x will convert the values to hex
*/
int main(int argc, char *argv[])
{
	int opt, fd, bsize, fsize, shift, rotate;
	bool s = false, n = false, r =false, c = false, x = false, b = false;				//bool values to see if -r,-c,-x,-h were already used
	ssize_t reading;							//variables for read and write

	fsize = -1;
	if(argc>1)								//if there is more than 1 arguments
	{
		while((opt = getopt(argc, argv, "s:n:c:r:xb")) !=-1)		//get the code for entering either -s,-n,-c-,r,-x,-b
		{
			switch(opt)						//switch case for the -s,-n,-c-,r,-x,-b
			{
				case 's':
				s = true;
				bsize=atoi(optarg);				//set the buffer size to the argument for -s (atoi converts it to an int)
				break;

				case 'n':
				n = true;
				fsize=atoi(optarg);				//set the max size of the file to the argument for -n (atoi converts it to an int)
       	                	break;

				case 'c':
				c = true;					//bool used to restrict user from entering invalid command combinations
				shift=atoi(optarg);				//make the shift amount the argument for -c (atoi converts it to an int)
                        	break;

	                        case 'r':
	                        r = true;					//bool used to restrict user from entering invalid command combinations
				rotate=atoi(optarg);				//make the rotate amount the argument for -c (atoi converts it to an int)
	                        break;

	                        case 'x':
       		                x = true;					//bool used to restrict user from entering invalid command combinations
              			break;

                       		case 'b':
                        	b = true;					//bool used to restrict user from entering invalid command combinations
                        	break;

				default:
				cerr<<"An error has occured with the switch case"<<endl;
			}
		}

		if(r==true && c==true)					//if statements to check is any command was illegal
		{
        	        cerr<<"ERROR! You can not do both -r and -c"<<endl;
			exit(1);					//exit if so with wa return code of 1

		}
		if(x==true && b==true)
        	{
               		cerr<<"ERROR! You can not do both -x and -b"<<endl;
			exit(2);					//exit if so with a return code of 2
        	}

/*
 if statements below are for if -n and or -s was not stated
*/
			if(s==false)                                             //if -s was not done
                        {
                                struct stat buf;        		//create the stat
                                int rc = stat(argv[optind], &buf);
                                if(rc==-1)              		//if the stat fails
                                {
                                        perror("stat");
                                        return 4;
                                }
                                bsize = buf.st_size;
                         }
                         if(n==false)
                         {
                                fsize = bsize;
                         }

		for(int i=optind; i<argc; i++)				//for loop to read through the command line
		{
			char file[bsize];				//read the file of the value -s
			char hfile[bsize*2];				//file for hex values. multiply by 2 to make room for 2 hex numbers per letter
			char bfile[bsize*8];				//file for binary values. multiply by 8 to make froom for 8 binary numbers per letter

	        	fd = open(argv[i], O_RDONLY);		        //open the file

                	if(fd==-1)                                      //in case there was an error in the opening
                	{
                	        perror("opening");
                       		cerr<<endl;
                	}
			else
			{
				while((reading = read(fd, file, bsize) !=0))		//while the file is not empty within the restricted size
				{
                        		if(reading ==-1)                                //in case there was an error in the reading
	                		{
        	        		        perror("reading");
                	       		 	cout<<endl;;
                			}
					else
					{
						reading = fsize;
					}

					if(c==true)					//caesar cipher
					{
						func(shift, file, reading);		//call the function with the file, the shift amount and size
					}
					if(r==true)					//rotate
					{
						funr(rotate, file, reading);
					}
					if(x==true)					//hex
					{
						for(int i=0; i<bsize; i++)		//copy the buffer to the new sized buffer
                                                {
                                                        hfile[i] = file[i];
                                                }
                                                for(int j = bsize+1; j<bsize*2; j++)	//replace the remaining space with blanks
                                                {
                                                        hfile[j]= ' ';
                                                }

						funx(hfile, reading);
					}
					if(b==true)					//binary
					{
						for(int i=0; i<bsize; i++)		//copy the buffer to the new sized buffer
						{
							bfile[i] = file[i];
						}
						for(int j = bsize+1; j<bsize*8; j++)	//replace the remaining space with blanks
						{
							bfile[j]= ' ';
						}
						funb(bfile, reading);
					}

/*
					if(b==true)
					{
						bfile[reading] = 0;			//clear any unused space
						write(1, bfile, reading*8);		//if binary was picked, multiply the file size by 8 to hold all binary vals
						cerr<<endl;
					}
					else if(x==true)
					{
						file[reading] = 0;			//clear any unused space
						write(1, file, reading*2);		//if hex was picked, multiply the file size by 2 to hold all hex vals
						//write(1, file, reading);
						cerr<<endl;
					}*/
					if(x != true && b != true)
					{
						file[reading] = 0;			//clear any unused space
						write(1, file, reading);		//print out the file if hex and binary were not used
						cerr<<endl;
					}
				}
			}
		}

	}
	else										//if the user did not input anything
	{
		cerr<<"There were no files to be read. Exiting"<<endl;
		return 1;
	}
	close(fd);									//close the file
	return 0;
}
