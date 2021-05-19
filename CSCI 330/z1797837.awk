# Charles Alms
# Z1797837
# 330 Assignment 7
# Due 11/6/20

# Purpose: This program will take an input file with 3 different sections
# with between 3 and 5 fields, all separated by a :. Program will print
# out 1 report with the total sales for each person

#NR is number of current records
#NF number of fields in current record
#FS is field seperator
#BEGIN matches before the first line of input. used to create headers
#END matches after the last line of input. used to create footers

BEGIN{				#do this first. Needs the { right next to it i dont know why it wont work without it like that
	FS = ":"		#make the field seperator :
	printf("%-20s\t%-15s\t%13s\n","Name", "Position", "Sales Amount")	#print 20 characters and tab left, another 15 characters and tab left, then 13 characters
        printf("=====================================================\n")
}

#main calculations for the program
#stores everything based on the assoicate id being the key
(NF == 4){						#for the products
	pid[$1]=$1					#procut id
	pcat[$1]=$2					#product category
	pdes[$1]=$3					#product description
	pprice[$1]=$4					#procuct price
}

(NF == 3){						#for the product
	aid[$1]=$1					#associate id

	split($2, name, " ")				#split the name into first and last based off a space
	aname[$1]= name[2] ", " name[1]			#associate name last, first

	apos[$1]=$3					#associate position
}

(NF == 5){						#for the transaction
	tid[$1]=$1					#trans id
	tpid[$1]=$2					#trans product id
	tquan[$1]=$3					#trans quantity
	tdate[$1]=$4					#trans date

	split($4, date, "/")				#split the date up to get the sales from 2018 only

	if(date[3] == "2018")				#if the year is 2018
	{
		empsale[$5] += (pprice[$2] * tquan[$2]) #to get the total sales for each person, multiply the price by the amount
	}
}

#do this at the end of the program. will print off the sales in order
#prints the employee name last, first	position	total sales amout
#sort -nr -k 4 is to sort the third parameter in decending order
# it needs to be 4 insted of 3 because the name is split into 2 separate parts
# spaced the same way as the header but the total is 13 digits and 2 decimal palces
#the names and positions are all left justified to look nicer
END{
	for(i in empsale){				#loops through everything
		printf("%-20s\t%-15s\t%13.2f\n",aname[i],apos[i],empsale[i]) | "sort -nr -k 4"
	}
}
