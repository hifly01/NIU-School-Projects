#ifndef VECTOR3_H
#define VECTOR3_H

#include <string> 

using std::ostream; 
using std::string; 

/***************************************************************
Vector3.h
Use: Creation of the class Vecotr3 to have variables and methods. 
***************************************************************/

class Vector3
{
    friend ostream& operator<< (ostream&, const Vector3&); 
    friend string operator+ (const Vector3&, const Vector3&);
    friend string operator- (const Vector3&, const Vector3&);
    friend double operator* (const Vector3&, const Vector3&);
    friend bool operator== (const Vector3&, const Vector3&);

    private:
        double x;
        double y; 
        double z;
        double coord[3] = {x, y, z}; 

    public:
        Vector3(double = 0.0, double = 0.0, double = 0.0);
	double &operator[] (int);
        double operator[] (int) const; 
};

#endif
