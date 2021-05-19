/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 7
   PROGRAMMER: Theresa Li, Charles Alm
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   4/19/18

   FUNCTION:   This program tests the functionality of the Queue
               template class.
*********************************************************************/ 

#ifndef QUEUE_H
#define QUEUE_H

#include <iostream>
#include <stdexcept>

using std::out_of_range;
using std::underflow_error; 

template <class T>
struct Node
{
    T nodeArray; 
    Node<T>* next; 
    
    Node(const T& = T(), Node<T>* next = nullptr);
};

template <class T> 
Node<T> :: Node(const T& newNodeArray, Node<T>* newNext)
{
    nodeArray = newNodeArray; 
    next = newNext; 
}

template <class T>
class Queue;

template <class T> 
std::ostream& operator<<(std::ostream&, const Queue<T>&);

template <class T>
class Queue
{
    friend std::ostream& operator<< <>(std::ostream&, const Queue<T>&);
    
public:
    Node<T>* qFront;
    Node<T>* qBack;
    size_t qSize; 
 
    Queue();   
    ~Queue(); 
    Queue(const Queue<T>&);
    Queue<T>& operator=(const Queue<T>&);
    void clear(); 
    size_t size() const; 
    bool empty() const; 
    T& front() const; 
    T& back() const; 
    void push(const T&);
    void pop();
};

/***************************************************************
Function: Queue()
Use: This is the default constructor for Queue() and sets 
qFront and qBack to nullpointer and qSize to 0. 
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T>
Queue<T> :: Queue()
{
    qFront = nullptr; 
    qBack = nullptr; 
    qSize = 0; 
}

/***************************************************************
Function: ~Queue()
Use: This is the deconstructor, and it calls clear.
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T> 
Queue<T> :: ~Queue()
{
    clear(); 
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
   qFront = nullptr; 
   qBack = nullptr; 
   qSize = 0; 
   
   Node<T>* ptr; 
   
   for (ptr = other.qFront; ptr != nullptr; ptr = ptr->next)
   {
       push(ptr->nodeArray); 
   }
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
Queue<T>& Queue<T>::operator=(const Queue<T>& other)
{
    if (this != &other)
    {
        clear();
        Node<T>* ptr; 

        for (ptr = other.qFront; ptr != nullptr; ptr = ptr->next)
        {
           push(ptr->nodeArray); 
        }
    }
    return *this; 
}

/***************************************************************
Function: operator<<
Use: This is output stream operator that is overloaded to work 
with the queue object. It displays values from the queue.  
Parameters: ostream&, const Queue<T>& 
Returns: ostream&
Notes: 
***************************************************************/
template <class T>
std::ostream& operator<<(std::ostream& lhs, const Queue<T>& rhs)
{
    Node<T>* ptr; 
    
    for (ptr = rhs.qFront; ptr != nullptr; ptr = ptr->next)
        lhs << ptr->nodeArray << ' ';
        
    return lhs; 
}

/***************************************************************
Function: clear()
Use: This method clears the qFront and qBack to nullptr and qSize
is set equal to 0 
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: clear()     
{
    qFront = nullptr; 
    qBack = nullptr; 
    qSize = 0; 
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
    return qSize;
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
    if (qSize == 0)
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
    if (empty())
    {
        throw underflow_error("Queue underflow on front()");
    }
    
    return qFront->nodeArray; 
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
    if (empty())
    {
        throw underflow_error("Queue underflow on back()");
    }
    
    return qBack->nodeArray; 
}

/***************************************************************
Function: push
Use: This method pushes a new item into the queue
Parameters: const T& 
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: push(const T& val)                                 
{
  Node<T>* newNode= new Node<T>(val);
  if (qSize == 0)
  {
      qFront = newNode; 
  }
  else
  {
      qBack->next = newNode; 
  }
  
  qBack = newNode; 
  qSize++; 
}

/***************************************************************
Function: pop
Use: This method pops off an old item from the queue
Parameters: None
Returns: None
Notes: 
***************************************************************/
template <class T>
void Queue<T> :: pop()                                              
{
   if (empty())
   {
       throw underflow_error("queue underflow on pop()");
   }
   
   Node<T>* delNode = qFront; 
   qFront = qFront->next; 
   
   if (qFront == nullptr)
   {
       qBack = nullptr;
   }
   
   delete delNode; 
   qSize--; 
}
#endif