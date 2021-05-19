/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#include <iostream> 
#include <string> 
#include <iostream> 
#include "shape.h"

using std::cout; 
using std::endl; 
using std::string; 

Shape :: Shape(const string& newColor)
{
    color = newColor; 
}

Shape :: ~Shape()
{
}

void Shape :: print() const
{
    cout << color; 
}

double Shape :: get_area() const
{
    return 0; 
}