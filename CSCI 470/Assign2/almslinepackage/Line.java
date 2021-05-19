/*****************************************************************
This program demonstrates a simple "Line" class. Here, a Line class
 is defined with its properties and interface (i.e., its methods).
A main method (in TestLine) then creates instances of this Line
 class and calls on the methods to demonstrate its behavior.

Charles Alms z1797837
partner: Michael Burstein z1836515
Assignment 2
Due 9/23/19
*****************************************************************/
package almslinepackage;			//include in a package
import java.io.*;				//include java commands
import java.lang.Math;				//include Math command
public class Line
{

private int x1, y1, x2, y2; //coordinates of the line
//Constructor
//Receives 4 integers which are the Line's start and end points.
public Line(int xOne, int yOne, int xTwo, int yTwo)
{
// each of these validates its argument - see below.
setXOne(xOne);
setYOne(yOne);
setXTwo(xTwo);
setYTwo(yTwo);
} // end constructor

//new constructor for the twodpoint class
//takes in 2 twodpoint objects and sets them equal to variables
//x and y inside the twodpoint constructor
public Line(TwoDPoint t1, TwoDPoint t2)
{
   this(t1.x, t1.y, t2.x, t2.y);
}


//method draw() calls another method called drawLine(),
//which is assumed to be a graphics primitive on the
//system. However, since this program will be
//run in console mode, a text description of the Line
//will be displayed. //
public void draw()
{
   drawLine(x1, y1, x2, y2);
}

//method drawLine() simulates drawing of a line for console mode.
//It should describe all the important attributes of the line.
//In a graphics mode program, we would delete this and use the
//system's Graphics library drawLine(). //
private void drawLine(int x1, int y1, int x2, int y2)
{
   System.out.println("Draw a line from x of " + x1 + " and y of " + y1);
   System.out.println("to x of " + x2 + " and y of " + y2 + "\n");
}

//Method setLine() allows user to change the points of the
//already existing Line.
public void setLine(int xOne, int yOne, int xTwo, int yTwo)
{
   setXOne(xOne);
   setYOne(yOne);
   setXTwo(xTwo);
   setYTwo(yTwo);
}
// -- the individual setXXXX methods that prevent
//  any line's coordinate from being offscreen.
//  In the event of an invalid (offscreen) value,
//  that value is (silently) set to 0.

//changed the set methods to hold the try catch statements
//try each if statement and if it fails, throw exception
//failed exceptions print a line that says can not complete
//and give the number for the point at which it could not work
public void setXOne(int xOne)
{
   try{
      if (xOne < 0 || xOne > 639)
         throw new Exception();
      else
         x1 = xOne;
      }
   catch(Exception e)
   {
      System.out.print("--MY TRY CATCH CAUGH A GENERIC EXCEPTION IN A SET METHOD FOR BAD");	//The try and throw exception is basically the same in principal for all the sets
      System.out.println("\n Value of X1 for an existing line");
      System.out.println("\n java.lang.Exception:" + xOne + " Was out of bounds" );
   }
}


public void setYOne(int yOne)
{
try{
if (yOne < 0 || yOne > 479)
throw new Exception();
else
y1 = yOne;
}
catch(Exception e)
{
System.out.print("--MY TRY CATCH CAUGH A GENERIC EXCEPTION IN A SET METHOD FOR BAD");	//
System.out.println("\n Value of Y1 for an existing line");
System.out.println("\n java.lang.Exception:" + yOne + " Was out of bounds" );
}
}


public void setXTwo(int xTwo)
{
try{
if (xTwo > 639 || xTwo < 0)
throw new Exception();
else
x2 = xTwo;
}
catch(Exception e)
{
System.out.print("--MY TRY CATCH CAUGH A GENERIC EXCEPTION IN A SET METHOD FOR BAD");
System.out.println("\n Value of X2 for an existing line");
System.out.println("\n java.lang.Exception:" + xTwo + " Was out of bounds" );
}
}

public void setYTwo(int yTwo)
{
try{
if (yTwo > 479 || yTwo < 0)
throw new Exception();
else
y2 = yTwo;
}
catch(Exception e)
{
System.out.print("--MY TRY CATCH CAUGH A GENERIC EXCEPTION IN A SET METHOD FOR BAD");
System.out.println("\n Value of Y2 for an existing line");
System.out.println("\n java.lang.Exception:" + yTwo + " Was out of bounds" );
}
}

//Now for some "get" Access methods to get individual values
public int getXOne()
{  return x1;
}
public int getYOne()
{
return y1;
}
public int getXTwo()
{
return x2;
}
public int getYTwo()
{
return y2;
}



//This returns the length of line
public double getLength()
{
return Math.sqrt((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2));
}

//returns the angle of the line
public double getAngle()
{
return Math.asin((y2-y1)/getLength());
}

} // end class Line
