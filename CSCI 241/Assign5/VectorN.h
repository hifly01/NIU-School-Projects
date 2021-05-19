/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 5
   PROGRAMMER: Theresa Li, Charles Alms
   LOGON ID:   z1814730, z1797837
   DUE DATE:   3/27/18

   FUNCTION:   This program tests the functionality of the VectorN
               class.
*********************************************************************/  

#ifndef VECTORN_H
#define VECTORN_H

#include <iostream>
#include <string>

using std::ostream; 
using std::string; 

/***************************************************************
VectorN.h
Use: Creation of the class VecotrN to have variables and methods.
***************************************************************/

class VectorN
{
    friend ostream& operator<< (ostream&, const VectorN&); 
    friend string operator+ (const VectorN&, const VectorN&);
    friend string operator- (const VectorN&, const VectorN&);
    friend double operator* (const VectorN&, const VectorN&);
    friend string operator* (const VectorN&, double);
    friend string operator* (double, const VectorN&);
    friend bool operator== (const VectorN&, const VectorN&);
    
    private: 
        double* vectorArrayPointer; 
        size_t vectorCapacity; 
    
    public: 
        VectorN();
        VectorN(const double [], size_t); 
        VectorN(const VectorN&);
        ~VectorN(); 
        VectorN& operator=(const VectorN&);
        void clear(); 
        size_t size()const; 
        double operator[] (int) const;
        double &operator[] (int);
        double at(unsigned int) const; 
        double& at(unsigned int); 
}; 

#endif