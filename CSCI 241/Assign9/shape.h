/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#ifndef SHAPE_H
#define SHAPE_H

#include <string>

using std::string; 

class Shape 
{
    private: 
        string color; 
    
    public: 
        Shape(const string&); 
        virtual ~Shape();
        virtual void print() const; 
        virtual double get_area() const; 
}; 

#endif