#include <iostream>
#include <iomanip>
#include <fstream> 
#include "Verifier.h"

using std::ifstream;
using std::cerr; 
using std::cout; 
using std::endl;
using std::string; 
using std::ios; 
using std::setw; 

/***************************************************************
Function: Verifier
Use: This is the default constructor that sets gridArray equals 
 * to the default value of 0. 
Parameters: None
Returns: None
Notes: 
***************************************************************/

Verifier :: Verifier()
{
    int gridArray[9][9] = {{0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0}}; 
}

/***************************************************************
Function: readGrid
Use: This function reads in the grid values from a text value. 
Parameters: const char* file
Returns: None
Notes: infile stuff
***************************************************************/

void Verifier :: readGrid(const char* file)
{
    ifstream inFile(file);

    if (!inFile)
    {
        cerr << "Error - unable to open input file\n";
        exit(1);
    }
    
    while (inFile)
    {  
        for (int row = 0; row < 9; row++) 
        {
            for (int col = 0; col < 9; col++)
            {
                inFile >> gridArray[row][col];
            }
        } 
    } 

    inFile.close(); 
}

/***************************************************************
Function: printGrid
Use: This function prints the values of the grid 
Parameters: None
Returns: None
Notes:the extra credit words
***************************************************************/

void Verifier :: printGrid()
{
    int counterCol = 0;
	int counterRow = 0;

	cout << "-------------------------" << endl;
	for(int i = 0; i < 9; i++)
	{
		cout << "| ";
		for(int j = 0; j < 9; j++)
		{
			cout << gridArray[i][j] << " ";
			counterCol += 1;

			if(counterCol % 3 == 0)
			{
				cout << "| ";
			}
		}
		cout << endl;
		counterRow += 1;

        if(counterRow % 3 == 0)
		{
			cout << "-------------------------" << endl;
		}
	}
}

/***************************************************************
Function: verifySolution
Use: This verifies whether the input grid values are a valid Sudoku solution
Parameters: None
Returns: None
Notes: 
***************************************************************/

bool Verifier :: verifySolution()
{
    int anotherRow = 0; 
    int anotherCol = 0; 

    //this works for rows
    for (int row = 0; row < 9; row++) 
    {
        if (row > 0)
        {
            anotherRow++;
        }

        for (int col = 0; col < 8; col++)
        {
            if (gridArray[anotherRow][anotherCol] == gridArray[row][col+1])
            {
                return false; 
            }
        }
        anotherCol = 0; 
    }

    anotherRow = 0; 
    anotherCol = 0; 

    //this works for columns
    for (int col = 0; col < 9; col++) 
    {
        if (col > 0)
        {
            anotherCol++;
        }

        for (int row = 0; row < 8; row++)
        {
	         if (gridArray[anotherRow][anotherCol] == gridArray[row+1][col])
        	 {
            	    	return false; 
            	 }
        }
        anotherRow = 0; 
    }

for(int gridRow=0; gridRow<9; gridRow+=3)
{
	for(int gridCol=0; gridCol<9; gridCol+=3)
	{
		for(int r=0; r<3; r++)
		{
			for(int c=0; c<3; c++)
			{
				if(gridArray[gridRow][gridCol]==gridArray[r][c+1])
				{
					return false;
				}
				else
				{
					gridRow++;
					gridCol++;
					r++;
					c++;
				}
			}
		}
	}
}
return true;
}
