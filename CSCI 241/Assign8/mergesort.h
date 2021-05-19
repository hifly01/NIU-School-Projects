/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 8, Part 3
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   4/26/18
 
   FUNCTION:   This program builds and sorts lists using the quick
               sort algorithm.
*********************************************************************/  

#ifndef MERGESORT_H
#define MERGESORT_H

#include <iostream>
#include <stdexcept>
#include <fstream>

using std::cout;
using std::endl; 
using std::setw; 
using std::ifstream; 
using std::vector; 

template <class T>
void mergeSort(vector<T>&, bool (*compare)(const T&, const T&));

template <class T>
void mergeSort(vector<T>&, int, int, bool (*compare)(const T&, const T&));

template <class T>
void merge(vector<T>&, int, int, int, bool (*compare)(const T&, const T&));

/***************************************************************
Function: mergeSort
Use: This is a recursive mergeSort method. 
Parameters: vector<T>&, bool 
Returns: None
Notes: 
***************************************************************/

template <class T>
void mergeSort(vector<T>& set, bool (*compare)(const T&, const T&))
{
    mergeSort(set, 0, set.size()-1, compare);
}

/***************************************************************
Function: mergeSort
Use: This method calls the overarching methods that are used for
the process of mergeSort. It keeps running recursively until it
has reached the end of the list. 
Parameters: vector<T>&, int, int bool
Returns: None
Notes: 
***************************************************************/

template <class T>
void mergeSort(vector<T>& set, int low, int high, bool (*compare)(const T&, const T&))
{
   int mid;
   
   if (low < high)
      {
      mid = (low + high) / 2;
      
      // Divide and conquer
      
      mergeSort(set, low, mid, compare);
      mergeSort(set, mid+1, high, compare);
      
      // Combine
      merge(set, low, mid, high, compare);
      }
}

/***************************************************************
Function: merge
Use: This method is responsible for the swapping of two values  
from two lists depending on if they are greater than or less 
than one another. 
Parameters: vector<T>&, int, int, bool  
Returns: None
Notes: 
***************************************************************/

template <class T>
void merge(vector<T>& set, int low, int mid, int high, bool (*compare)(const T&, const T&))
{
    // Create temporary array to hold merged subarrays
   T* temp = new T[high - low + 1];

   int i = low;      // Subscript for start of left sorted subvector
   int j = mid+1;    // Subscript for start of right sorted subvector
   int k = 0;        // Subscript for start of merged vector

   // While not at the end of either subarray
   while (i <= mid && j <= high)
      {
      if (compare(set[j], set[i]))
         {
         temp[k++] = set[j++];
         //++j;
         //++k;
         }
      else
         {
         temp[k++] = set[i++];
         //++i;
         //++k;
         }
      }

   // Copy over any remaining elements of left subarray
   while (i <= mid)
      {
      temp[k++] = set[i++];
      //++i;
      //++k;
      }

   // Copy over any remaining elements of right subarray
   while (j <= high)
      {
      temp[k++] = set[j++];
      //++j;
      //++k;
      }

   // Copy merged elements back into original array
   for (i = 0, j = low; j <= high; i++, j++)
      set[j] = temp[i];

   // Delete temporary array
   delete[] temp;
}
#endif
