/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#include <iostream> 
#include <string>
#include "triangle.h"

using std::cout; 
using std::endl; 
using std::string; 

Triangle :: Triangle(string color, int newheight, int newbase) : Shape(color)
{
    height = newheight; 
    base = newbase; 
}

void Triangle :: print() const
{
    Shape :: print(); 
    cout << " triangle, height " << height << ", base " << base << ", area " << (0.5)*base*height << endl;
}

double Triangle :: get_area() const
{
    return (0.5)*base*height; 
}