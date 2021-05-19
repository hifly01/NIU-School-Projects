/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#include <iostream>
#include <string>
#include "rectangle.h"

using std::cout; 
using std::endl;
using std::string; 

Rectangle :: Rectangle(string color, int newHeight, int newWidth) : Shape(color)
{
    height = newHeight; 
    width = newWidth; 
}

void Rectangle :: print() const
{
    Shape :: print(); 
    cout << " rectangle, height " << height << ", width " << width << ", area " << height*width << endl;
}

double Rectangle :: get_area() const
{
    return height*width; 
}