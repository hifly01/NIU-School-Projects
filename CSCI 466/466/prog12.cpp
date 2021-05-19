/*
Charles Alms
section 1
Revanth Reddy Dadi
Prog 12
Due: 12/5
*/

#include <mysql.h>
#include <iostream>
using namespace std;

#define SERVER "courses"
#define USER "z1797837"
#define PASSWORD "1998May11"
#define DATABASE "henrybooks"

int main()
{
	MYSQL *connect, mysql;
	connect=mysql_init(&mysql);

	connect=mysql_real_connect
		(connect, SERVER, USER, PASSWORD, DATABASE, 0, NULL, 0);

	if(connect)
	{
		MYSQL_RES *res_set;
		MYSQL_ROW row;
		mysql_query(connect, "select Title, Price, AuthorFirst, AuthorLast from Author, Wrote, Book where Book.BookCode=Wrote.BookCode and Author.AuthorNum=Wrote.AuthorNum;");

		res_set=mysql_store_result(connect);

		while((row=mysql_fetch_row(res_set))!=NULL)
		{
			cout<<row[0]<<"  "<<row[1]<<"  "<<row[2]<<"  "<<row[3]<<endl;
		}
		mysql_free_result(res_set);
	}
	mysql_close(connect);
}
