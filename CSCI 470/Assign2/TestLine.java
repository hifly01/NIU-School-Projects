/***************************************************************
Now we will define a driver program below called TestLine with
main() where execution will begin. It is this class, and this code,
 that will create instances of the Line and call its methods. As a
test module, this code would be improved with additional
System.out.println() statements that explain what is being attempted
 and what the results should be, for example: "About to change l1 to
 an invalid value and then redraw it. Line position
should not change:

Charles Alms z1797837
partner: Michael Burstein z1836515
Assignment 2
Due 9/23/19
"*/
//*********************************************************
import almslinepackage.*;		//import the package

class TestLine
{

public static void main(String args[])
{
Line l1 = null, l2 = null, l3 = null;
//declare 2 instances of Line class
//create 1 Line object
l1 = new Line (10, 10, 100, 100);
//draw it
l1.draw();
//change start point with valid values
l1.setLine(5, 5, l1.getXTwo(), l1.getYTwo());
//draw it again with new start point
l1.draw();
//try to change xOne (x1) to an illegal value
l1.setXOne(3000);
//draw the line...x1 should now be zero
l1.draw();

l1.getLength();

l1.getAngle();
//create a second Line instance, or object
l2 = new Line(100, 100, 400, 400);
//draw 2nd line
l2.draw();
//set a new valid yTwo for line 2
l2.setYTwo(479);
//draw 2nd line again
l2.draw();

l2.getLength();

l2.getAngle();
//print lines for the length
System.out.println("Here's the length for line 1: " + l1.getLength());

System.out.println("Here's the lenght for line 2: " + l2.getLength());

//print lines for the angle
System.out.println("\nHere's the angle for line 1: " + l1.getAngle());

System.out.println("Here's the angle for line 2: " + l2.getAngle());

//try catch for the new constructor
try{
TwoDPoint one = new TwoDPoint(10,5);
TwoDPoint two = new TwoDPoint(100, 400);

//print lines
System.out.println("\ntest 2D point Constructor X1 = " + one.x);
System.out.println("\ntest 2D point Constructor Y1 = " + one.y);
System.out.println("\ntest 2D point Constructor X2 = " + two.x);
System.out.println("\ntest 2D point Constructor Y2 = " + two.y);

//throw the exception
throw new Exception();
}

//catch the exception and exit with return code 88
catch(Exception c)
{
System.out.println("\nThis try catch caught a Generic Exception for a bad constructor");
System.out.println("Failed to create a line with 4 invalid values");
System.out.println("leaving with rc of 88");
System.exit(88);
}

} // end of main

}  // end class TestLine
