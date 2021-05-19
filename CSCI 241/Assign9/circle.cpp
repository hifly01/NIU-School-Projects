/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#include <iostream>
#include <string> 
#include "circle.h"

using std::cout; 
using std::endl; 
using std::string; 

Circle :: Circle(string color, int newRadius) : Shape(color)
{
    radius = newRadius; 
}

void Circle :: print() const
{
    Shape :: print(); 
    cout << " circle, radius " << radius << ", area " << 3.14*radius*radius << endl;
}

double Circle :: get_area() const
{
    return 2*3.14*radius; 
}