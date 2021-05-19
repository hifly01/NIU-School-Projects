#!/bin/bash

#Charles Alms
#330 fall 2020
#Assignment 6, automotive shell script
#Due 10/30/20

#purpose: Create a shell script that will allow the user to create and edit
#a simple database that will hold information on cars such as the make, model
#year and color. User can add and remove as many records as they want


#create a new data base that takes the name and 1 parameter. if no parameter, make it untitled
#dbparam is the first parameter and dbnme is the name of the database
new()
{
	if [ -n "$nameofdb" ];					#if the third parameter is blank
	  then
	    echo "$nameofdb" > $dbnme				#database name acts more like a key. the name is the first parameter after new

	else
	    echo "Untitled Database " > $dbnme			#if the user did not enter a database name

	fi
}

#the add() is to add a record to the databbase with 5 parameters.
#param1, param2, param3. param4, parma5 will hold info on the car
#such as database, maker, model, year, and color
#make, model, color must be larger than 0 characters, year must be above 1870 and below 2025
add()
{
	if [ "$#" -eq 2 -o "$#" -eq 5 ]		#if the user missed at least 1 parameter
	  then
		echo ""
		echo "Some parameters are missing"
	elif [ "$#" -gt 6 ]			#if the user had too many parameters
	  then
		echo ""
		echo "Too many parameters. Only need car maker, model, year and color"
	else
		if [ -f $dbnme -a -w $dbnme ] 			#check to see if the file exists and can be written to
	 	 then
			if [ "$caryear" -lt 1870 -o "$caryear" -gt 2025 ]			#checks the car year
	  		 then
				echo ""
				echo "Car year is out of bounds. Please make sure it is between 1870 and 2025"
			else
				echo "$carmake, $carmodel, $caryear, $carcolor" >> $dbnme		#adds the car data to the database if everything is ok
				echo "added"
			fi
		else						#if the file could not be written to or something is wrong
			echo ""
			echo "Could not find that database or file is not writable"
		fi
	fi
}

#the show() will show records from the database and will take up to 4 parameters
#all will show all records, single shows 1 record with 1 parameter, range shows a range of records with 2 parameters
show()
{
	if [ "$amount" = "all" ]				#if user wants to see all records
	  then
		if [ -f $dbnme -a -r $dbnme ] 			#make sure the database is a file and readable
	  	 then
			cat $dbnme				#print out the whole db
		fi
	elif [ "$amount" = "single" ]				#if user wants to see single records
	  then
		sed -n $((showpar2+1))p $dbnme			#needs +1 so it does not show the title

	elif [ "$amount" = "range" ]				#if user wants to show a range of records
	  then
		if [ "$showupper" -gt "$showlower" ]			#if the lower range is higher than the upper
		  then
			sed -n "$((showlower+1)),$((showupper+1))"p $dbnme	#shows the records in between the range. +1 to get rid of the title
		else
			echo ""
			echo "The lower should be a lower number than the upper limit"
		fi
	else
		echo ""
		echo "Can not read file or file is epmty. Please make sure read is enabled and records are in the file"
	fi
}

#delete() is to remove records from the database with up to 4 parameters
#works just like show but the first parameter will be delete
delete()
{
	if [ "$amount" = "all" ]				#if user wants to delete all
	  then
		if [ -f $dbnme -a -r $dbnme ] 			#make sure the database is a file and readable
	  	 then
			sed -i "1!"d $dbnme			#delete all but the first record (the nameofdb)
			echo "deleting all"			#delete the whole database here
		else
			echo ""
			echo "Database can not be read"
		fi
	elif [ "$amount" = "single" ]				#if user wants to delete single record
	  then
		sed -i "$((delpar2+1))"d $dbnme			#delete the value at "delpar2" that the user entered
		echo "deleting 1"

	elif [ "$amount" = "range" ]
	  then
		if [ "$delupper" -gt "$dellower" ]		#if the lower range is higher than the upper
		  then
			echo ""
			echo "Please make sure the first number is lower than the second"
		else
			sed -i "$((dellower+1)),$((delupper+1))"d $dbnme		#delete the range
			echo "deleting range"
		fi
	else
		echo ""
		echo "Can not read file or file is epmty. Please make sure read is enabled and records are in the file"
	fi
}

#counts how many records are in the database using wc -l
count()
{
		counter=$(< "$dbnme" wc -l)			#sets counter to the line counter amount
		counter=$((counter-1))				#subtract 1 to not include the nameofdb
		if [ "$counter" -eq 1 ]
		  then
	                echo "$counter record in the database"		#simple print messages to show how many are in the db
		else
			echo "$counter records in the database"
		fi
}

#if the user does not enter command 1 or command 2, it will show some options
blank()
{
	echo " "
	echo "# dbname  ­ filename of database file to use"
	echo "# command ­ which of the functions to call: \"new\", \"add\", \"show\", \"delete\""
	echo "# param1  ­ first non­dbname parameter to whichever command function chosen"
	echo "# ...­ placeholder for parameters between 1 and N"
	echo "# paramN  ­ Nth parameter to whichever command function chosen"
	echo "Example % ./z1797837dbnme.sh dbnmename command param1 param2 ... paramN"
	echo " "
	echo "While in the loop, enter a full command including the database name, function, and parameters"
	echo "Example:  database add Ford Pickup 2000 green"
	echo ""
}


#this is hwo the program runs before it enters the loop. User can type "./z1797837 DB new example"
#and it will preform new and then enter the loop
if [ "$1" = "" -o "$2" = "" ] 		#if the command line is blank for the first or second command
   then
	blank				#blank shows some options to choose
else					#start going through all the options
#-------------------------------------------------------------------------------------------------------------------
	if [ "$2" = "new" ] 		#if the second parameter is new, call the new
	  then
		dbnme=$1		#set the first parameter to dbnme
		nameofdb=$3		#name of the database is the third parameter
		new dbnme nameofdb	#call new with database name and the name of the data itself

	        echo "New database created"
		echo ""
#-------------------------------------------------------------------------------------------------------------------
	elif [ "$2" = "add" ] 				#if user types DB add ...
       	  then
		if [ "$#" -lt 6 ]			#if the user entered less than the amount of params
		  then
			echo ""
			echo "Missing some parameters"
		elif [ "$#" -gt 6 ]			#if there are too many parameters
		  then
			echo ""
			echo "Too many parameters"
		else
			dbnme=$1
			carmake=$3				#car maker is the fourth param
			carmodel=$4				#car model is the 5th
			caryear=$5				#car year is the 6th
			carcolor=$6				#car color is 7th

			add dbnme nameofdb carmake carmodel caryear carcolor		#call add function with data user entered
		fi
#-------------------------------------------------------------------------------------------------------------------
	elif [ "$2" = "show" ] 					#if user types DB show ...
  	  then
		dbnme=$1

		if [ "$3" = "all" -a "$#" -eq 3 ]		#if user typed "all" and has 3 parameters
	  	  then
	                amount=$3

			show dbnme amount 			#call show with the database name and all

		elif [ "$3" = "single" -a "$#" -eq 4 ]		#you need to have exactly 4 parameters for show single
		  then
			amount=$3

			showpar2=$4				#show the amount of the single (number value)
			show dbnme amount showpar2		#call show with the database name, show, single, number to see


		elif [ "$3" = "range" -a "$#" -eq 5 ]		#you need to have exactly 5 parameters for show range
	 	  then
			amount=$3

			showlower=$4				#lower limit
			showupper=$5				#upper limit
			show dbname amount showlower showupper		#call show with the name, range, lower limit and uper limit
		else
			echo ""
			echo "Invalid show command. Check parameters and spelling"
		fi

#-----------------------------------------------------------------------------------------------------------------------------
	elif [ "$2" = "delete" ]
	  then
		dbnme=$1

		if [ "$3" = "all" -a "$#" -eq 3 ]		#if the user wants to delete all
		  then
			amount=$3				#holds all
			delete dbnme amount 			#call show with the database name and all

		elif [ "$3" = "single" -a "$#" -eq 4 ]		#you need to have exactly 4 parameters for show single
		  then
			amount=$3				#holds "single"
			delpar2=$4				#show the amount of the single (number value)
			delete dbnme amount delpar2		#call show with the database name, show, single, number to see

		elif [ "$3" = "range" -a "$#" -eq 5 ]		#you need to have exactly 5 parameters for show range
		  then
			amount=$3				#holds "range"
			dellower=$4				#lower limit
			delupper=$5				#upper limit
			delete dbname amount dellower delupper 		#call show with the name, range, lower limit and uper limit

		else
			echo ""
			echo "invalid delete command. Check parameters and spelling"
		fi
#-----------------------------------------------------------------------------------------------------------------------
	elif [ "$2" = "count" -a "$#" -eq 2 ]			#if the user wants to count and only typed 2 parameters
	  then
		dbnme=$1
		count dbnme					#call count function
#-----------------------------------------------------------------------------------------------------------------------
	else
		echo ""
		echo "There is something wrong with the option you are trying to do"
		echo "Either it is not a vaild option or is spelled wrong"
	fi
fi		#end of the if statement



#This is the start of the main loop. if the user entered in a command previously while running the program,
#the program will jump inmto the loop here. If the user typed just "./z1797837.sh", it will show some options (call blank)
until [ "$input" = "quit" -o "$intput" = "q" -o "$par1" = "quit" -o "$par1" = "q" ]		#run loop till user types quit or q
  do
	#input another command line just like the one from the handout example
	echo ""
	echo "Would you like to continue? If so, enter another full command line. Hit enter again to see how"
	read -p "Otherwise type quit: " par1 input par2 par3 par4 par5 par6

	if [ "$input" = "quit" -o "$input" = "q" -o "$par1" = "quit" -o "$par1" = "q" ]         	#quit the loop
           then
                exit							#exit the loop

	elif [ -n "$par6" ]						#if the user entered too many parameters
	  then
		echo "Too many parameters"

	elif [ "$input" = "add" ]					#if the user is adding another record
	  then
		dbnme=$par1						#store all the parameters in the respective names
		carmake=$par2
		carmodel=$par3
		caryear=$par4
		carcolor=$par5
		echo ""
		add dbnme nameofdb carmake carmodel caryear carcolor		#call add function with new parameters user entered
	#----------------------------------------------------------------------------------------------------
	elif [ "$input" = "show" ]					#if the user picks show
	  then
		dbnme=$par1						#store the parameters
		amount=$par2

		if [ "$amount" = "single" ]				#if user picked single
		  then
			showpar2=$par3					#holds the number the user wants to see
			echo ""
			show dbnme amount showpar2			#call show with 3 parameters

		elif [ "$amount" = "all" ]				#if user wants to see all
		  then
			showpar1=$par3					#holds "all"
			echo ""
			show dbnme amount showpar1			#call show all
		elif [ "$amount" = "range" ]
		  then
			showlower=$par3					#enter the high and low amounts
			showupper=$par4
			echo ""
			show dbnme amount showlower showupper		#call chow range
		else
			echo "That was not a valid option"
			echo ""
		fi
	#------------------------------------------------------------------------------------
	elif [ "$input" = "delete" ]              			#if the user picks delete
          then
                dbnme=$par1						#store param
		amount=$par2

                if [ "$amount" = "single" ]				#if user wants to pick 1
                  then
                        delpar2=$par3					#holds record number
                        echo ""
                        delete dbnme amount delpar2			#call delete single
                elif [ "$amount" = "all" ]				#for all
                  then
                        delpar1=$par3					#holds "all"
			echo ""
                        delete dbnme amount delpar1			#call delete all

                elif [ "$amount" = "range" ]				#user wants range
                  then
                        dellower=$par3					#stores high and low amounts
                        delupper=$par4
                        echo ""
                        delete dbnme amount dellower delupper		#Call delete range
                else
                        echo "That was not a valid option. Quiting"
                        echo ""
                        exit
                fi
	#----------------------------------------------------------------------------------
	elif [ "$input" = "count" ]					#if user wants count
	  then
		dbnme=$par1						#store dbnme
		count dbnme						#call count

	elif [ "$input" = "new" ]					#user wants new
	  then
		dbnme=$par1						#store dbnme and nameofdb
		nameofdb=$par2
		new db nameofdb						#call new
		echo ""
		echo "New database created"

	elif [ "$input" = "" -o "$intput" = "" -o "$par1" = "" -o "$par1" = "" ]
	  then
		blank

	else								#if the user types something else
		echo "Invalid command. Please check spelling and parameter amounts"
	fi

done		#done with the unitl loop
