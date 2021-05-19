/*
Charles Alms
z1797837
Assignmet 6 extra credit
Due 4/13/20

Purpose is to simulate memory management. This Assignment assumes
we only have 16MB of memeory and the operating system uses the first
3MB.

Run the program with either "F" for first fit, or "B" for best fit.
*/
#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <cstring>
#include <climits>
#include <fstream>

using namespace std;

#define HOWOFTEN 6		//how often to print const

char firstOrBest = 'F';		//char used to decide if first fit or best fit
struct Block;			//decalre structure

struct Block			//block structure
{
	Block(int, int);
	int add;
	int size;
	string pid;
	string bpid;
	Block * prev;
	Block * next;
};

Block::Block(int x, int y)
{
	add = x;
	size = y;
}

Block * Avail = nullptr;	//available memeory
Block * InUse = nullptr;	//in use memory

/*
Function: blockDelete
returns: nothing
arguments: 2 block objects
purpose: delates the block
*/
void blockDelete(Block * iter, Block ** from)
{
	if (iter->prev == nullptr && iter->next != nullptr)			//if the first iterator is empty but not next
	{
		*from = iter->next;
		iter->next->prev = nullptr;					//set both to null
	}
	else if (iter->prev != nullptr && iter->next != nullptr)		//if both the first and next iterator are not empty
	{
		iter->prev->next = iter->next;
		iter->next->prev = iter->prev;
	}
	else if (iter->prev == nullptr && iter->next == nullptr)		//if both the first and next iterator are empty
	{
		delete *from;							//delete it
		*from = nullptr;						//set it = to null
	}
	else
	{
		iter->prev->next = nullptr;
	}
	if (*from != nullptr)							//if not empty, delete it
	{
		delete iter;
	}
}

/*
Function: merge
returns nothing
purpose: will merge memory blocks that are avaiable together
*/
void merge()
{
	Block * iter = Avail;
	Block * hold;
	bool flag = false;
	while (iter->next != nullptr)
	{
		if ((iter->size + iter->next->size) < 4*1024*1024)		//if both blocks are smaller than 4mbs
		{
			flag = true;
			cout<<"Merging two blocks at "<<iter->add<<" and "<<iter->next->add<<endl;
			iter->size += iter->next->size;				//combine the size
			hold = iter->next;
			iter->next = iter->next->next;
			delete hold;
		}
		iter = iter->next;
	}
	if (flag == true)								//if flag is true
	{
		merge();
	}
}

/*
Function: alloc
returns: nothing
arguments: string, int, string
purpose: allocates the memory
*/
void alloc(string own, int size, string block)
{
	Block * iter = Avail;
	Block * next;
	int bestSize = INT_MAX;
	bool stop = false;
	cout<<"Transaction: request to allocate "<<size<<" bytes for process "<<own<<", block ID: "<<block<<endl;

	if (firstOrBest == 'F')					//if first fit
	{
		while (iter != nullptr && stop != true)		//while not empty and not found
		{
			if (iter->size >= size)			//if the iterator size > than the size
			{
				stop = true;			//stop
			}
			else
			{
				iter = iter->next;		//else, move to the next
			}
		}
	}
	else							//if best fit
	{
		while (iter != nullptr)				//while not empty
		{
			if (iter->size >= size)			//while iter size is bigger than the size
			{
				if (bestSize > iter->size)	//if bestsize it too big
				{
					bestSize = iter->size;	//set bestsize to the smaller size
					next = iter;
				}
				iter = iter->next;
			}
			else					//if smaller, move to the next position
			{
				iter = iter->next;
			}
		}
		if (next != nullptr)				//if it is not empty, stop
		{
			stop = true;
			iter = next;
			next = nullptr;
		}
	}

	if (stop != true)					//if it was not empty, say no space available
	{
		cout<<"No space was found"<<endl;
	}
	else							//if there is space
	{
		cout<<"Found a block of size "<<iter->size<<endl;
		next = new Block(iter->add, size);

		iter->add += size;				//increase the size
		iter->size -= size;
		if (iter->size <= 0)
		{
			blockDelete(iter, &Avail);		//call the blockDelete
		}

		iter = InUse;
		if (iter != nullptr)
		{
			while (iter->next != nullptr)		//while it is not empty
			{
				iter = iter->next;		//move on
			}
		}
		next->pid = own;
		next->bpid = block;
		next->next = nullptr;
		next->prev = nullptr;

		if (InUse == nullptr)				//if it is empty
		{
			InUse = next;				//move on the InUse
		}
		else						//else, move the iterator
		{
			iter->next = next;
			next->prev = iter;
		}
		cout<<"Success in allocating a block"<<endl;
	}
}

/*
Function: dealloc
returns: nothing
arguments: 2 strings
purpose: deallocates the memory
*/
void dealloc(string own, string block)
{
	cout<<"Transaction: request to deallocate block ID "<<block<<" for process "<<own<<endl;

	Block * iter = InUse;				//iterator is = to the InUse
	Block * position;
	bool found = false;

	while (iter != nullptr && found != true)			//if not found and not null1
	{
		if (iter->pid == own && iter->bpid == block)		//if the pids equal the blocks and process ids
		{
			found = true;
		}
		else							//else move on to the next
		{
			iter = iter->next;
		}
	}

	if (found == false)						//if you can not find the right space
	{
		cout<<"Unable to comply as the indicated block cannot be found"<<endl;
	}
	else								//if the space is found
	{
		Block * prevHold = nullptr;

		position = new Block(iter->add, iter->size);

		blockDelete(iter, &InUse);				//call blockDelete
		iter = Avail;

		found = false;

		while (iter != nullptr && found != true)		//while not empty and not found
		{
			if (position->add < iter->add)			//if the position is smaller than iter
			{
				found = true;
			}
			else
			{
				prevHold = iter;
				iter = iter->next;
			}
		}

		if (iter == nullptr)					//if the iterator is empty
		{
			iter = Avail;					//make iterator = to avail
			while (iter->next != nullptr)			//while iterator is not empty
			{
				iter = iter->next;
			}

			iter->next = position;				//switch position and iter
			position->prev = iter;
			position->next = nullptr;
		}
		else if (iter == Avail)					//if the iterator finds an unavailable position
		{
			position->next = Avail;				//switch
			Avail->prev = position;
			position->prev = nullptr;

			Avail = position;
		}
		else
		{
			prevHold->next = position;			//switch
			position->next = iter;
			position->prev = prevHold;
			iter->prev = position;
		}
		merge();						//call the merge function
		cout<<"Success in deallocating a block"<<endl;
	}
}

/*
Function: terminate
returns: nothing
arguments: string and bool
purpose: terminates process and frees up used memory
*/
void terminate(string own, bool firstRun)
{
	if (firstRun)					//if the first time tunning the program, we can not terminate nothing
	{
		cout<<"Transaction: request to terminate process "<<own<<endl;
	}

	Block * iter = InUse;
	Block * position;
	bool found = false;

	while (iter != nullptr && found != true)		//while not empty and running at least twice 
	{

		if (iter->pid == own)
		{
			found = true;
		}
		else
		{
			iter = iter->next;
		}
	}

	if (found == false && firstRun == true)			//if it can not find anything and is the first time running
	{
		cout<<"Unable to comply as the indicated block cannot be found"<<endl;
	}
	else if (found == true)					//if found something
	{
		Block * prevHold = nullptr;

		position = new Block(iter->add, iter->size);

		position->next = nullptr;
		position->prev = nullptr;

		blockDelete(iter, &InUse);			//delete the block
		iter = Avail;
		found = false;

		while (iter != nullptr && found != true)	//while not empty and not found
		{
			if (position->add < iter->add)
			{
				found = true;
			}
			else
			{
				prevHold = iter;
				iter = iter->next;
			}
		}
		if (iter == nullptr)				//if the iterator was empty
		{
			iter = Avail;
			while (iter->next != nullptr)
			{
				iter = iter->next;
			}

			iter->next = position;
			position->prev = iter;
			position->next = nullptr;
		}
		else if (iter == Avail)				//if the iterator = the available space
		{
			position->next = Avail;
			Avail->prev = position;
			position->prev = nullptr;

			Avail = position;
		}
		else						//else
		{
			prevHold->next = position;
			position->next = iter;
			position->prev = prevHold;
			iter->prev = position;
		}

		if (InUse != nullptr)
		{
			terminate(own, false);
		}

		if (firstRun== true)				//if the first time running
		{
			merge();				//call merge function
			cout<<"Success in terminating a process"<<endl;
		}
	}
}

/*
Function: load
returns: nothing
arguments: string, size, string
purpose: loads process into the memory
*/
void load(string own, int size, string block)
{
	Block * iter = Avail;			//set the iterators
	Block * next = nullptr;
	int bestSize = INT_MAX;
	bool stop = false;
	cout<<"Transaction: request to load process "<<own<<", block ID "<<block<<" using "<<size<<" bytes"<<endl;
	if (firstOrBest == 'F')			//if the condition was first fit
	{
		while (iter != nullptr && stop != true)
		{
			if (iter->size >= size)
			{
				stop = true;			//bool to stop if the size is too big
			}
			else					//if not too big, move the iterator
			{
				iter = iter->next;
			}
		}
	}
	else							//if best fit
	{
		while (iter != nullptr)				//white not blank
		{
			if (iter->size >= size)			//white less than the size
			{
				if (bestSize > iter->size)	//if the best size is bigger than the other size
				{
					bestSize = iter->size;	//make the best size == the iterator size
					next = iter;
				}
				iter = iter->next;		//move the iterator
			}
			else
			{
				iter = iter->next;
			}
		}

		if (next != nullptr)				//if empty
		{
			stop = true;				//stop and set the iterator to the next position
			iter = next;
			next = nullptr;
		}
	}
	if (stop != true)					//if the size was too small
	{
		cout<<"Unable to comply as no block of adequate size is available"<<endl;
	}
	else							//if th size was perfect
	{
		cout<<"Found a block of size "<<iter->size<<endl;

		next = new Block(iter->add, size);		//make next = to the block

		iter->add += size;
		iter->size -= size;

		if (iter->size <= 0)				//if the size is negative,
		{
			blockDelete(iter, &Avail);		//delete the block
		}

		iter = InUse;

		if (iter != nullptr)
		{
			while (iter->next != nullptr)
			{
				iter = iter->next;		//while not empty, move the iterator
			}
		}
		next->pid = own;
		next->bpid = block;
		next->next = nullptr;
		next->prev = nullptr;

		if (InUse == nullptr)
		{
			InUse = next;
		}
		else
		{
			iter->next = next;
			next->prev = iter;
		}
		cout<<"Success in allocating a block"<<endl;
	}
}

/*
Function: print
returns: nothing
Purpose: takes no arguments. Prints the contents of memory
*/
void print()
{
	Block * iter = Avail;			//iterator for the block
	long int totalSize = 0;			//size counter
	cout<<"List of available blocks"<<endl;
	if (iter == nullptr)
	{
		cout<<"(none)"<<endl;
	}

	while (iter != nullptr)			//while pointing at something
	{
		cout<<"Start Address = "<<setw(8)<<iter->add<<" Size = "<<setw(7)<<iter->size<<endl;
		totalSize += iter->size;
		iter = iter->next;
	}
	cout<<"Total size of the list = "<<totalSize<<endl<<endl;

	iter = InUse;		//set iterator to memory InUse
	totalSize = 0;

	cout<<"List of blocks in use"<<endl;
	if (iter == nullptr)
	{
		cout<<"(none)"<<endl;
	}

	while (iter != nullptr)
	{
		cout<<"Start Address = "<<setw(9)<<iter->add<<" Size = "<<setw(8)<<iter->size<<" Process ID = "<<iter->pid<<" Block ID = "<<iter->bpid<<endl;
		totalSize += iter->size;
		iter = iter->next;
	}
	cout<<"Total size of the list = "<<totalSize<<endl<<endl;
}

/*
Function: main
Purpose: runs the whole program. Takes in 1 argument
*/
int main(int arg, char ** letter)
{
	string type;		//string for first fit or best fit
	if (arg != 2)
	{
		cout<<"Incorrect command. Please type F or B after ./Assign6"<<endl;
		exit(-1);
	}
	if(letter[1][0] == 'F' || letter[1][0] == 'f')		//if you wantt first fit
	{
		type = "First-Fit";

	}
	else if(letter[1][0] == 'B' || letter[1][0] == 'b')	//if you want best fit
	{
		type = "Best-Fit";
	}
	else				//if neither F or B was picked
	{
		cout<<"ERROR in arguments"<<endl;
		exit(-1);
	}

	Block * blockIter;		//pointer for iteration

	Avail = new Block(3*1024*1024, 1024*1024);		//1 mb

	Avail->next = new Block(Avail->size + Avail->add, 2*1024*1024);	//2mbs
	Avail->prev = nullptr;

	blockIter = Avail->next;		//move the pointer
	blockIter->prev = Avail;

	//creates new blocks
	blockIter->next = new Block(blockIter->size + blockIter->add, 2*1024*1024);
	blockIter->next->prev = blockIter;
	blockIter = blockIter->next;

	blockIter->next = new Block(blockIter->size + blockIter->add, 4*1024*1024);
	blockIter->next->prev = blockIter;
	blockIter = blockIter->next;

	blockIter->next = new Block(blockIter->size + blockIter->add, 4*1024*1024);
	blockIter->next->prev = blockIter;
	blockIter->next->next = nullptr;

//-----------------------------------------------------------------------
	ifstream inFile;		//file opening
	inFile.open("input.txt");

	if (!inFile)
	{
		cout<<"unable to open input file";
		exit(-1);
	}
	char inputLine[256];		//input line from the file

	string ownHold = "";
	string idHold = "";
	int sizeHold = 0;
	int count = 0;

	cout<<endl;
	cout<<"Simulation of Memory Management using the "<<type<<" algorithm"<<endl;
	cout<<"Beginning of the run"<<endl;
	cout<<endl;

	print();

	while (inFile && inFile.peek() != '?')
	{
		if ((count % HOWOFTEN) == 0)		//if counter%6 == 0, call print
		{
			print();
		}
		memset(inputLine, '\0', 256);		//make the input line from the file blank

		inFile.getline(inputLine, 256);		//grab the input line from the file

		switch(inputLine[0])			//switch the letter from the file to the case
		{
			case 'L':			//if L, we do load
				strtok(inputLine, " \n\r");
				ownHold = (string) strtok(nullptr, " \n\r");
				sizeHold = atoi(strtok(nullptr, " \n\r"));
				idHold = (string) strtok(nullptr, " \n\r");
				load(ownHold, sizeHold, idHold);
				break;
			case 'A':			//if A, we do alloc
				strtok(inputLine, " \n\r");
				ownHold = (string) strtok(nullptr, " \n\r");
				sizeHold = atoi(strtok(nullptr, " \n\r"));
				idHold = (string) strtok(nullptr, " \n\r");
				alloc(ownHold, sizeHold, idHold);
				break;
			case 'D':			//if D, we do dealloc
				strtok(inputLine, " \n\r");
				ownHold = (string) strtok(nullptr, " \n\r");
				idHold = (string) strtok(nullptr, " \n\r");
				dealloc(ownHold, idHold);
				break;
			case 'T':			//if T, we do terminate
				strtok(inputLine, " \n\r");
				ownHold = (string) strtok(nullptr, " \n\r");
				terminate(ownHold, true);
				break;
			default:
				break;
		}
	}
	cout<<"\n\n\nEnd of the run"<<endl;
	cout<<endl;
	print();		//call print one last time

	return 0;
}











