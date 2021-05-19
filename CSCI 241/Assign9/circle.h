#ifndef CIRCLE_H
#define CIRCLE_H

#include <string>
#include "shape.h"

using std::string; 

class Circle : public Shape
{
    private: 
        int radius; 
        
    public: 
        Circle(string, int); 
        void print() const; 
        double get_area() const; 
}; 

#endif