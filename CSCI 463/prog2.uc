#Charles Alms 
#z1797837
#Due 10/15/19

00 0 0 0 0 0 0 0 0 00 00 00	#reset everything to 0

00 0 1 0 0 0 0 0 0 01 01 01     #r1 = 0 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 01	#turn on the write enable
00 0 1 0 0 0 0 0 0 01 01 01	#turn off write enable. r1= 1

00 0 1 0 0 0 0 0 0 01 01 01	#r1 = 1 + 1 + 1
00 0 1 1 0 0 0 0 0 01 01 01     #turn on the write enable
00 0 1 0 0 0 0 0 0 01 01 01     #turn off write enable. r1= 4

00 0 1 0 0 0 0 0 0 01 01 01     #r1 = 4 + 4 + 1
00 0 1 1 0 0 0 0 0 01 01 01     #turn on the write enable
00 0 1 0 0 0 0 0 0 01 01 01     #turn off write enable. r1= 9

00 0 1 0 0 0 0 0 0 01 01 01     #r1 = 9 + 9 + 1
00 0 1 1 0 0 0 0 0 01 01 01     #turn on the write enable
00 0 1 0 0 0 0 0 0 01 01 01     #turn off write enable. r1= 13

00 0 1 0 0 0 0 0 0 01 01 01     #r1 = 13 + 13 + 1
00 0 1 1 0 0 0 0 0 01 01 01     #turn on the write enable
00 0 1 0 0 0 0 0 0 01 01 01     #turn off write enable. r1= 1F

00 0 1 0 0 0 0 0 0 01 01 00	#r1 = 1F + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00	#turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00	#turn off write enable. r1 = 20

####
00 0 0 0 0 0 0 0 0 10 01 00     #r2 = 20 + 0 + 0
00 0 0 1 0 0 0 0 0 10 01 00     #turn on write enable
00 0 0 0 0 0 0 0 0 10 01 00     #turn off write enable. r2 = 20

00 0 0 0 0 0 0 0 0 10 10 10     #r2 = 20 + 20 + 0
00 0 0 1 0 0 0 0 0 10 10 10     #turn on write enable
00 0 0 0 0 0 0 0 0 10 10 10     #turn off write enable. r2 = 40
###

00 0 1 0 0 0 0 0 0 01 01 01     #r1 = 20 + 20 + 1
00 0 1 1 0 0 0 0 0 01 01 01     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 01     #turn off write enable. r1 = 41
###############################################################################

00 0 0 0 0 0 0 0 0 10 10 10     #r2 = 40 + 40 + 0
00 0 0 1 0 0 0 0 0 10 10 10     #turn on write enable
00 0 0 0 0 0 0 0 0 10 10 10     #turn off write enable. r2 = 80

00 0 0 0 0 1 0 0 0 01 00 10	#mar 
00 0 0 0 0 0 0 0 0 01 00 10	#mar 
00 0 0 0 0 0 0 1 0 01 00 01	#mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 80 = 41

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 41 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 42

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 80 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 81

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar
00 0 0 0 0 0 0 1 0 01 00 01     #mbr
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 81 = 42

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 42 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 43

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 81 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 82

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 82 = 43

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 43 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 44

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 82 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 83

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 83 = 44

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 44 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 45

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 83 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 84

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 84 = 45

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 45 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 46

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 84 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 85

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 85 = 46

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 46 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 47

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 85 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 86

00 0 0 0 0 1 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 0 0 01 00 10     #mar 
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 86 = 47

00 0 1 0 0 0 0 0 0 01 01 00     #r1 = 47 + 0 + 1
00 0 1 1 0 0 0 0 0 01 01 00     #turn on write enable
00 0 1 0 0 0 0 0 0 01 01 00     #turn off write enable. r1 = 48

00 0 1 0 0 0 0 0 0 10 10 00     #r2 = 86 + 0 + 1
00 0 1 1 0 0 0 0 0 10 10 00     #turn on write enable
00 0 1 0 0 0 0 0 0 10 10 00     #turn off write enable. r2 = 87

00 0 0 0 0 1 0 0 0 01 00 10     #mar
00 0 0 0 0 0 0 0 0 01 00 10     #mar
00 0 0 0 0 0 0 1 0 01 00 01     #mbr 
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 0 0 1 0 0 01 00 01
00 0 0 0 0 0 0 0 0 01 00 01
00 0 0 0 1 1 0 0 0 01 01 00
00 0 0 0 1 0 0 0 1 11 01 00	#add. 87 = 48