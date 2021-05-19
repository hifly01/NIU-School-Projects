#include <unistd.h>
#include <string>
#include <sys/wait.h>
#include <iostream>

using namespace std;

int pipeA[2];
int pipeB[2];           //declared 3 int arrays of size 2
int pipeC[2];

void PWork(int, int);
void CWork(int, int);		//prototypes for functions
void GWork(int, int);

/*
main function:

calls the other functions, uses if statements for errors, and uses print lines

returns: 0
*/

int main()
{

	if(pipe(pipeA) == -1)			//if the first pipe fails, exit -5
	{
		cerr<<"the first pipe, pipeA, has failed"<<endl;
		exit (-5);
	}

 	if(pipe(pipeB) == -1)                   //if the second pipe fails, exit -5
        {
                cerr<<"the second pipe, pipeB, has failed"<<endl;
                exit (-5);
        }

	if(pipe(pipeC) == -1)                   //if the third pipe fails, exit -5
        {
                cerr<<"the third pipe, pipeC, has failed"<<endl;
                exit (-5);
        }


	pid_t pid = fork();			//call the first fork

	if(pid == -1)                           //if the pid is not a parent, BuffCharGild, or grand BuffCharGild, error message
        {
                cerr<<"The first fork has failed. Exiting with a -5"<<endl;
                exit(-5);                       //exit with a return code of -5
        }

	else if(pid == 0)                       //if a BuffCharGild if pid = 0
        {
                pid_t pid2 = fork();            //second fork variable

                if(pid2 == -1)                  //if fork 2 fails, exit
                {
                        cerr<<"The second fork has failed. Exiting with a -5"<<endl;
                        exit(-5);               //exit with a retrun code of -5
                }

		else if(pid2 == 0)		//if it is the BuffCharGild (grand BuffCharGild in this case), reads from C and writes to B
		{
                        cout<<"I am the grandchild and am ready to proceed"<<endl;

			close(pipeC[1]);		//close the unused ends for both 
                        close(pipeB[0]);		//the read and write

                        GWork(pipeC[0],pipeB[1]);	//pass in the read, then write into grandBuffCharGild

                        close(pipeC[0]);                //close the read and write pipes
                        close(pipeB[1]);

			exit(0);			//exit
		}

		else		//if it is the BuffCharGild, reads from B and writes to A
		{
			cout<<"I am the child and am ready to proceed"<<endl;

			close(pipeB[1]);	//close the unsed ends for both
			close(pipeA[0]);

			CWork(pipeB[0],pipeA[1]);	//pass in read and write to the BuffCharGild

			close(pipeB[0]);	//close the read and write pipes
			close(pipeA[1]);
			exit(0);		//exit
			wait(0);		//would crash if the wait was before exit
		}
	}

	else		//the parent reads from A and writes to C
	{
		cout<<"I am the parent and am ready to proceed"<<endl;

		close(pipeA[1]); 		//close the unused ends of the pipes
		close(pipeC[0]); 

		PWork(pipeA[0],pipeC[1]);	//pass in the read and write pipes

		close(pipeA[0]);		//close the other ends of the pipes
		close(pipeC[1]);

		exit(0);			//exit
		wait(0);			//program crashed if wait was before exit
	}
	return 0;
}

/*
PWork(): two ints for the pipes

gets called by the main and handles the string values and buffer, calculates M,
and converts M into a string. Starts the read and writing functions

returns: nothing
*/

void PWork(int readp, int writep)
{
	string Buffer = "1@";		//declared a string buffer and value
	string Value ="1";
	char buffCharP;			//used a char to grab 1 bit at a time
	long int M = 1;			//used for the math

	cerr << "Parent        Value: " << M <<endl;
	write(writep, Buffer.c_str(), Buffer.length());			//get the program started with a write command
	Buffer.clear();			//cleared the buffer and value after the first write
	Value.clear();			//to get rid of anything that was just added

	while(true)
	{
		while(read(readp, &buffCharP, 1) > 0)		//first read statement
		{
			if(buffCharP == '@')			//check if the bit is = to the end of line character
			{
				break;				//if so break
			}
			Value.push_back(buffCharP);		//move the char bit
		}

		try						//needed a try catch or the stoi would crash
		{
			M = stoi(Value);			//convert value into a string
		}
		catch(...)					//unconditional catch
		{
			break;					//break
		}

		if (M > 999999999 || M <-999999999)		//if M is betweeen the values
		{
			write(writep, "*@", 2);			//write into the writing pipe
			break;					//break out
		}

		else{
			M = (200 - 3 * M);			//equation

			Buffer = to_string(M);			//convert M to a string and store in Buffer
			cerr << "Parent        Value: " << M <<endl;		//print line
			write(writep, Buffer.c_str(), Buffer.length());		//call the write function again
			write(writep, "@", 1);
		}

		Buffer.clear();
		Value.clear();			//clear value and buffer so the math is not changed
	}
}

/*
CWork(): two ints for the pipes

gets called by the main and handles the string values and buffer, calculates M,
and converts M into a string

returns: nothing
*/

void CWork(int readc, int writec)
{
	string Buffer;
	string Value;
	char buffCharC;			//new char for the child function
	long int M;

	while(true)
	{
		while(read(readc, &buffCharC, 1) > 0)		//check if the bit is = to the end of line characte
		{
			if(buffCharC == '@')
			{
				break;
			}
			Value.push_back(buffCharC);		//move the char bit
		}

		try						//needed a try catch or the stoi would crash
		{
			M = stoi(Value);			//convert value into a string
		}
		catch(...)					//unconditional catch
		{
			break;
		}

		if (M > 999999999 || M < -999999999)
		{
			write(writec, "*@", 2);			//write into the writing pipe
		}

		else
		{
			M = (7 * M) - 6;		//equation

			Buffer = to_string(M);					//convert M to a string and store in Buffer
			cerr << "Child         Value: " << M <<endl;		//print line
			write(writec, Buffer.c_str(), Buffer.length());		//call the write function again
			write(writec, "@", 1);
		}

		Buffer.clear();			//clear value and buffer so the math is not changed
		Value.clear();
	}

}

/*
GWork(): two ints for the pipes

gets called by the main and handles the string values and buffer, calculates M,
and converts M into a string

returns: nothing
*/

void GWork(int readg, int writeg)
{
	string Buffer;
	string Value;
	char BuffCharG;			//new char for the grandchild function
	long int M;

	while(true)
	{
		while(read(readg, &BuffCharG, 1) > 0)
		{
			if(BuffCharG == '@')
			{
				break;
			}
			Value.push_back(BuffCharG);
		}

		try						//needed a try catch or the stoi would crash
		{
			M = stoi(Value);			//convert value into a string
		}
		catch(...)					//unconditional catch
		{
			break;
		}

		if (M > 999999999 || M <-999999999)
		{
			write(writeg, "*@", 2);			//write into the writing pipe
			break;
		}

		else
		{
			M = 30 - 4 * M;	//do the math on the number

			Buffer = to_string(M);					//convert M to a string and store in Buffer
			cerr << "GrandChild    Value: " << M <<endl;		//printline
			write(writeg, Buffer.c_str(), Buffer.length());		//call the write function again
			write(writeg, "@", 1);
		}

		Buffer.clear();			//clear value and buffer so the math is not changed
		Value.clear();
	}
}


