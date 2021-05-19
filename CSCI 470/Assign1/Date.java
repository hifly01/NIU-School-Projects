/********************************************************
Charles Alms
z1797837
Assignment 1
470 Java

Partner: Michael Burstein z1836515
********************************************************/
class Date			//declare case
{
	private int day;	//declare variables day, month, year
	private int month;
	private int year;

Date()				//constructor one setting day to 0
{
	this.day = 0;
}

Date(int d, int m, int y)	//second constructor
{
	this.day = d;
	this.month = m;
	this.year = y;
}

public void setDay(int d)	//sets day to d
{
	this.day = d;
}

public int getDay()		//gets day and returns it
{
	return day;
}

public void setMonth(int m)	//sets month to r
{
	this.month = m;	
}

public int getMonth()		//gets month and returns in
{
	return month;
}

public void setYear(int y)	//sets year to y
{
	this.year=y;
}

public int getYear()		//gets year and returns it
{
	return year;
}

}
