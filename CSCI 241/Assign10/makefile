#   PROGRAM:    CSCI 241 Assignment 10
#   PROGRAMMER: Theresa Li 
#   LOGON ID:   Z1814730
#   DUE DATE:   5/3/18
#
#   FUNCTION:   This program tests the functionality of the List class

# Compiler variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file
assign10: assign10.o
	g++ $(CCFLAGS) -o assign10 assign10.o

# Rule to compile source code file to object code
assign10.o: assign10.cpp List.h
	g++ $(CCFLAGS) -c assign10.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign10 
