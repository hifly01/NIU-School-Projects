/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 5
   PROGRAMMER: Theresa Li, Charles Alms
   LOGON ID:   z1814730, z1797837
   DUE DATE:   3/27/18

   FUNCTION:   This program tests the functionality of the VectorN
               class.
*********************************************************************/  

#include <iostream>
#include <iomanip> 
#include <string> 
#include <sstream>
#include <stdexcept>
#include "VectorN.h"

using std::ostream; 
using std::string; 
using std::cout; 
using std::endl; 
using std::ostringstream;
using std::out_of_range; 

/***************************************************************
Function: VectorN
Use: This is the default constructor for VectorN() and sets the 
vectorCapacity to 0 and the vectoryArrayPointer to a nullptr. 
Parameters: None
Returns: None
Notes: 
***************************************************************/

VectorN::VectorN()
{
    vectorCapacity = 0; 
    vectorArrayPointer = nullptr; 
}

/***************************************************************
Function: operator<<
Use: This overloads the << operator and makes it display the 
vector's values
Parameters: ostream&, const Vector3&
Returns: ostream&
Notes: 
***************************************************************/

ostream& operator<< (ostream& lhs, const VectorN& rhs) 
{
    if (rhs.vectorCapacity == 0)
    {
        lhs << "()";
    }
    else 
    {
        unsigned int i; 
        lhs << "("; 
        for (i = 0; i < rhs.vectorCapacity-1; ++i)
        {
            lhs << rhs.vectorArrayPointer[i] << ", "; 
        }
        
        if (i < (unsigned int) rhs.vectorCapacity)
        {
            lhs << rhs.vectorArrayPointer[i];
        }
        
        lhs << ")";
    
        return lhs; 
    }
}

/***************************************************************
Function: VectorN
Use: This is a constructor for VectorN(). If there are valid 
values to copy in. The array values will change. 
Parameters: double [], size_t
Returns: None
Notes: 
***************************************************************/

VectorN::VectorN(const double values[], size_t n)
{
    vectorArrayPointer = new double[n]; 
    
    vectorCapacity = n; 
    
    for (size_t i = 0; i < n; ++i)
    {
        vectorArrayPointer[i] = values[i]; 
    }
}

/***************************************************************
Function: VectorN
Use: This is the another version of the VectorN constructor, in 
case there are info that needs to be passed in but aren't 
specified directly. 
Parameters: const VectorN&
Returns: None
Notes: 
***************************************************************/

VectorN::VectorN(const VectorN& other) 
{
    vectorCapacity = other.vectorCapacity; 
    
    if (vectorCapacity == 0)
    {
        vectorArrayPointer = nullptr; 
    }
    else
    {
        vectorArrayPointer = new double[vectorCapacity]; 
    }
    
    for (size_t i = 0; i < vectorCapacity; ++i)
    {
        vectorArrayPointer[i] = other.vectorArrayPointer[i]; 
    }
} 

/***************************************************************
Function: ~VectorN
Use: This is the VectorN deconstructor. It clears out old data 
from other VectorN objects not in use. 
Parameters: None
Returns: None
Notes: 
***************************************************************/

VectorN::~VectorN()
{
    clear();
}

/***************************************************************
Function: clear
Use: This is called by the destructor and sets all the values of
the object back to default values and deletes the array of 
objects. 
Parameters: None
Returns: None
Notes: 
***************************************************************/

void VectorN::clear()
{
    delete[] vectorArrayPointer; 
    vectorCapacity = 0;
    vectorArrayPointer = nullptr; 
}

/***************************************************************
Function: size
Use: This is function just returns the array size. 
Parameters: None
Returns: size_t
Notes: 
***************************************************************/

size_t VectorN::size() const
{
    return vectorCapacity; 
} 

/***************************************************************
Function: operator[]
Use: This overloads the [] operator and takes the index value
that is stored between the two brackets and returns the value
at that array index. This is the get method because it is constant.
Parameters: int
Returns: double
Notes: 
***************************************************************/

double VectorN::operator[] (int index) const
{
    if (index == 0)
        return vectorArrayPointer[0]; 
    else if (index == 1)
        return vectorArrayPointer[1]; 
    else if (index == 2)
        return vectorArrayPointer[2]; 
    else if (index == 3)
        return vectorArrayPointer[3]; 
}

/***************************************************************
Function: operator[]
Use: This overloads the [] operator and takes the index value
that is stored between the two brackets and returns the value
at that array index. This is the set method because it isn't 
constant.
Parameters: int
Returns: double
Notes: 
***************************************************************/

double &VectorN::operator[] (int index) 
{
    if (index == 0)
        return vectorArrayPointer[0]; 
    else if (index == 1)
        return vectorArrayPointer[1]; 
    else if (index == 2)
        return vectorArrayPointer[2]; 
    else if (index == 3)
        return vectorArrayPointer[3]; 
}

/***************************************************************
Function: operator=
Use: This overloads the = operator and replaces the values stored
in the vector object. 
Parameters: const VectorN&
Returns: VectorN&
Notes: 
***************************************************************/

VectorN& VectorN::operator=(const VectorN& other)
{
    if (this != &other)
    {
        delete[] vectorArrayPointer; 
        
        vectorCapacity = other.vectorCapacity; 
        
        if (vectorCapacity == 0)
        {
            vectorArrayPointer = nullptr;
        }
        else
        {
            vectorArrayPointer = new double[vectorCapacity]; 
        }
        for (size_t i = 0; i < vectorCapacity; ++i)
        {
            vectorArrayPointer[i] = other.vectorArrayPointer[i]; 
        }
    }
    return *this; 
}

/***************************************************************
Function: operator+
Use: This overloads the + operator and makes it add two vectors
together 
Parameters: const VectorN&, const VectorN&
Returns: string
Notes: 
***************************************************************/

string operator+ (const VectorN& rhs, const VectorN& lhs) 
{            
    double added1 = rhs.vectorArrayPointer[0] + lhs.vectorArrayPointer[0]; 
    double added2 = rhs.vectorArrayPointer[1] + lhs.vectorArrayPointer[1]; 
    double added3 = rhs.vectorArrayPointer[2] + lhs.vectorArrayPointer[2]; 
    double added4 = rhs.vectorArrayPointer[3] + lhs.vectorArrayPointer[3]; 
     
    double addedCoord[4] = {added1, added2, added3, added4}; 
    
    ostringstream output1, output2, output3, output4; 
    output1 << addedCoord[0];
    output2 << addedCoord[1];
    output3 << addedCoord[2]; 
    output4 << addedCoord[3];
    
    string addOutput; 
    
    if (rhs.vectorCapacity == 4 && lhs.vectorCapacity == 4)
    {
        addOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ", " + output4.str() + ") ";
    } 
    else
    {
        addOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ") ";
    }
     
    return addOutput;
}

/***************************************************************
Function: operator-
Use: This overloads the - operator and makes it subtract two
vectors together. 
Parameters: const VectorN&, const VectorN&
Returns: string
Notes: 
***************************************************************/

string operator- (const VectorN& rhs, const VectorN& lhs)                                         
{            
    double sub1 = rhs.vectorArrayPointer[0] - lhs.vectorArrayPointer[0]; 
    double sub2 = rhs.vectorArrayPointer[1] - lhs.vectorArrayPointer[1]; 
    double sub3 = rhs.vectorArrayPointer[2] - lhs.vectorArrayPointer[2]; 
    double sub4 = rhs.vectorArrayPointer[3] - lhs.vectorArrayPointer[3]; 
     
    double subCoord[4] = {sub1, sub2, sub3, sub4}; 
    
    ostringstream output1, output2, output3, output4; 
    output1 << subCoord[0];
    output2 << subCoord[1];
    output3 << subCoord[2]; 
    output4 << subCoord[3];
    
    string subOutput; 
    
    if (rhs.vectorCapacity == 4 && lhs.vectorCapacity == 4)
    {
        subOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ", " + output4.str() + ") ";
    } 
    else
    {
        subOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ") ";
    }
     
    return subOutput;
}

/***************************************************************
Function: operator*
Use: This overloads the * operator and makes it multiply the 
vectors for vector multiplication. 
Parameters: const VectorN&, const VectorN&
Returns: double
Notes: 
***************************************************************/

double operator* (const VectorN& lhs, const VectorN& rhs)
{    
    double resultX = 0, resultY = 0, resultZ = 0, resultA = 0, totalResult = 0; 
    
    resultX = lhs.vectorArrayPointer[0] * rhs.vectorArrayPointer[0]; 
    resultY = lhs.vectorArrayPointer[1] * rhs.vectorArrayPointer[1]; 
    resultZ = lhs.vectorArrayPointer[2] * rhs.vectorArrayPointer[2]; 
    resultA = lhs.vectorArrayPointer[3] * rhs.vectorArrayPointer[3];
   
    totalResult = resultX + resultY + resultZ + resultA; 
    
    return totalResult;
}

/***************************************************************
Function: operator*
Use: This overloads the * operator and makes it multiply the 
scalar values. 
Parameters: double, const VectorN&
Returns: string
Notes: 
***************************************************************/

string operator* (double num, const VectorN& rhs)
{    
    double resultX = 0, resultY = 0, resultZ = 0, resultA = 0; 

    resultX = rhs.vectorArrayPointer[0] * num;
    resultY = rhs.vectorArrayPointer[1] * num;
    resultZ = rhs.vectorArrayPointer[2] * num;
    resultA = rhs.vectorArrayPointer[3] * num;
   
    ostringstream output1, output2, output3, output4; 
    output1 << resultX; 
    output2 << resultY;
    output3 << resultZ; 
    output4 << resultA; 
    
    string totalOutput; 
    
    if (rhs.vectorCapacity == 4)
    {
        totalOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ", " + output4.str() + ")"; 
    }
    else
    {
        totalOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ")";
    }
    return totalOutput;
}

/***************************************************************
Function: operator*
Use: This overloads the * operator and makes it multiply the 
scalar values. 
Parameters: const VectorN&, num
Returns: string
Notes: 
***************************************************************/

string operator* (const VectorN& lhs, double num)
{    
    double resultX = 0, resultY = 0, resultZ = 0, resultA = 0; 

    resultX = lhs.vectorArrayPointer[0] * num;
    resultY = lhs.vectorArrayPointer[1] * num;
    resultZ = lhs.vectorArrayPointer[2] * num;
    resultA = lhs.vectorArrayPointer[3] * num;
   
    ostringstream output1, output2, output3, output4; 
    output1 << resultX; 
    output2 << resultY;
    output3 << resultZ; 
    output4 << resultA; 
    
    string totalOutput; 
    
    if (lhs.vectorCapacity == 4)
    {
        totalOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ", " + output4.str() + ")"; 
    }
    else
    {
        totalOutput = "(" + output1.str() + ", " + output2.str() + ", " + output3.str() + ")";
    }
    
    return totalOutput;
} 

/***************************************************************
Function: operator==
Use: This overloads the == operator and compares the two vectors 
to see if they are equal or not. 
Parameters: const Vector3&, const Vector3&
Returns: bool
Notes: 
***************************************************************/

bool operator== (const VectorN& lhs, const VectorN& rhs) 
{
    bool answer = false; 
    if ((lhs.vectorArrayPointer[0] == rhs.vectorArrayPointer[0]) && (lhs.vectorArrayPointer[1]  == rhs.vectorArrayPointer[1]) && (lhs.vectorArrayPointer[2]  == rhs.vectorArrayPointer[2]) 
    && (lhs.vectorArrayPointer[3]  == rhs.vectorArrayPointer[3]) && (lhs.vectorArrayPointer[4]  == rhs.vectorArrayPointer[4]) && lhs.vectorCapacity == rhs.vectorCapacity)
    {
        answer = true; 
    }
    return answer; 
}

/***************************************************************
Function: at
Use: This reads the inputted subscript to see if it's valid, 
and if it's not, an exception will be thrown. Otherwise it 
will be returned. 
Parameters: const unsigned int 
Returns: double
Notes: 
***************************************************************/
 
double VectorN::at(unsigned int sub) const
{
    if (sub < 0 || sub >= vectorCapacity)
    {
        throw out_of_range("subscript out of range");
    }
    else
    {
       return vectorArrayPointer[sub];
    }
}

/***************************************************************
Function: at
Use: This writes in the inputted subscript to see if it's valid, 
and if it's not, an exception will be thrown. Otherwise it 
will be returned. 
Parameters: unsigned int s
Returns: double&
Notes: 
***************************************************************/

double& VectorN::at(unsigned int sub)
{
    if (sub < 0 || sub >= vectorCapacity) 
    {
        throw out_of_range("subscript out of range");
    }
    else
    {
        return vectorArrayPointer[sub]; 
    }
}