#   PROGRAM:    CSCI 241 Assignment 7
#   PROGRAMMER: Theresa Li, Charles Alms 
#   LOGON ID:   Z1814730, Z1797837
#   DUE DATE:   4/19/18
# 
#   FUNCTION:   This program tests the functionality of the Queue
#               template class.

# Compiler variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file 
assign7: assign7.o
	g++ $(CCFLAGS) -o assign7 assign7.o

# Rule to compile source code file to object code
assign7.o: assign7.cpp Queue.h
	g++ $(CCFLAGS) -c assign7.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign7
