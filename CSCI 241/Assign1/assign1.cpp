/*********************************************************************
   PROGRAM:    CSCI 241 Assignment 1
   PROGRAMMER: your name
   LOGON ID:   your z-ID
   DUE DATE:   2/1/2018
   FUNCTION:   This program tests functions for manipulating C strings.
*********************************************************************/

#include <iostream>
#include <cstring>
#include <cctype>

using std::cin;
using std::cout;
using std::endl;

// Add your function prototypes here

bool equals(const char* str1, const char* str2);

bool equalsIgnoreCase(const char* str1,const char* str2);

int indexOf(const char* str, char ch);

int lastIndexOf(const char* str, char ch);

bool startsWith(const char* str, const char* prefix);

bool endsWith(const char* str, const char* suffix);

int main()
   {
   int index;

   // Tests 1a - 1d: Test the equals() function
   cout << "Test 1a: ";
   if (equals("catapult", "catapult"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 1b: ";
   if (!equals("catapult", "catamaran"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 1c: ";
   if (!equals("cat", "catamaran"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 1d: ";
   if (!equals("catapult", "cat"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << endl;

   // Tests 2a - 2d: Test the equalsIgnoreCase() function
   cout << "Test 2a: ";
   if (equalsIgnoreCase("catapult", "CATAPULT"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 2b: ";
   if (!equalsIgnoreCase("catapult", "Catamaran"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 2c: ";
   if (!equalsIgnoreCase("Cat", "Catamaran"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 2d: ";
   if (!equalsIgnoreCase("Catapult", "Cat"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << endl;

   // Tests 3a - 3d: Test the indexOf() function
   cout << "Test 3a: ";
   index = indexOf("adamant", 'a');
   if (index == 0)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 0\n";

   cout << "Test 3b: ";
   index = indexOf("adamant", 'm');
   if (index == 3)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 3\n";

   cout << "Test 3c: ";
   index = indexOf("adamant", 't');
   if (index == 6)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 6\n";

   cout << "Test 3d: ";
   index = indexOf("adamant", 'x');
   if (index == -1)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not -1\n";

   cout << endl;

   // Tests 4a - 4d: Test the lastIndexOf() function
   cout << "Test 4a: ";
   index = lastIndexOf("adamant", 't');
   if (index == 6)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 6\n";

   cout << "Test 4b: ";
   index = lastIndexOf("adamant", 'm');
   if (index == 3)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 3\n";

   cout << "Test 4c: ";
   index = lastIndexOf("adamant", 'a');
   if (index == 4)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not 4\n";

   cout << "Test 4d: ";
   index = lastIndexOf("adamant", 'x');
   if (index == -1)
      cout << "correct\n";
   else
      cout << "incorrect - index returned was " << index << ", not -1\n";

   cout << endl;

   // Tests 5a - 5c: Test the startsWith() function
   cout << "Test 5a: ";
   if (startsWith("your house", "your"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 5b: ";
   if (!startsWith("my house", "your"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 5c: ";
   if (!startsWith("you", "your"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << endl;

   // Tests 6a - 6c: Test the endsWith() function
   cout << "Test 6a: ";
   if (endsWith("your house", "house"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 6b: ";
   if (!endsWith("your mouse", "house"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   cout << "Test 6c: ";
   if (!endsWith("use", "house"))
      cout << "correct\n";
   else
      cout << "incorrect\n";

   return 0;
   }

// Add your function definitions here
bool equals(const char* str1, const char* str2)
{
	if(strcmp(str1, str2)==0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

//ignores the case
bool equalsIgnoreCase(const char* str1,const char* str2)
{
   int i;
   for(i=0; str1[i]!= '\0' && str2[i]!='\0'; i++)
   {
		if(tolower(str1[i]!=tolower(str2[i])))
    	{
        	return false;
    	}
	}
    if(str1[i]=='\0'&&str2[i]=='\0')
    {
    	return true;
    }

}

//returns the place where the letter is
int indexOf(const char* str, char ch)
{
	int i;
	for(i=0; i<strlen(str); i++)
	{
		if(str[i]== ch)
		{
			return i;
		}
	}
	return -1;
}

//returns the number wehre the letter was last seen
int lastIndexOf(const char* str, char ch)
{
	int i, count;
	for(i=0; i<strlen(str); i++)
	{
		if(str[i]== ch)
		{
			count=i;
			return count;
		}
	}
	return -1;
}

//see if the word starts with the char
bool startsWith(const char* str, const char* prefix)
{
	int i;
	for(i=0; i<strlen(prefix);i++)
	{
		if(str[i] == prefix[i])
		{
			return true;
		}
		if(str[i] != prefix[i])
		{
			return false;
		}
	}
}

//see if the word ends with
bool endsWith(const char* str, const char* suffix)
{
	int i, j;
	for(i=strlen(str)-1; j=strlen(suffix)-1; i>=0 && j>=0, i--, j--)
	{
		if(str[i]==suffix[j])
		{
			return true;
		}
	}
	return false;
}

