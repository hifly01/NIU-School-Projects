#   PROGRAM:    CSCI 241 Assignment 6
#   PROGRAMMER: Theresa Li, Charles Alms 
#   LOGON ID:   Z1814730, Z1797837
#   DUE DATE:   4/10/18
# 
#   FUNCTION:   This program tests the functionality of the Queue
#               template class.

# Compiler variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file 
assign6: assign6.o
	g++ $(CCFLAGS) -o assign6 assign6.o

# Rule to compile source code file to object code
assign6.o: assign6.cpp Queue.h
	g++ $(CCFLAGS) -c assign6.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign6
