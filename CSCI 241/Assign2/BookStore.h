#ifndef BOOKSTORE_H
#define BOOKSTORE_H
 
#include <string>
#include "Book.h"

using std::string;

/***************************************************************
BookStore
Uses: Declares items and methods in the class, used for BookStore.cpp
***************************************************************/ 

class BookStore 
{    
    Book items[30]; 
    int totalBooks = 0;
    
public:
 
 BookStore();  
 BookStore(const string&);
 
 void sortByISBN();  
 int searchForISBN(const char*);
 void processOrders(const string&); 
 
 void print(); 
  
};

#endif
