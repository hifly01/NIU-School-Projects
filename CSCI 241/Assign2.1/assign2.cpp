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

int main()
{
	BookStore bookstore1("bookdata");
	bookstore1.print();
	bookstore1.processOrders("orders.txt");
	bookstore1.print();
}
