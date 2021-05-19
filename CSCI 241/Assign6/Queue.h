/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 6
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   4/10/18
    
   FUNCTION:   This program tests the functionality of the Queue
               template class.
*********************************************************************/
#ifndef QUEUE_H
#define QUEUE_H

#include <iostream>
#include <stdexcept>

using std::out_of_range;
using std::underflow_error; 
using std::cout; 
using std::endl; 

template <class T>
class Queue;

template <class T>
std::ostream& operator<<(std::ostream&, const Queue<T>&);

template <class T>
class Queue
{
    friend std::ostream& operator<< <>(std::ostream&, const Queue<T>&);
    
    public: 
        T* queueArray; 
        size_t queueSize; 
        size_t queueCap; 
        int queueFrontSub; 
        int queueBackSub;
        
        Queue(); 
        ~Queue();
        Queue(const Queue<T>&);
        Queue<T>& operator=(const Queue<T>&); 
        Queue<T>& operator<<(const Queue<T>&); 
        
        void clear(); 
        size_t size() const; 
        size_t capacity(); 
        bool empty() const; 
        T& front() const;
        T& back() const; 
        void push(const T&);
        void pop(); 
        void reserve(size_t); 
};

/***************************************************************
Function: Queue()
Use: This is the default constructor for Queue() and sets 
queueSize, queueCap, and queueFrontSub to 0. Then queueArray is
a pointer that needs ot be nullpointer, and queueBackSub is 
the capacity minus 1. 
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T>                  
Queue<T> :: Queue()
{
    queueSize = 0;
    queueCap = 0; 
    queueArray = nullptr;
    queueFrontSub = 0;
    queueBackSub = queueCap - 1;
}

/***************************************************************
Function: ~Queue()
Use: This is the deconstructor, and it deletes the pointer for 
queueArray when the program is done running. 
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T> 
Queue<T> :: ~Queue()
{
    delete[] queueArray; 
}

/***************************************************************
Function: Queue()
Use: This is the copy constructor, and it is in charge of 
copying over new values into the queue. 
Parameters: const Queue<T>& 
Returns: None
Notes: 
***************************************************************/
template <class T> 
Queue<T> :: Queue(const Queue<T>& other)
{   
   queueCap = other.queueCap;
   queueSize = other.queueSize;
   queueArray = new int[queueCap]; 
   
   for (size_t i = 0; i < queueCap - 1; ++i) 
      queueArray[i] = other.queueArray[i];
      
   queueFrontSub = other.queueFrontSub;
   queueBackSub = other.queueBackSub;
}

/***************************************************************
Function: operator=
Use: This is the copying assignment operator that is overloaded
to work for the template. It copies everything over if the 
value of the array is different from the previous one.   
Parameters: const Queue<T>& other 
Returns: Queue<T>&
Notes: 
***************************************************************/
template <class T> 
Queue<T>& Queue<T> :: operator=(const Queue<T>& other)  
{
    if (this != &other)
    {
        queueCap = other.queueCap;
        queueSize = other.queueSize;
        queueArray = new int[queueCap];

        for (size_t i = 0; i < queueCap; ++i) 
          queueArray[i] = other.queueArray[i];
          
        queueFrontSub = other.queueFrontSub;
        queueBackSub = other.queueBackSub;
    }
    
    return *this; 
}

/***************************************************************
Function: operator<<
Use: This is output stream operator that is overloaded to work 
with the queue object. It displays values from teh queue.  
Parameters: ostream&, const Queue<T>& 
Returns: ostream&
Notes: 
***************************************************************/
template <class T>                                                  
std::ostream& operator<<(std::ostream& lhs, const Queue<T>& rhs)
{
   size_t current, i; 
   
   for (current = rhs.queueFrontSub, i = 0; i < rhs.queueSize; ++i)
   {
       lhs << rhs.queueArray[current] << ' ';
       
       current = (current + 1) % rhs.queueCap;
   }

   return lhs;
}

/***************************************************************
Function: clear()
Use: This method clears the queueSize, queueFrontSub and queueBackSub
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T> 
void Queue<T> :: clear()
{
    queueSize = 0; 
    queueFrontSub = 0;
    queueBackSub = queueCap - 1; 
}

/***************************************************************
Function: size() const
Use: This method returns the queueSize
Parameters: None
Returns: size_t
Notes: 
***************************************************************/
template <class T> 
size_t Queue<T> :: size() const                                  
{
    return queueSize; 
}

/***************************************************************
Function: capacity()
Use: This method returns the queue capacity 
Parameters: None
Returns: size_t
Notes: 
***************************************************************/
template <class T>
size_t Queue<T> :: capacity()                             
{
    return queueCap;
}

/***************************************************************
Function: empty()
Use: This method check if the queue is empty or doesn't have 
any values
Parameters: None
Returns: bool 
Notes: 
***************************************************************/
template <class T>
bool Queue<T> :: empty() const                                    
{
    if (queueSize == 0)
    {
        return true; 
    }
    else
    {
        return false; 
    }
}

/***************************************************************
Function: front() const
Use: This method returns the first value in the queue array. 
Parameters: None
Returns: T&
Notes: 
***************************************************************/
template <class T>
T& Queue<T> :: front() const
{
    if (queueSize == 0)
    {
        throw underflow_error("queue underflow on front()");
    }
    
    return queueArray[queueFrontSub];
}

/***************************************************************
Function: back() const
Use: This method returns the last value in the queue array. 
Parameters: None
Returns: T&
Notes: 
***************************************************************/
template <class T> 
T& Queue<T> :: back() const
{
    if (queueSize == 0)
    {
        throw underflow_error("queue underflow on back()");
    }
    
    return queueArray[queueBackSub];
}

/***************************************************************
Function: push
Use: This method pushes a new item into the queue, and if the 
capacity of the queue is full, then it will call reserve to 
expand the queue capacity. 
Parameters: const T& 
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: push(const T& val)                                 
{
   if (queueSize == queueCap)
   {
      if (queueCap == 0)
         reserve(1);
      else
        reserve(queueCap * 2);
   }
    
    queueBackSub = (queueBackSub + 1) % queueCap; 
    queueArray[queueBackSub] = val; 
    ++queueSize;
}

/***************************************************************
Function: pop
Use: This method pops off an old item from the queue, and if the 
array is empty, an error will occur. Then the queueSize will 
decrease by 1.  
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: pop()                                              
{
   if (queueSize == 0)
   {
        throw underflow_error("queue underflow on pop()");
   }
    
    queueFrontSub = (queueFrontSub + 1) % queueCap;
    --queueSize;
}

/***************************************************************
Function: reverse
Use: This method adds in a new capacity to the queue. 
Parameters: size_t
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: reserve(size_t newCap)          
{
   if (newCap <= queueSize)
      return;

   T* tempArray = new T[newCap];
   int current = queueFrontSub;
   
   for (size_t i = 0; i < queueCap; ++i)
   {
    tempArray[i] = queueArray[current];
    current = (current + 1) % queueCap;
   }
   queueCap = newCap;
   delete[] queueArray;
   queueFrontSub = 0; 
   queueBackSub = queueSize - 1; 
   queueArray = tempArray;
}

#endif