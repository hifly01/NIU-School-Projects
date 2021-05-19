#include <mysql.h>
#include <iostream>
using namespace std

#define SERVER "courses"
#define USER "z1797837"
#define PASSWORD "1998May11"
#define DATABASE "z1797837"

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
		mysql_query(connect, "select f.flightnum from flight f;");

		res_set=mysql_store_result(connect);

		while((row=mysql_fetch_row(res_set))!=NULL)
		{
			cout<<row[0]<<endl;
		}
	}
	mysql_free_result(res_set);
	mysql_close(connect);
}
