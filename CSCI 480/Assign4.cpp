/***********************************************************
Assign4 -- CSCI 480 -- Professor Hutchins

Name: Charles Alms  z1797837

Due: 3/24/2020

Purpose: memory

The program should accept two command-line argument. The first is 'F' or 'L', where 'F' means that the First-In-First-Out page replacement algorithm should be used and 'L' means that the Least-Recently-Used algorithm should be used,
and the second is 'P' or 'D', where 'P' indicates that we will use pre-paging and 'D' indicates that we will use demand paging.  This we might have
"Assign4 F D", for instance.

************************************************************/

#include <fstream>
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
#include <queue>
#include <list>

using namespace std;

#define TOTALPAGES  25		//constant for pages

queue<int> fifo;		//first in first out queue
list<int> lilo;			//last in last out queue

//created a structure too handle the pages
struct page_t {
	int pagenum;
	int framenum;
	bool mod;
} pages[TOTALPAGES];


struct fileline{
	int logicalAddress;
	char command;
};

//Function Declarations
void buildTable(string);
void printTable(page_t);

/*
int main

returns: nothing

purpose: runs the main program. Call other functions for
printing and handles some math. Reads in the file
*/
int main(int argc, char* argv[])		//takes 2 arguments
{
	int addr;			//address from file
	char rOrw;			//read or write letter from file
	ifstream inFile;

	inFile.open("./input.txt");		//opent the file

	if (!inFile)
	{
	cout << "Unable to open file input.txt"<<endl;;
	exit(1);
	}

	vector<fileline> file;		//vector for the file

	if(inFile.is_open())
	{
		while(!inFile.eof())
		{
			inFile >> addr;		//add the address to the file
			inFile >> rOrw;

			file.push_back({addr, rOrw});		//addes to the vector until the file is empty
		}
	}

	string arg1 = argv[1];		//first argument
	string arg2 = argv[2];		//second argument

	buildTable(arg2);			//call the table building function

	if(arg1 == "F" || arg1== "f")		//if FIFO was picked
	{
		if(arg2 == "p" || arg2 == "P")		//if prepaging was picked
		{
			cout<<"FIFO with prepaging"<<endl;
			int counter = 0;			//counter for displaying table
			for(int x = 0; x < 15; x++)		//add the first 15 pages to the queue
			{
				fifo.push(x);
			}

			for(unsigned int i = 0; i < file.size(); i++)
			{
				int pageNumber = file[i].logicalAddress/200;		//divide the address by 200
				if(file[i].command == 'W')			//if writing
				{
			        	if(pages[pageNumber].framenum == -1)		//add the page numbers and modified to the queue
                                        {
                                                pages[pageNumber].framenum = pages[fifo.front()].framenum;
                                                pages[fifo.front()].framenum = -1;

                                                fifo.pop();
                                                fifo.push(pageNumber);


                                                pages[fifo.front()].mod = true;			//set modified to true if writing
                                                cout << "write the page " << pageNumber << " from frame " << pages[fifo.front()].framenum << " to disk" << endl;
                                                counter++;
                                	}
				}
				else if(file[i].command == 'R')			//if reading
				{
					if(pages[pageNumber].framenum == -1)
					{
						pages[pageNumber].framenum = pages[fifo.front()].framenum;
						pages[fifo.front()].framenum = -1;

                                                fifo.pop();
                                                fifo.push(pageNumber);


						pages[fifo.front()].mod = false;		//set modiified to false if reading
						cout << "read page " << pageNumber << " from disk into frame " << pages[fifo.front()].framenum <<endl;
						counter++;
					}
				}
				if(counter % 10 == 0 && counter != 0)		//if the counter reaches 10, display table
				{
					cout<<"Page Number" << setw(21)<<"Frame Number" << setw(22)<<"Modified"<<endl;
 					for (int i = 0; i < TOTALPAGES; ++i)
        				{
						printTable(pages[i]);
					}
				counter = 0;
				}
			}
		}

		else if(arg2 == "D" || arg2 == "d")		//if demand pick
		{
			cout<<"FIFO with demand paging"<<endl;
                	int counter = 0;
			int frameIndex = 0;			//index of the frame for demand paging

        	        for(unsigned int i = 0; i < file.size(); i++)
               	 	{
				int pageNumber = file[i].logicalAddress/200;
	                 	if(file[i].command == 'W')			//for write
                                {
                                        if(pages[pageNumber].framenum == -1)
                                        {
						if(frameIndex < 15)		//if there are less than 15 pages availalbe
						{
							frameIndex++;		//increase frame index by 1
                	                                fifo.pop();
                        	                        fifo.push(frameIndex);		//push index into queue
							pages[frameIndex].framenum = pages[fifo.front()].framenum;
						}

						else		//if there are no pages left
						{
 							pages[pageNumber].framenum = pages[fifo.front()].framenum;
                                                	pages[fifo.front()].framenum = -1;

	                                                fifo.pop();		//pop off the first element
        	                                        fifo.push(pageNumber);	//push the queue back

                	                                pages[fifo.front()].mod = true;
                        	                        cout << "write the page " << pageNumber << " from disk into frame " << pages[fifo.front()].framenum <<endl;
                                	                counter++;
							frameIndex++;
                                                }
					}
                                }
                                else if(file[i].command == 'R')		//if read
                                {
                                        if(pages[pageNumber].framenum == -1)		//does the same as above
                                        {
                                                if(frameIndex < 15)
						{
							frameIndex++;
                                        	        fifo.pop();
                                                	fifo.push(frameIndex);
							pages[frameIndex].framenum = pages[fifo.front()].framenum;
						}
						else
						{
							pages[pageNumber].framenum = pages[fifo.front()].framenum;
        	                                        pages[fifo.front()].framenum = -1;

                        	                        fifo.pop();
                                	                fifo.push(pageNumber);


                                        	        pages[fifo.front()].mod = false;		//sets modify to false
                                                	cout << "read page " << pageNumber << " from disk into frame " << pages[fifo.front()].framenum <<endl;
 	                                                counter++;
							frameIndex++;
                                                }
					}
                                }

                                if(counter % 10 == 0 && counter != 0)		//counter to display table
                                {
                                        cout<<"Page Number" << setw(21)<<"Frame Number" << setw(22)<<"Modified"<<endl;
                                        for (int i = 0; i < TOTALPAGES; ++i)
                                        {
                                                printTable(pages[i]);
                                        }
	                                counter = 0;
                                }
				else
				{
					cout<<"Erorr in second argument"<<endl;
				}
			}
		}
//---------------------------------------------------------------------------------------------
	else if( arg1 == "L" || arg1== "l")		//if last in last out
	{

		if(arg2 == "p" || arg2 == "P")			//if prepaging
        	{
			cout<<"LILO with prepaging"<<endl;

	                int counter = 0;
	  	      for(int x = 0; x < 15; x++)			//add elements to the list
                	{
				lilo.push_front(x);
			}

	                for(unsigned int i = 0; i < file.size(); i++)
        	        {
                	int pageNumber = file[i].logicalAddress/200;	//divide the address by 200
	                if(file[i].command == 'W')			//if writing
       	         	{
                        	if(pages[pageNumber].framenum == -1)	//does the same as prepaging for FIFO
                        	{
                        	        pages[pageNumber].framenum = pages[lilo.front()].framenum;
  	                       		pages[lilo.front()].framenum = -1;

	                                lilo.pop_front();
        	                        lilo.push_back(pageNumber);

	        	                pages[lilo.front()].mod = true;		//set modify to true
                        	        cout << "write the page " << pageNumber << " from frame " << pages[fifo.front()].framenum << " to disk" << endl;
	                        	counter++;
                                                }
                        	}
				else if(file[i].command == 'R')		//if reading
				{
					if(pages[pageNumber].framenum == -1)
                        		{
                               			pages[pageNumber].framenum = pages[fifo.front()].framenum;
		                     		pages[lilo.front()].framenum = -1;

	                                        lilo.pop_front();
       	                                 	lilo.push_back(pageNumber);

	                                        pages[lilo.front()].mod = false;		//sets modified to false
        	                                cout << "read page " << pageNumber << " from disk into frame " << pages[lilo.front()].framenum <<endl;
               	                         	counter++;
                                	}
                        	}
                        	if(counter % 10 == 0 && counter != 0)		//if counter is 10, display the table
                        	{
                        	        cout<<"Page Number" << setw(21)<<"Frame Number" << setw(22)<<"Modified"<<endl;
                               		for (int i = 0; i < TOTALPAGES; ++i)
                                	{
                                        	printTable(pages[i]);
                                	}
                                	counter = 0;
                        	}
                	}
        	}
		else if(arg2 == "D" || arg2 == "d")
		{
			cout<<"LILO with demand paging"<<endl;

			int counter = 0;
                        int frameIndex = 0;                     //index of the frame for demand paging

                        for(unsigned int i = 0; i < file.size(); i++)
                        {
                                int pageNumber = file[i].logicalAddress/200;
                                if(file[i].command == 'W')                      //for write
                                {
                                        if(pages[pageNumber].framenum == -1)
                                        {
                                                if(frameIndex < 15)             //if there are less than 15 pages availalbe
                                                {
                                                        frameIndex++;           //increase frame index by 1
                                                        lilo.pop_front();
                                                        lilo.push_back(frameIndex);          //push index into queue
                                                        pages[frameIndex].framenum = pages[lilo.front()].framenum;
                                                }

                                                else            //if there are no pages left
                                                {
                                                        pages[pageNumber].framenum = pages[lilo.front()].framenum;
                                                        lilo.pop_front();             //pop off the first element
                                                        lilo.push_back(pageNumber);  //push the queue back

                                                        pages[lilo.front()].mod = true;
                                                        cout << "write the page " << pageNumber << " from disk into frame " << pages[lilo.front()].framenum <<endl;
                                                        counter++;
                                                        frameIndex++;
                                                }
                                        }
                                }
                                else if(file[i].command == 'R')         //if read
                                {
                                        if(pages[pageNumber].framenum == -1)            //does the same as above
                                        {
                                                if(frameIndex < 15)
                                                {
                                                        frameIndex++;
                                                        lilo.pop_front();
                                                        lilo.push_back(frameIndex);
                                                        pages[frameIndex].framenum = pages[lilo.front()].framenum;
                                                }
                                                else

                                                       pages[lilo.front()].framenum = -1;
                                                {
                                                        pages[pageNumber].framenum = pages[lilo.front()].framenum;
                                                        pages[lilo.front()].framenum = -1;

                                                        lilo.pop_front();
                                                        lilo.push_back(pageNumber);


                                                        pages[lilo.front()].mod = false;                //sets modify to false
                                                        cout << "read page " << pageNumber << " from disk into frame " << pages[lilo.front()].framenum <<endl;
                                                        counter++;
                                                        frameIndex++;
                                                }
                                        }
                                }

                                if(counter % 10 == 0 && counter != 0)           //counter to display table
                                {
                                        cout<<"Page Number" << setw(21)<<"Frame Number" << setw(22)<<"Modified"<<endl;
                                        for (int i = 0; i < TOTALPAGES; ++i)
                                        {
                                                printTable(pages[i]);
                                        }
                                        counter = 0;
                                }

		}
		}
		else		//if not p or d
                {
                        cout<<"Erorr in second argument"<<endl;
                }

	}

	}
	else	//if not L or F
	{
		cout<<"Error in first argument"<<endl;
	}


	return 0;
}

/*
buildTable

returns: nothing

arguments: string

purpose: sets up the table with the values from the file.
contains an array for frame numbers
*/
void buildTable(string arg2)		//set up the table
{

	int frames[15] = {101,102,103,104,105,201,202,203,204,205,301,302,303,304,305};	//array of the frame numbers


	if(arg2 == "D" || arg2 == "d")
	{
		for(int k = 0; k < TOTALPAGES; ++k)
		{
			pages[k].pagenum = k;
			pages[k].framenum = -1;
			pages[k].mod = NULL;
		}
	}
	else if(arg2 == "P" || arg2 == "p")
	{
        	for(int k = 0; k < TOTALPAGES; ++k)
        	{
        		pages[k].pagenum = k;

			if(k<15)
			{
        			pages[k].framenum = frames[k];
        		}
			else
			{
				pages[k].framenum = -1;
			}
			pages[k].mod = false;
        	}
	}
	else
	{
		cout << "error in arguements ";
	}
}

/*
printTable

returns: nothing

purpose: takes in page_t and will print the table
with the appropriate format. Has fixed spacing and
converts the true and false from modified to yes
or no
*/
void printTable(page_t page)	//displays the table
{
	cout << page.pagenum << setw(21)<< page.framenum << setw(22);

	if(page.mod)			//check to see if it was modified
		cout << "Yes" << endl;
	else
		cout << "No" << endl;

}


