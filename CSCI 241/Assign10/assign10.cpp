//***************************************************************
// PROGRAM:    CSCI 241 Assignment 10
// PROGRAMMER: Theresa Li
// LOGON ID:   Z1814730
// DUE DATE:   5/3/18
//
// FUNCTION:   This program tests the functionality of the List
//             class.
//***************************************************************

#include <iostream>
#include <string>
#include <utility>
#include "List.h"

using std::cout;
using std::endl;
using std::make_pair;
using std::pair;
using std::string;

int main()
    {
    //********//
    // PART 1 //
    //********//

    cout << "===== PART 1 =====\n\n";

    cout << "*** Testing default constructor ***\n\n";

    List<int> l1;

    cout << "*** Testing size(), operator<<(), and empty() with empty list ***\n\n";

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l1 is " << ((l1.empty()) ? "empty\n\n" : "not empty\n\n");

    cout << "*** Testing push_back() into empty list ***\n\n";

    l1.push_back(40);

    cout << "*** Testing size(), operator<<(), and empty() with non-empty list ***\n\n";
    
    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l1 is " << ((l1.empty()) ? "empty\n\n" : "not empty\n\n");

    cout << "*** Testing push_back() into non-empty list ***\n\n";

    l1.push_back(50);
    l1.push_back(60);

    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    List<char> l2;

    cout << "*** Testing push_front() into empty list ***\n\n";

    l2.push_front('c');

    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    cout << "*** Testing push_front() into non-empty list ***\n\n";

    l2.push_front('b');
    l2.push_front('a');

    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    
    cout << "*** Testing push_front() and push_back() ***\n\n";

    l1.push_front(30);
    l1.push_front(20);
    l1.push_front(10);

    l2.push_back('d');
    l2.push_back('e');
    l2.push_back('f');

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    cout << "*** Testing read version of front() and back() ***\n\n";

    cout << "l1 front: " << l1.front() << endl;
    cout << "l1 back: " << l1.back() << endl << endl;                       
    
    cout << "*** Testing write version of front() and back() ***\n\n";

    l1.front() = 5;
    l1.back() = 65;

    cout << "l1 front: " << l1.front() << endl;
    cout << "l1 back: " << l1.back() << endl << endl;

    cout << "*** Testing pop_back() ***\n\n";                                 

    l2.pop_back();
    l2.pop_back();

    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    cout << "*** Testing pop_front() ***\n\n";                                 

    l2.pop_front();
    l2.pop_front();

    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    cout << "*** Testing pop to empty ***\n\n";                                        

    l2.pop_back();
    l2.pop_front();

    cout << "l2 (size " << l2.size() << "): " << l2 << endl << endl;

    cout << "*** Testing copy constructor ***\n\n";                                 

    List<int> l3 = l1;

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing for shallow copy ***\n\n";
    
    l1.front() = 10;
    l1.back() = 60;

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing copy assignment operator ***\n\n";
    
    l1.push_back(70);
    l1.push_back(80);

    l3 = l1;

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing for shallow copy ***\n\n";
    
    l1.push_back(90);
    l3.pop_front();

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing self-assignment ***\n\n";

    l1 = l1;

    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing chained assignment ***\n\n";

    List<int> l4;

    l4 = l3 = l1;

    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "l3 (size " << l3.size() << "): " << l3 << endl;
    cout << "l4 (size " << l4.size() << "): " << l4 << endl << endl;

    cout << "*** Testing equality operator ***\n\n";                                

    cout << "l1 and l4 are " << ((l1 == l4) ? "equal\n" : "not equal\n");
    
    l3.back() = -8;                                                                                      
    
    cout << "l1 and l3 are " << ((l1 == l3) ? "equal\n" : "not equal\n");

    l4.pop_front();

    cout << "l1 and l4 are " << ((l1 == l4) ? "equal\n\n" : "not equal\n\n");

    cout << "*** Testing less than operator ***\n\n";

    cout << "l1 is " << ((l1 < l4) ? "less than" : "not less than") << " l4\n";                   
    cout << "l4 is " << ((l4 < l1) ? "less than" : "not less than") << " l1\n";
    cout << "l1 is " << ((l1 < l1) ? "less than" : "not less than") << " l1\n";
    cout << "l1 is " << ((l1 < l3) ? "less than" : "not less than") << " l3\n";
    cout << "l3 is " << ((l3 < l1) ? "less than" : "not less than") << " l1\n";

    l3.pop_back();

    cout << "l1 is " << ((l1 < l3) ? "less than" : "not less than") << " l3\n";                             
    cout << "l3 is " << ((l3 < l1) ? "less than" : "not less than") << " l1\n\n";                            
    cout << "*** Testing clear() ***\n\n";

    l1.clear();

    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing for const correctness ***\n\n";

    List<int>& r4 = l4;

    cout << "l4 (size " << r4.size() << "): " << r4 << endl;
    cout << "l4 is " << ((r4.empty()) ? "empty\n" : "not empty\n");                                     
    cout << "l4 and l1 are " << ((r4 == l1) ? "equal\n" : "not equal\n");
    cout << "l4 is " << ((r4 < l3) ? "less than" : "not less than") << " l3\n";
    cout << "l4 is " << ((r4 < l1) ? "less than" : "not less than") << " l1\n";
    cout << "l1 is " << ((l1 < r4) ? "less than" : "not less than") << " l4\n\n";                           
    
    //********//
    // PART 2 //
    //********//

    cout << "===== PART 2 =====\n\n";

    for (int i = 15; i < 90; i += 10)
        l1.push_back(i);

    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing default constructor and begin() ***\n\n";
    
    Iterator<int> itr1;

    itr1 = l1.begin();

    cout << "*** Testing operator*() ***\n\n";
    
    cout << "First list element: " << *itr1 << endl << endl;

    cout << "*** Testing prefix form of operator++() ***\n\n";

    cout << "Second list element: " << *(++itr1) << endl << endl;

    cout << "*** Testing postfix form of operator++() ***\n\n";

    cout << "Second list element: " << *(itr1++) << endl;
    cout << "Third list element: " << *itr1 << endl << endl;

    cout << "*** Testing prefix form of operator--() ***\n\n";

    cout << "Second list element: " << *(--itr1) << endl << endl;

    cout << "*** Testing postfix form of operator--() ***\n\n";

    cout << "Second list element: " << *(itr1--) << endl;
    cout << "First list element: " << *itr1 << endl << endl;

    cout << "*** Testing alternate constructor ***\n\n";
 
    Iterator<int> itr2(nullptr);

    cout << "*** Testing operator==() ***\n\n";
    cout << "itr1 and l1.begin() are " << ((itr1 == l1.begin()) ? "equal\n" : "not equal\n");                       //This is supposed to be equal but it is not
    cout << "itr1 and l1.end() are " << ((itr1 == l1.end()) ? "equal\n" : "not equal\n");                           
    cout << "itr2 and l1.end() are " << ((itr2 == l1.end()) ? "equal\n" : "not equal\n");                           //This is supposed to be equal but it is not 
    cout << "itr1 and itr2() are " << ((itr1 == itr2) ? "equal\n\n" : "not equal\n\n");
    
    cout << "*** Testing operator!=() ***\n\n";
    cout << "itr1 and l1.begin() are " << ((itr1 != l1.begin()) ? "not equal\n" : "equal\n");                       //This is supposed to be equal but it is not
    cout << "itr1 and l1.end() are " << ((itr1 != l1.end()) ? "not equal\n" : "equal\n");
    cout << "itr2 and l1.end() are " << ((itr2 != l1.end()) ? "not equal\n" : "equal\n");                           //This is supposed to be equal but it is not 
    cout << "itr1 and itr2() are " << ((itr1 != itr2) ? "not equal\n\n" : "equal\n\n");
    
    cout << "*** Testing begin(), end(), and operator->() ***\n\n";

    List<pair<string, double> > l5;

    l5.push_back(make_pair("Joe Murphy", 3.75));
    l5.push_back(make_pair("Sam Melton", 3.87));
    l5.push_back(make_pair("Carl Miller", 2.63));
    l5.push_back(make_pair("Mike Piazza", 2.59));
    l5.push_back(make_pair("John Deberge", 3.52));

    for (Iterator<pair<string, double> > itr = l5.begin(); itr != l5.end(); ++itr)                    //This is the only test that doesn't work, -> is not the problem
        cout << itr->first << ", " << itr->second << endl;

    cout << endl; 

    //********//
    // PART 3 //
    //********//

   /* cout << "===== PART 3 =====\n\n";

    l1.clear();
    
    cout << "*** Testing insert() at beginning of empty list ***\n\n";

    itr1 = l1.insert(l1.begin(), 28);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing insert() at beginning of non-empty list ***\n\n";

    l1.insert(itr1, 17);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing insert() at end of list ***\n\n";

    itr1 = l1.insert(l1.end(), 47);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing insert() in middle of non-empty list ***\n\n";

    l1.insert(itr1, 35);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    l1.push_back(53);
    l1.push_back(61);

    cout << "*** Testing erase() at front of list ***\n\n";

    itr1 = l1.begin();
    itr1 = l1.erase(itr1);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "Iterator now points to: " << *itr1<< endl << endl;

    cout << "*** Testing erase() in middle of list ***\n\n";

    ++itr1; ++itr1;

    itr1 = l1.erase(itr1);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl;
    cout << "Iterator now points to: " << *itr1<< endl << endl;

    cout << "*** Testing erase() at back of list ***\n\n";
  
    ++itr1;

    l1.erase(itr1);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing remove(10) on empty list ***\n\n";

    l1.clear();
    l1.remove(10);
    cout << "l1 (size " << l1.size() << "): " << l1 << endl << endl;

    cout << "*** Testing remove(10) on non-empty list ***\n\n";

    int array1[] = {10, 62, 25, 10, 32, 58, 10, 16, 10, 43, 10};

    for (int i = 0; i < 11; ++i)
        l1.push_back(array1[i]);

    cout << "Before - l1 (size " << l1.size() << "): " << l1 << endl;
    l1.remove(10);   
    cout << "After  - l1 (size " << l1.size() << "): " << l1 << endl << endl; */

    //**************//
    // EXTRA CREDIT //
    //**************//

    /*cout << "===== EXTRA CREDIT =====\n\n";

    cout << "*** Testing splice() of empty list into non-empty list ***\n\n";

    l3.clear();

    cout << "Before:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;

    l1.splice(l1.begin(), l3);
 
    cout << "After:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing splice() of non-empty list into empty list ***\n\n";

    cout << "Before:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;

    l3.splice(l3.begin(), l1);
 
    cout << "After:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing splice() at end of list ***\n\n";

    int array2[] = {11, 13, 15};

    for (int i = 0; i < 3; ++i)
        l1.push_back(array2[i]);

    cout << "Before:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;

    l3.splice(l3.end(), l1);
 
    cout << "After:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing splice() at beginning of list ***\n\n";

    int array3[] = {12, 14, 16};

    for (int i = 0; i < 3; ++i)
        l1.push_back(array3[i]);

    cout << "Before:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;

    l3.splice(l3.begin(), l1);
 
    cout << "After:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl << endl;

    cout << "*** Testing splice() before 5th element in list ***\n\n";

    int array4[] = {-1, -2, -3};

    for (int i = 0; i < 3; ++i)
        l1.push_back(array4[i]);

    itr1 = l3.begin();
    for (int i = 0; i < 4; ++i)
        ++itr1;

    cout << "Before:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;

    l3.splice(itr1, l1);
 
    cout << "After:\n"
         << "  l1 (size " << l1.size() << "): " << l1 << endl
         << "  l3 (size " << l3.size() << "): " << l3 << endl;*/

    return 0;
    }
