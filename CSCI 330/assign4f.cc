/*
 file with all functions

 This file will hold all the functions useed by assign4.cc
*/
#include "assign4.h"
#include <iostream>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <cstring>
#include <bitset>
using namespace std;

/*
 func: takes an int, char, and int

 purpose: completers caesar cipher

 returns: nothing
*/
void func(int num, char *buf, int flength)
{
	char result=' ';
	for(int i=0; i<flength; i++)
	{
		if(isupper(buf[i]))					//if a capital letter
		{
			result = char(int(buf[i]+num-65)%26+65);	//convert the letter
			buf[i] = result;				//set the buffer to the new value
		}
		else							//if lowercase
		{
			result = char(int(buf[i]+num-97)%26+97);	//convert the letter
			buf[i] = result;				//set the buffer to the new value
		}
	}
}

/*
 funr: takes an int, char, and an int

 Purpose: to rotate the bits by the amount the user has indicated

 returns: nothing
*/
void funr(int num, char *buf, int flength)
{
	for(int i =0; i<flength; i++)
	{
		buf[i] = buf[i]+num;
	}
}

/*
 funb: takes a char and an int

 purpose: converts the file to binary

 returns: nothing
*/
void funb(char *buf, int flength)
{
 	for(int i = 0; i < flength; i++)
	{
		bitset<8> x(buf[i]);
		cerr<<x;
	}
	cerr<<endl;
}

/*
 funx: takes a char and int

 Converts the file to hex

 returns: nothing
*/
void funx(char *buf, int flength)
{
	for(int i = 0; i<flength; i++)
	{
                cerr<<hex<<(int)buf[i];
	}
	cerr<<endl;
}

