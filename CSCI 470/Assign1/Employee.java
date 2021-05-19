/********************************************************
Charles Alms
z1797837
Assignment 1
470 Java

Partner: Michael Burstein z1836515
********************************************************/
class Employee			//declare employee class
{
	private String fName;	//declare firs, lase name, and salary
	private String lName;
	private double salary;
Employee()			//first constructor setting the names to not given
{
	this.fName ="not given";
	this.lName="not given";
}

Employee(String first, String last, double sal)		//second costructor
{
	this.fName = first;
	this.lName = last;
	this.salary= sal;
}

public void setFName(String first)		//sets first name to first
{
	this.fName = first;
}

public String getFName()			//gets first name and returns it
{
	return fName;
}

public void setLName(String last)		//sets last name to last
{
        this.lName = last;
}

public String getLName()			//gets last name and returns it
{
        return lName;
}

public void setSal(double sal)			//sets salary tp sal
{
	this.salary = sal;
}

public double getSal()				//gets salary and returns it
{
	if(salary<0)				//checks if it is below 0 and set it
	{					//to 0 if it is
		salary=0;
	}
	return salary;
}
};
