#ifndef BOOK_H
#define BOOK_H

/***************************************************************
Book.h
Use: This is the header file for Book.cpp that decalres variables and methods.
 * A description of each method can be found in Book.cpp.
***************************************************************/

class Book
{
	char isbn [11]{};
	char title [41]{};
	double price;
	int quantity;

	public:
		Book();
		Book(char*, char*, double, int);

		const char* getISBN() const;
		const char* getTitle();
		double getPrice();
		int getQuantity();
		void setPrice(double);
		void setQuantity(int);
		int fulfillOrder(int);
		void print();
};

#endif
