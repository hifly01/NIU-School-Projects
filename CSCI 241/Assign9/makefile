#
#   PROGRAM:    CSCI 241 Assignment 9
#   PROGRAMMER: Theresa Li, Charles Alms 
#   LOGON ID:   Z1814730, Z1797837
#   DUE DATE:   5/2/18
#
#   FUNCTION:   This program uses polymorphism with different shapes 


# Compiler Variables
CCFLAGS = -ansi -Wall -std=c++11

# Rule to link object code files to create executable file
assign9: assign9.o shape.o circle.o rectangle.o triangle.o
	g++ $(CCFLAGS) -o assign9 assign9.o shape.o circle.o rectangle.o triangle.o

# Rule to compile source code files to object code
assign9.o: assign9.cpp shape.h circle.h rectangle.h triangle.h
	g++ $(CCFLAGS) -c assign9.cpp

shape.o: shape.cpp shape.h
	g++ $(CCFLAGS) -c shape.cpp

circle.o: circle.cpp circle.h
	g++ $(CCFLAGS) -c circle.cpp

rectangle.o: rectangle.cpp rectangle.h
	g++ $(CCFLAGS) -c rectangle.cpp

triangle.o: triangle.cpp triangle.h
	g++ $(CCFLAGS) -c triangle.cpp

circle.h: shape.h
rectangle.h: shape.h
triangle.h: shape.h

#Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign9 
