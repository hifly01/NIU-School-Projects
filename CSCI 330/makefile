#Charles Alms
#z1797837
#CSCI 330
#assign 5
#10/23/20

# Compiler variables
CCFLAGS = -Wall -std=c++11

# Rule to link object code files to create executable file
assign5: assign52.o
	g++ $(CCFLAGS) -o assign5 assign52.o

# Rules to compile source code files to object code
assign5.o: assign52.cc
	g++ $(CCFLAGS) -c assign52.cc

# Pseudo-target to remove object code and executable files
clean:
	-rm *.o assign5

