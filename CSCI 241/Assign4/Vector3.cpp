/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 4
   PROGRAMMER: Theresa Li, Charles Alms
   LOGON ID:   z1814730, z1797837
   DUE DATE:   3/8/18

   FUNCTION:   This program tests the functionality of the Vector3
               class.
*********************************************************************/

#include <iostream>
#include <iomanip> 
#include <string> 
#include <sstream>
#include "Vector3.h"

using std::ostream; 
using std::string; 
using std::cout; 
using std::endl; 
using std::ostringstream;
 
/***************************************************************
Function: Vector3 
Use: This is the constructor for the class Vector3. It sets new 
values to the vector coordinates of x, y, z 
Parameters: double x, double y, double z
Returns: None 
Notes: 
***************************************************************/

Vector3 :: Vector3(double newX, double newY, double newZ)
{
   x = newX;
   y = newY; 
   z = newZ; 
}

/***************************************************************
Function: operator<<
Use: This overloads the << operator and makes it display the 
vector's right x, y and z
Parameters: ostream&, const Vector3&
Returns: ostream&
Notes: 
***************************************************************/

ostream& operator<< (ostream& lhs, const Vector3& rhs) 
{
    lhs << "(" << rhs.x << ", " << rhs.y << ", " << rhs.z << ")"; 

    return lhs; 
}

/***************************************************************
Function: operator+
Use: This overloads the + operator and makes it add the x's, y's, 
and z's on the right and left side of the operator
Parameters: const Vector3&, const Vector3&
Returns: double
Notes: 
***************************************************************/

string operator+ (const Vector3& rhs, const Vector3& lhs)
{
    double addedX = rhs.x + lhs.x; 
    double addedY = rhs.y + lhs.y; 
    double addedZ = rhs.z + lhs.z; 

    double addedCoord[3] = {addedX, addedY, addedZ}; 

    ostringstream output1, output2, output3; 
    output1 << addedCoord[0];
    output2 << addedCoord[1];
    output3 << addedCoord[2]; 

    string addOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ") "; 

    return addOutput;
}

/***************************************************************
Function: operator-
Use: This overloads the - operator and makes it subtract the x's, y's, 
and z's on the right and left side of the operator
Parameters: const Vector3&, const Vector3&
Returns: double
Notes: 
***************************************************************/

string operator- (const Vector3& rhs, const Vector3& lhs) 
{
    double subX = rhs.x - lhs.x; 
    double subY = rhs.y - lhs.y; 
    double subZ = rhs.z - lhs.z; 

    double subCoord[3] = {subX, subY, subZ}; 

    ostringstream output4, output5, output6; 
    output4 << subCoord[0];
    output5 << subCoord[1];
    output6 << subCoord[2]; 

    string subOutput = "(" + output4.str() + ", " + output5.str() + ", " + output6.str() + ") "; 

    return subOutput;
}

/***************************************************************
Function: operator*
Use: This overloads the * operator and makes it multiple the x's, y's, 
and z's on the right and left side of the operator. Then it adds up
all the multiplied values to get the scalar multiplication answer. 
Parameters: const Vector3&, const Vector3&
Returns: double
Notes: 
***************************************************************/

double operator* (const Vector3& lhs, const Vector3& rhs)  
{
    double resultX = 0, resultY = 0, resultZ = 0; 

    if (lhs.x != 0 && rhs.x != 0 && lhs.y != 0 && rhs.y != 0 && lhs.z != 0 && rhs.z != 0)
    {
        resultX = lhs.x * rhs.x; 
        resultY = lhs.y * rhs.y; 
        resultZ = lhs.z * rhs.z; 
    }
    else if (lhs.x != 0 && (lhs.y == 0 || lhs.z == 0))
    {
        resultX = lhs.x * rhs.x; 
        cout << "resultX1 " << resultX << endl; 
        resultY = lhs.x * rhs.y; 
        cout << "resultY1 " << resultY << endl;  
        resultZ = lhs.x * rhs.z; 
        cout << "resultZ1 " << resultZ << endl; 
    }
    else if (rhs.x != 0 && (rhs.y == 0 || rhs.z == 0))
    {
        resultX = rhs.x * lhs.x; 
	cout << "resultX " << resultX << endl; 
        resultY = rhs.x * lhs.y;
        cout << "resultY " << resultY << endl;  
        resultZ = rhs.x * lhs.z; 
        cout << "resultZ " << resultZ << endl; 
    }

   double resultTote = resultX + resultY + resultZ;     //this is not adding correctly for the second vector multiplication test, k*v4

   return resultTote; 
} 

/***************************************************************
Function: operator[]
Use: This overloads the [] operator and takes the index value
that is stored between the two brackets and returns the value
at that array index.
Parameters: int
Returns: double
Notes: this one is the get
***************************************************************/

double &Vector3::operator[] (int index)
{
    if (index == 0)
        return x;
    else if (index == 1)
        return y;
    else if (index == 2)
        return z;
}

double Vector3::operator[] (int index) const
{
    if (index == 0)
        return x; 
    else if (index == 1)
        return y; 
    else if (index == 2)
        return z; 
	//this works for the most part except for 
    // v6[0] = -2.4; 
  // v6[1] = -1.3;
  // v6[2] = 17.5;
}

/***************************************************************
Function: operator==
Use: This overloads the == operator and compares the x, y, z
on the left and right side of the operator to see if they are
the same or not. 
Parameters: const Vector3&, const Vector3&
Returns: bool
Notes: 
***************************************************************/

bool operator== (const Vector3& lhs, const Vector3& rhs) 
{
    bool answer = false; 
    if ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z))
    {
        answer = true; 
    }
    return answer; 
}

