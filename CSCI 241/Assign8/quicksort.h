/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 8, Part 3
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   4/26/18
 
   FUNCTION:   This program builds and sorts lists using the quick
               sort algorithm.
*********************************************************************/  

#ifndef QUICKSORT_H
#define QUICKSORT_H

#include <iostream>
#include <stdexcept>
#include <fstream>

using std::cout;
using std::endl; 
using std::setw; 
using std::ifstream; 
using std::vector; 

template <class T>
void quickSort(vector<T>&, bool (*compare)(const T&, const T&));

template <class T>
void quickSort(vector<T>&, int, int, bool (*compare)(const T&, const T&));

template <class T> 
int partition(vector<T>&, int, int, bool (*compare)(const T&, const T&));

/***************************************************************
Function: quickSort
Use: This is a recursive quickSort method. 
Parameters: vector<T>&, bool 
Returns: None
Notes: 
***************************************************************/

template <class T>
void quickSort(vector<T>& set, bool (*compare)(const T&, const T&))
{
  quickSort(set, 0, set.size()-1, compare);
}

/***************************************************************
Function: quickSort
Use: This method calls the overarching methods that are used for
the process of quickSort. It keeps running recursively until it
has reached the end of the list. 
Parameters: vector<T>&, int, int bool
Returns: None
Notes: 
***************************************************************/

template <class T> 
void quickSort(vector<T>& set, int start, int end, bool (*compare)(const T&, const T&))
{
    int pivotPoint;

    if (start < end)
      {
      pivotPoint = partition(set, start, end, compare);     // Get the pivot point
      quickSort(set, start, pivotPoint - 1, compare);       // Sort first sublist
      quickSort(set, pivotPoint + 1, end, compare);         // Sort second sublist
      }
}

/***************************************************************
Function: partition
Use: This method is responsible for the swapping of two values  
in the list depending on if they are greater than or less than 
one another. 
Parameters: vector<T>&, int, int, bool  
Returns: None
Notes: 
***************************************************************/

template <class T>
int partition(vector<T>& set, int start, int end, bool (*compare)(const T&, const T&))
{
   int pivotIndex, mid;
   T pivotValue, temp; 

   mid = (start + end) / 2;

   temp = set[start];
   set[start] = set[mid];
   set[mid] = temp;

   pivotIndex = start;
   pivotValue = set[start];

   for (int scan = start + 1; scan <= end; ++scan)
      {
      if (compare(set[scan], pivotValue))
         {
         pivotIndex++;

         temp = set[pivotIndex];
         set[pivotIndex] = set[scan];
         set[scan] = temp;
         }
      }

    temp = set[start];
    set[start] = set[pivotIndex];
    set[pivotIndex] = temp;

    return pivotIndex;
}

#endif
