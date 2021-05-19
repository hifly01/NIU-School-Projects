//***************************************************************
// PROGRAM:    CSCI 241 Assignment 10
// PROGRAMMER: Theresa Li
// LOGON ID:   Z1814730
// DUE DATE:   5/3/18
//
// FUNCTION:   This program tests the functionality of the List
//             class.
//***************************************************************

#ifndef List_h
#define List_h

#include <iostream>
#include <stdexcept> 

using std::out_of_range;
using std::underflow_error; 

using std::cout; //delete later
using std::endl; //delete later

template <class T>
struct Node;

template <class T>
struct Node 
{
    T nodeArray; 
    Node<T>* prev; 
    Node<T>* next; 
    
    Node(const T& = T(), Node<T>* next = nullptr, Node<T>* prev = nullptr); 
}; 

template <class T>
Node<T> :: Node(const T& newNodeArray, Node<T>* newNext, Node<T>* newPrev)
{
    nodeArray = newNodeArray; 
    prev = newPrev; 
    next = newNext; 
}

template <class T> 
struct Iterator; 

template <class T> 
bool operator==(const Iterator<T>&, const Iterator<T>&);

template <class T> 
bool operator!=(const Iterator<T>&, const Iterator<T>&); 

template <class T>
std::ostream& operator<<(std::ostream&, const Iterator<T>&);

template <class T> 
struct Iterator
{
    friend bool operator== <>(const Iterator<T>&, const Iterator<T>&); 
    friend bool operator!= <>(const Iterator<T>&, const Iterator<T>&); 
    friend std::ostream& operator<< <>(std::ostream&, const Iterator<T>&);
    
    private:
        Node<T>* ptr; 
        
    public: 
        Iterator(); 
        Iterator(Node<T>*); 
        Iterator<T>& operator++();
        Iterator<T> operator++(int); 
        Iterator<T>& operator--(); 
        Iterator<T> operator--(int);
        T& operator*() const; 
        T* operator->() const; 
}; 

template <class T> 
Iterator<T> :: Iterator()
{
    ptr = nullptr; 
}

template <class T> 
Iterator<T> :: Iterator(Node<T>* ptr)
{
    this->ptr = ptr; 
}

template <class T>
std::ostream& operator<< (std::ostream& lhs, const Iterator<T>& rhs) 
{
    Iterator<T>* ptr2; 
    
    lhs << ptr2->ptr; 
        
    return lhs;    
}

template <class T> 
Iterator<T>& Iterator<T> :: operator++() 
{
    ptr = ptr->next; 
    return *this; 
}

template <class T> 
Iterator<T> Iterator<T> :: operator++(int unused)
{
    Iterator<T> temp = *this;
    ptr = ptr->next;
    return temp; 
}

template <class T> 
Iterator<T>& Iterator<T> :: operator--()
{
    ptr = ptr->prev; 
    return *this; 
}

template <class T> 
Iterator<T> Iterator<T> :: operator--(int unused)
{
    Iterator<T> temp = *this; 
    ptr = ptr->prev; 
    return temp; 
}

template <class T> 
T& Iterator<T> :: operator*() const
{
    return ptr->nodeArray; 
}

template <class T> 
T* Iterator<T> :: operator->() const 
{
    return &ptr->nodeArray; 
}

template <class T> 
bool operator==(const Iterator<T>& rhs, const Iterator<T>& lhs)
{
    bool answer = false; 
    
    if (&rhs == &lhs)
    {
        answer = true; 
    }

    return answer; 
}

template <class T> 
bool operator!=(const Iterator<T>& rhs, const Iterator<T>& lhs)
{
    bool answer = false; 
    
    if (&rhs != &lhs)
    {
        answer = true; 
    }
    
    return answer; 
}
 
template <class T> 
class List; 

template <class T>
std::ostream& operator<<(std::ostream&, const List<T>&);

template <class T> 
bool operator==(const List<T>&, const List<T>&);

template <class T>
bool operator< (const List<T>&, const List<T>&); 

template <class T>
class List 
{
    friend std::ostream& operator<< <>(std::ostream&, const List<T>&);
    friend bool operator== <>(const List<T>&, const List<T>&);
    friend bool operator< <>(const List<T>&, const List<T>&);
    
    public: 
    Node<T>* lfront;  
    Node<T>* lback;
    size_t listSize; 
    
    List();   
    ~List(); 
    List(const List<T>&);
    List<T>& operator=(const List<T>&);
    void clear(); 
    size_t size() const; 
    bool empty() const; 
    const T& front() const; 
    T& front(); 
    const T& back() const; 
    T& back(); 
    void push_front(const T&);
    void push_back(const T&); 
    void pop_front();
    void pop_back(); 
    
    Iterator<T> begin() const; 
    Iterator<T> end() const; 
    
    //Iterator<T> insert(Iterator<T>, const T&);
    //Iterator<T> erase(Iterator<T>);
    //List<T> remove(const T&); 
};

template <class T>
List<T> :: List()
{
    lfront = nullptr; 
    lback = nullptr; 
    listSize = 0; 
}

template <class T>
List<T> :: ~List()
{
    lfront = nullptr; 
    lback = nullptr; 
    listSize = 0; 
}

template <class T>
List<T> :: List(const List<T>& other)
{
   lfront = nullptr; 
   lback = nullptr; 
   listSize = 0; 
   
   Node<T>* ptr; 
   
   for (ptr = other.lfront; ptr != nullptr; ptr = ptr->next)
   {
       push_back(ptr->nodeArray); 
   }
}

template <class T>
List<T>& List<T> :: operator= (const List<T>& other)                            
{
    if (this != &other)
    {
        clear(); 
      
        Node<T>* ptr; 

        for (ptr = other.lfront; ptr != nullptr; ptr = ptr->next)
        {
           push_back(ptr->nodeArray); 
        }
    }
    return *this; 
}

template <class T>
void List<T> :: clear()
{
    lfront = nullptr; 
    lback = nullptr; 
    listSize = 0; 
}

template <class T>
size_t List<T> :: size() const
{
    return listSize; 
}

template <class T>
bool List<T> :: empty() const
{
    if (listSize == 0)
    {
        return true; 
    }
    
    return false; 
}

template <class T>
const T& List<T> :: front() const 
{
    if (empty())
    {
        throw underflow_error("Queue underflow on front()");
    }
    
    return lfront->nodeArray; 
}

template <class T>
T& List<T> :: front()
{
    if (empty())
    {
        throw underflow_error("Queue underflow on front()");
    }
    
    return lfront->nodeArray; 
}

template <class T>
const T& List<T> :: back() const
{
    if (empty())
    {
        throw underflow_error("Queue underflow on back()");
    }
    
    return lback->nodeArray; 
}

template <class T>
T& List<T> :: back()
{
    if (empty())
    {
        throw underflow_error("Queue underflow on back()");
    }
    
    return lback->nodeArray; 
}

template <class T>
void List<T> :: push_front(const T& val)
{
  Node<T>* newNode = new Node<T>(val);
  if (listSize != 0)
  {
      Node<T>* newNode = new Node<T>(val);
      newNode->next = lfront; 
      lfront->prev = newNode; 
      lfront = newNode; 
  }
  else
  {
      newNode->next = lfront; 
      lback = newNode; 
      lfront = newNode; 
  }
  
  listSize++; 
}

template <class T>
void List<T> :: push_back(const T& val)
{
  Node<T>* newNode = new Node<T>(val);
  if (listSize != 0)
  {
      Node<T>* newNode = new Node<T>(val);
      newNode->prev = lback; 
      lback->next = newNode; 
      lback = newNode; 
  }
  else
  {
      newNode->prev = lback; 
      lfront = newNode; 
      lback = newNode; 
  }
  
  listSize++;   
}

template <class T>
void List<T> :: pop_front()
{
   if (empty())
   {
       throw underflow_error("queue underflow on pop()");
   } 
   
   if (listSize > 1)
   {
       Node<T>* delNode = lfront; 
       lfront = delNode->next; 
       lfront->prev = nullptr; 
       delete delNode; 
   }
   else
   {
      Node<T>* delNode = lfront; 
      lfront = delNode->next; 
      lback = nullptr; 
      delete delNode; 
   }
   
   listSize--; 
}

template <class T>
void List<T> :: pop_back()
{
   if (empty())
   {
       throw underflow_error("queue underflow on pop()");
   } 
   
   if (listSize > 1)
   {
       Node<T>* delNode = lback; 
       lback = delNode->prev; 
       lback->next = nullptr; 
       delete delNode; 
   }
   else
   {
      Node<T>* delNode = lback; 
      lback = delNode->prev; 
      lfront = nullptr; 
      delete delNode; 
   }
   
   listSize--; 
}

template <class T>
bool operator== (const List<T>& lhs, const List<T>& rhs) 
{
    Node<T>* ptr1; 
    Node<T>* ptr2 = rhs.lfront; 
    bool answer = false; 
    
    if (lhs.listSize != rhs.listSize)
    {
        answer = false; 
    }
    else 
    {
        for (ptr1 = lhs.lfront; ptr1 != nullptr && ptr2 != nullptr; ptr1 = ptr1->next)
        {
            if(ptr1->nodeArray == ptr2->nodeArray)
            {
                answer = true; 
            }
            
            ptr2 = ptr2->next;
        }
    }
    
    return answer; 
}

template <class T>
bool operator< (const List<T>& lhs, const List<T>& rhs) 
{
    Node<T>* ptr1 = lhs.lfront;
    Node<T>* ptr2 = rhs.lfront; 
    
    if (ptr1 == nullptr)
    {
        return true; 
    }
    
    for (ptr1 = lhs.lfront; ptr1 != nullptr && ptr2 != nullptr; ptr1 = ptr1->next)
    {        
        if ((ptr1->nodeArray) < (ptr2->nodeArray))
        {
            return true; 
        }
        else if ((ptr1->nodeArray) > (ptr2->nodeArray))
        {
           return false; 
        }
        else
        {
            ptr2 = ptr2->next;
        }
    }
    
    if (ptr1 == nullptr && ptr2 != nullptr)
    {
        return true; 
    }
    else
    {
        return false;
    }
}

template <class T>
std::ostream& operator<< (std::ostream& lhs, const List<T>& rhs) 
{
    Node<T>* ptr; 
    
    for (ptr = rhs.lfront; ptr != nullptr; ptr = ptr->next)
        lhs << ptr->nodeArray << ' ';
        
    return lhs;    
}

template <class T> 
Iterator<T> List<T>::begin() const
{
    Iterator<T> front = lfront;  
    
    return front; 
}

template <class T>
Iterator<T> List<T>::end() const
{
    Iterator<T> back = nullptr; 
    return back; 
}

/*template <class T> 
Iterator<T> List<T> :: insert (Iterator<T> position, const T& val)
{
    if (position.ptr == nullptr)
    {
        push_back(val);
        Iterator<T> newback -> lback; 
        
        return newback; 
    }
    else if (position.ptr->prev == nullptr)
    {
        push_front(val); 
        Iterator<T> newfront -> lfront; 
        
        return newfront; 
    }
    else
    {
        Node<T> newNode = val; 
        newNode->prev = position.ptr->prev; 
        newNode->next = position.ptr; 
        next->newNode; 
        prev->newNode; 
        
        listSize++; 
        
        return newNode; 
    }
}

template <class T> 
Iterator<T> List<T> :: erase(Iterator<T> position)
{
    
}

template <class T> 
void List<T> :: remove(const T& val)
{
    
}*/

#endif