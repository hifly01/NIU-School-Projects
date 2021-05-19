#
# PROGRAM:      assign5
# PROGRAMMER:   Theresa Li, Charles Alms
# LOGON ID:     Z1814730, Z1797837
# DUE DATE:     3/27/18
#

# Compiler Variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file
assign4: assign5.o VectorN.o
	g++ $(CCGLAGS) -o assign5 assign5.o VectorN.o

# Rules to compile source code files to object code
assign4.o: assign5.cpp VectorN.h
	g++ $(CCFLAGS) -c assign5.cpp

Vector3.o: VectorN.cpp VectorN.h
	g++ $(CCFLAGS) -c VectorN.cpp

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign5
