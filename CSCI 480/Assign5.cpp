/*
Charles Alms z1797837
Assignment 5
Process Synchronization
Due 4/6/20

The purpose is to use threads, semaphores, and a mutex
to create a producer-comsumer problem.

Some examples of numbers to enter: 2, 2, 2, 2
6, 2, 2, 6
7, 5, 5, 7
Numbers follow the same pattern of pnum, cnum, pstep, cstep
*/
#include <unistd.h>
#include <pthread.h>
#include <stdio.h>
#include <iostream>
#include <semaphore.h>
#include <stdlib.h>
#include <iomanip>
#include <queue>
#include <list>

using namespace std;

#define BUFFER_SIZE 35
int P_NUMBER = 7;
int C_NUMBER = 5;
int P_STEPS = 5;
int C_STEPS = 7;

int widgetCounter = 0;
queue<int> Q;		//the original queue
queue<int> Q2;		//copy of Q that will be used for printing
queue<int> W;		//queue for the widget value

sem_t NotFull; //semaphore is not full
sem_t NotEmpty; //semaphore is not empty

pthread_mutex_t mutex;

/***********************************************
Function: Used to build and print the widget
Use: prints the widget and thread counter
Paramater: int thread ID
Returns: nothing
***********************************************/
void buildWidget(int threadID)
{
	while(!Q2.empty())			//while the queue is not empty, print it
        {
		cout<<"P"<<Q2.front()<<"W"<<W.front()<<" ";
                Q2.pop();
        }
}
/************************************************
Function: Insert(int threadID)
Use: Inserts a thread
Parameters: (int threadID)
Returns: Nothing
*************************************************/
void Insert(int threadID)
{
	int counter = 0;
	int code;
	code = pthread_mutex_lock(&mutex);
	int widgetArr[BUFFER_SIZE];
	widgetArr[threadID] = counter;

	if(code == 0)
	{
		Q.push(threadID);		//Q will hold the thread IDs
		Q2 = Q;				//make a copy of Q
		W.push(widgetArr[threadID]);    //push the W queue to hold the widget value
		widgetCounter++;
		cout << "Producer " << threadID << " inserted one item.  Total is now  " << widgetCounter << ".  Buffer now contains: ";
		buildWidget(threadID);
		cout<<endl;
	}
	else
	{
		cout << "Producer " << threadID << " Error in lock" << endl;
		exit(-1);
	}

	code = pthread_mutex_unlock(&mutex);

	if (code != 0)
	{
		cout << "Producer " << threadID << " Error in Unlock" << endl;
		exit(-1);
	}
}

/************************************************
Function: Remove(int threadID)
Use: Removes a thread
Parameters: (int threadID)
Returns: Nothing
*************************************************/
void Remove(int threadID)
{
	int code;
	code = pthread_mutex_lock(&mutex);

	if (code == 0)
	{
		widgetCounter--;
		Q.pop();
		Q2 = Q;
		if(widgetCounter == 0)
		{
			cout << "Consumer " << threadID << " removed one item.   Total is now  " << widgetCounter << ".  Buffer is now empty"<<endl;
		}
		else
		{
			cout << "Consumer " << threadID << " removed one item.   Total is now  " << widgetCounter << ".  Buffer now contains: ";
			buildWidget(threadID);
                        cout<<endl;

		}
	}
	else
	{
		cout << "Consumer " << threadID << ": Failure in Remove: lock" << endl;
		exit(-1);
	}

	code = pthread_mutex_unlock(&mutex);

	if (code != 0)
	{
		cout << "Consumer : " << threadID << ": Failure in Remove: Unlock" << endl;
		exit(-1);
	}
}

/************************************************
Function: * Produce(void * threadID)
Use: Produces a thread
Parameters: (void * threadID)
Returns: Nothing
*************************************************/
void * Produce(void * threadID)
{
	long temp = (long) threadID;

	for (int i = 0; i < P_STEPS; i++)
	{
		sem_wait(&NotFull);
		Insert(temp);
		sem_post(&NotEmpty);
		sleep(1);
	}
	pthread_exit(NULL);
}

/************************************************
Function: * Consume(void * threadID)
Use: Consumes a thread
Parameters: (void * threadID)
Returns: Nothing
*************************************************/
void * Consume(void * threadID)
{
	long temp = (long) threadID;

	for (int i = 0; i < C_STEPS; i++)
	{
		sem_wait(&NotEmpty);
		Remove(temp);
		sem_post(&NotFull);
		sleep(1);
	}
	pthread_exit(NULL);
}

/************************************************
Function: main(int argc, char *argv[])
Use: Illustrates the Producer-Consumer Problem
Parameters: (int argc, char *argv[])
Returns: Nothing
*************************************************/
int main(int argc, char *argv[])
{
	int pnum, cnum, pstep, cstep;

	cout<<"P number: ";
	cin>>pnum;
	cout<<"C number: ";
	cin>>cnum;
	cout<<"P step: ";
	cin>>pstep;
	cout<<"C step: ";
	cin>>cstep;

	P_NUMBER = pnum;
	C_NUMBER = cnum;
	P_STEPS = pstep;
	C_STEPS = cstep;

	int rc;
	sem_init(&NotFull, 0, BUFFER_SIZE);
	sem_init(&NotEmpty, 0, 0);
	pthread_t Consumer[C_NUMBER];
	pthread_t Producer[P_NUMBER];
	pthread_mutex_init(&mutex, NULL);

	cout << "\nSimulation of Producer and Consumers\n" << endl;
	cout << "The semaphores and mutex have been initialized.\n" << endl;

	for (long i = 0; i < C_NUMBER; i++)
	{
		rc = pthread_create(&Consumer[i], NULL, Consume, (void *) i);
		if(rc)
		{
			cout << "Error in Consumer create" << endl;
			exit(-1);
		}
	}

	for (long i = 0; i < P_NUMBER; i++)
	{
		rc = pthread_create(&Producer[i], NULL, Produce, (void *) i);
		if(rc)
		{
			cout << "Error in producer create" << endl;
			exit(-1);
		}
	}

	for (int i = 0; i < C_NUMBER; i++)
	{
		pthread_join(Consumer[i], NULL);
	}

	for(int i = 0; i < P_NUMBER; i++)
	{
		pthread_join(Producer[i], NULL);
	}

	cout << "\n\nAll the producer and consumer threads have been closed." << endl;
	cout << "The semaphores and mutex have been deleted.\n" << endl;

	pthread_mutex_destroy(&mutex);
	pthread_exit(NULL);

	sem_destroy(&NotFull);
	sem_destroy(&NotEmpty);

	return 0;
}


