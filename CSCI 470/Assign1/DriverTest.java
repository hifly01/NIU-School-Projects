/********************************************************
Charles Alms
z1797837
Assignment 1
470 Java

Partner: Michael Burstein z1836515
********************************************************/
class DriverTest{
public static void main(String[] args)	//declare the main
{
   	Employee e1 = new Employee();	//create a new employee object

	e1.setFName("Kyle");		//set the name
	String emFName=e1.getFName();	//set a variable to the name

	e1.setLName("Johnson");		 //set the last name
        String emLName=e1.getLName();	//set a variable to the last name

	double e1sal = 10000;		//declare a salary
	e1.setSal(e1sal);		//set the salary
	double emSal = e1.getSal();	//set a variable with salary

	System.out.println("\nThe first name is "+emFName);	//print lines for
	System.out.println("The last name is "+emLName);	//printing the first
	System.out.println("The salary is "+emSal);		//last names and salary
//--------------------------------------------------------------------
        Employee e2 = new Employee();	//create a new employee object

        e2.setFName("Matt");		//set the name
        String em2FName=e2.getFName();	//set a variable to the name

        e2.setLName("Wills");		//set the last name
        String em2LName=e2.getLName();	//set a variable to the last name

        double e2sal = 15000;		//create a new salary variable
//	double e2sal = -1;		//used to test the negative salary
        e2.setSal(e2sal);		//set the salary
        double em2Sal = e2.getSal();	//set a variable with salary

        System.out.println("\nThe first name is "+em2FName);	//print lines for printing
        System.out.println("The last name is "+em2LName);	//the first, last names
        System.out.println("The salary is "+em2Sal);		//and the salary

	//print line for a raise
	System.out.println("\nThe new salary for each employee after a 10% raise is:");

	emSal = emSal +(emSal*.10);		//increase salary one by 10%
	em2Sal = em2Sal + (em2Sal*.10);		//increase salary two by 10%

        System.out.println("\nThe first name is "+emFName);	//print lines for the
        System.out.println("The last name is "+emLName);	//new salary
        System.out.println("The salary is "+emSal);		//for person one

        System.out.println("\nThe first name is "+em2FName);	//pirnt lines for the
        System.out.println("The last name is "+em2LName);	//new salary
        System.out.println("The salary is "+em2Sal);		//for person two

	Date date = new Date();			//call date constructor 1

	int Day = 13;				//set Day to a number
	date.setDay(Day);			//set the day
	int dateD= date.getDay();		//set a variable to have the date

	int Month = 7;				//set Month to 7
	date.setMonth(Month);			//set the month
	int dateM = date.getMonth();		//set a variable to have the month

	int Year = 2070;			//set Tear to 2070
	date.setYear(Year);			//set the year
	int dateY = date.getYear();		//set a variable to have the year

	//print line to print in the month/day/year format
	System.out.println("\nThis is the date "+ dateM +"/"+dateD+"/"+dateY);
}
}
