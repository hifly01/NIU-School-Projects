/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 9
   PROGRAMMER: Theresa Li, Charles Alms 
   LOGON ID:   Z1814730, Z1797837
   DUE DATE:   5/2/18
 
   FUNCTION:   This program uses polymorphism with different shapes 
*********************************************************************/  
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>

#include "shape.h"
#include "circle.h"
#include "rectangle.h"
#include "triangle.h"

using std::cout;
using std::endl;
using std::fixed;
using std::setprecision;
using std::vector;
using std::string;

int main()
{
    cout << fixed << setprecision(2); 
    
    vector<Shape *> Shapes(6); 
    
    Shapes[0] = new Circle("green", 10); 
    Shapes[1] = new Rectangle("red", 8, 6); 
    Shapes[2] = new Triangle("yellow", 8, 4); 
    Shapes[3] = new Triangle("black", 4, 10);
    Shapes[4] = new Circle("orange", 5);
    Shapes[5] = new Rectangle("blue", 3, 7); 
    
    cout << "Printing all shapes..." << endl; 
    
    for (unsigned int i = 0; i < Shapes.size(); ++i)
    {
        Shapes[i]->print(); 
    }
    
    cout << endl; 
    cout << "Printing only triangles..." << endl; 
    
    for (unsigned int i = 0; i < Shapes.size(); ++i)
    {
        if (dynamic_cast<Triangle*>(Shapes[i]) != nullptr)
        {
            Shapes[i]->print(); 
        }
    }
    
    for (unsigned int i = 0; i < Shapes.size(); ++i)
    {
        delete Shapes[i]; 
    }
    
    cout << endl; 
    
    return 0; 
}