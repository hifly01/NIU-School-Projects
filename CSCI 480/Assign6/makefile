#Charles Alms   z1797837
#CSCI 480 Assignment 6
#Due 4/13/20
#

CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file
Assign6: Assign6.o
	g++ $(CCFLAGS) -o Assign6 Assign6.o

# Rule to compile source code file to object code
Assign6.o: Assign6.cpp
	g++ $(CCFLAGS) -c Assign6.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o Assign6

