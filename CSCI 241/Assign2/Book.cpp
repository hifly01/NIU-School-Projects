#include <iostream>
#include <iomanip>
#include <cstring>
#include "Book.h"

using std::cout;
using std::endl;
using std::fixed;
using std::setprecision;
using std::string; 
using std::setw;
using std::strcpy; 
using std::right; 
using std::left; 

/***************************************************************
Function: Book
Use: This is the default constructor that sets ISBN, Title, Price, 
 * and Quantity to their default values of 0 or null string. 
Parameters: None
Returns: None
Notes: isbn and title are cstrings so has to use the string copy
***************************************************************/ 
Book :: Book()
{
    setPrice(0); 
    setQuantity(0); 
}

/***************************************************************
Function: Book
Use: This function sets the variables isbn, title, price, and quantity
 * to the new values. 
Parameters: char nISBN [11], char nTitle [41], double price, int quantity
Returns: None
Notes: 
***************************************************************/ 
Book :: Book(char nISBN [11], char nTitle [41], double price, int quantity)
{
    strcpy(isbn, nISBN);
    strcpy(title, nTitle); 
    setPrice(price);
    setQuantity(quantity);
}

/***************************************************************
Function: getISBN
Use: It returns the ISBN number 
Parameters: None
Returns: None
Notes: 
***************************************************************/ 
const char* Book :: getISBN() const
{
    return isbn; 
}

/***************************************************************
Function: getTitle
Use: It returns the title
Parameters: None
Returns: None
Notes: 
***************************************************************/ 
const char* Book :: getTitle()
{
    return title; 
}

/***************************************************************
Function: getPrice
Use: It returns the price 
Parameters: char nISBN [11], char nTitle [41], double price, int quantity
Returns: None
Notes: 
***************************************************************/ 

double Book :: getPrice()
{
    return price; 
}

/***************************************************************
Function: getQuantity
Use: It returns the quantity of books 
Parameters: None
Returns: None
Notes: 
***************************************************************/ 

int Book :: getQuantity()
{
    return quantity; 
}

/***************************************************************
Function: setPrice
Use: This makes sure that if price is negative, it will be set to 0. 
 * Otherwise, the new price will be added into price. 
Parameters: double nPrice
Returns: None
Notes: 
***************************************************************/ 

void Book :: setPrice(double nPrice)
{
    if (nPrice >= 0)
    {
        price = nPrice; 
    }
    else
    {
        price = 0; 
    }
}

/***************************************************************
Function: Book
Use: This function sets the variables isbn, title, price, and quantity
 * to the new values. 
Parameters: char nISBN [11], char nTitle [41], double price, int quantity
Returns: None
Notes: 
***************************************************************/ 

void Book :: setQuantity(int nQuantity)
{
    if (nQuantity >= 0)
    {
        quantity = nQuantity; 
    }
    else
    {
        quantity = 0; 
    }
} 

/***************************************************************
Function: fulfillOrder
Use: This function checks the number of books that it already has 
and makes sure there is enough books that can be given to the order.  
Parameters: int books
Returns: None
Notes: 
***************************************************************/ 
int Book :: fulfillOrder(int books)
{
    int numShipped; 
    if (books <= 0)
    {
        numShipped=0; 
    }
    if (books <= quantity)
    {
        numShipped=books;
        quantity=quantity-books;
    }
    if (books >= quantity)
    {
        quantity=0; 
    }
    return numShipped;
}

/***************************************************************
Function: Print
Use: This function prints the ISBN, title, price, and quantity 
Parameters: None
Returns: None
Notes: 
***************************************************************/ 
void Book :: print()
{
    cout << left << setw(14) << isbn; 
    cout << left << setw(44) << title; 
    cout << left << setw(10) << price; 
    cout << left << quantity;  
}
