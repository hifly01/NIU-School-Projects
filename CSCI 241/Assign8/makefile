#   PROGRAM:    CSCI 241 Assignment 8, Part 1
#   PROGRAMMER: Theresa Li, Charles Alms 
#   LOGON ID:   Z1814730, Z1797837
#   DUE DATE:   4/26/18
#
#   FUNCTION:   This program builds and sorts lists using the quick
#               sort algorithm.

# Compiler variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file
assign8: assign8.o
	g++ $(CCFLAGS) -o assign8 assign8.o

# Rule to compile source code file to object code
assign8.o: assign8.cpp sorts.h
	g++ $(CCFLAGS) -c assign8.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign8 
