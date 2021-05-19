#ifndef VERIFIER_H
#define VERIFIER_H

/***************************************************************
Verifier.h
Use: Creation of the class Verifier to have variables and methods. 
***************************************************************/

class Verifier
{
    private: 
        int gridArray[9][9]; 
    
    public: 
        Verifier();
        
        void readGrid(const char*); 
        void printGrid(); 
        bool verifySolution();
};

#endif 