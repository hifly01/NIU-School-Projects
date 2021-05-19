/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 8, Part 3
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   4/26/18
 
   FUNCTION:   This program builds and sorts lists using the quick
               sort algorithm.
*********************************************************************/  

#ifndef SORTS_H
#define SORTS_H

#include <iostream>
#include <stdexcept>
#include <fstream>

using std::cout;
using std::endl; 
using std::setw; 
using std::ifstream; 
using std::vector; 

/***************************************************************
Function: buildList
Use: This method reads in the data from the input file and makes
it into a list. 
Parameters: vector<T>&, const char* 
Returns: None
Notes: 
***************************************************************/

template <class T>
void buildList(vector<T>& set, const char* fileName)
{
    T item; 
    ifstream inFile;
    inFile.open(fileName);
    if (!inFile)
    {
        cout << "Unable to open input file " << fileName << endl;
        exit(1);
    }
    inFile >> item;
    while (inFile)
    {
        set.push_back(item);

        inFile >> item;
    }
    inFile.close();
}

/***************************************************************
Function: printList
Use: This method displays the list that was made from buildList
Parameters: vector<T>&, int, int 
Returns: None
Notes: 
***************************************************************/

template <class T>
void printList(const vector<T>& set, int itemWidth, int numPerLine)
{
    int i = 0;
    while (i < (int) set.size())
    {
        cout << setw(itemWidth) << set[i] << ' ';
        i++;
        if (i % numPerLine == 0)
            cout << endl;
    }
    if (i % numPerLine != 0)
        cout << endl;
}

/***************************************************************
Function: lessThan
Use: This method compares two items to see which item is less than
the other
Parameters: const T&, const T&
Returns: None
Notes: 
***************************************************************/

template <class T> 
bool lessThan(const T& item1, const T& item2)
{
    return (item1 < item2); 
}

/***************************************************************
Function: greaterThan
Use: This method compares two items to see which item is greater
than the other
Parameters: const T&, const T& 
Returns: None
Notes: 
***************************************************************/

template <class T> 
bool greaterThan(const T& item1, const T& item2)
{
    return (item1 > item2); 
}

#endif 
