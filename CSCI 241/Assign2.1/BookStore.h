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
	private:

		Book items[30];
		int totalBooks = 0;

		void sortByISBN();
		int searchForISBN(const char*) const;

	public:

		BookStore();
		BookStore(const string&);

		void processOrders(const string&);
		void print();

};

#endif
