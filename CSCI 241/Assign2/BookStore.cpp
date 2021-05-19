#include <iostream>
#include <iomanip>
#include <cstring>
#include <fstream> 
#include "BookStore.h"

using std::ifstream;
using std::cerr; 
using std::cout; 
using std::endl;
using std::string; 
using std::ios; 
using std::setw; 

/***************************************************************
Function: BookStore
Use: This function sets the variables equal to a default value. 
 * In this case, it is 0. 
Parameters: None
Returns: None
Notes: 
***************************************************************/ 
BookStore :: BookStore()
{
    totalBooks = 0; 
}

/***************************************************************
Function: BookStore
Use: This function works with ifstream(input files) and opening the 
 * input file, reading it in and closing it. 
Returns: None
Notes: 
***************************************************************/ 
BookStore :: BookStore(const string& input)
{
    ifstream inFile(input, ios::in|ios::binary); 
    
    if (!inFile)
      {
        cerr << "Error - unable to open input file\n";
        exit(1);
      }
    
    inFile.read((char*) this, sizeof(BookStore));
      
    inFile.close();
}
 
/***************************************************************
Function: Print
Use: This prints the books held in the array 
Parameters: None
Returns: None
Notes: 
***************************************************************/ 
void BookStore :: print()
{
   cout << "Book Inventory Listing" << endl; 
   cout << endl; 
   cout << "ISBN" << setw(14) << "Title" << setw(44) << "Price" << setw(10) << "Qty" << setw(6) << endl; 
   
   int i;
   for (i = 0; i < totalBooks; i++)
      {
          items[i].print();
          cout << endl;
      }
}

/***************************************************************
Function: sortByISBN
Use: This sorts the ISBN by descending order 
Parameters: None
Returns: None
Notes: 
***************************************************************/
void BookStore :: sortByISBN()
{
   int i, j;
   Book bucket;

   for (i = 1; i < totalBooks; i++)
      {
          bucket = items[i];

          for (j = i; (j > 0) && (strcmp(items[j-1].getISBN(), bucket.getISBN()) > 0); j--)  
             items[j] = items[j-1];

          items[j] = bucket;
      }
} 

/***************************************************************
Function: searchForISBN
Use: This figures out if an isbn that the user is looking for 
is in the ISBN list 
Parameters: char isbn
Returns: None
Notes: 
***************************************************************/
int BookStore :: searchForISBN(const char* isbn)  
{
   int low = 0;
   int high = totalBooks - 1;
   int mid;

   while (low <= high)
      {
          mid = (low + high) / 2;

          if (strcmp(isbn, items[mid].getISBN()) == 0)
	    { 
             return mid;
	    }
          if (strcmp(isbn, items[mid].getISBN()) < 0)
	    {  
            high = mid - 1;
	    }
          else
	    {
	      low = mid + 1;
	    }
      }

    return mid; 
   //return -1;
} 

/***************************************************************
Function: processOrders
Use: This takes the orders from the list and compares of 
 * whether you have them or not 
Parameters: const string& object
Returns: None
Notes: 
***************************************************************/
void BookStore :: processOrders(const string& object)
{
   char orderNumber[7];
   char isbn[11];
   int orderQuantity;
   int numShipped; 

  ifstream inFile(object);

    if (!inFile)
      {
          cerr << "Error - unable to open input file\n";
          exit(1);
      }
  
    inFile >> orderNumber;
    while (inFile)
      {  
          inFile >> isbn; 
          inFile >> orderQuantity; 
          
          int index = searchForISBN(isbn);
          if (index == -1)
                 cout << "There is an error" << endl; 
          else
             {
                 cout << "Order Listing" << endl; 
                 
                 int i; 
                 for (i = 0; i < totalBooks; i++)
                 {
                     numShipped = items[i].fulfillOrder(orderQuantity);
                     cout << "Order #" << orderNumber << ": ISBN " << items[i].getISBN() << ", " << orderQuantity << " of " << numShipped << " shipped, order total $" << items[i].getPrice() << endl;
                 }
                 
                 inFile >> orderNumber;
                
                }
                 
             }
    inFile.close(); 
}
   
      
