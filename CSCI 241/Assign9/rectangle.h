/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#ifndef RECTANGLE_H
#define RECTANGLE_H

#include <string>
#include "shape.h"

class Rectangle : public Shape
{
    private:
        int height; 
        int width; 
    
    public: 
        Rectangle(string, int, int);
        void print() const; 
        double get_area() const; 
};

#endif