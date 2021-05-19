//import gamepackage.*;
package bur_pgk;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.Date;
import java.util.HashMap;
import java.util.*;


public class PDGameApp {

  public static void main(String args[])
  {

    HashMap<String, GameStat> hashmap = new HashMap<>();	//hash map for the date and the results of the round
    String curtime = null;

    Scanner scan = new Scanner(System.in);		//scanner for the players input
    boolean flag = true;   //flag for the choice while loop
    int choice = 0;    //choice of what the computer should do
    String file = "file.txt";			//name of the file for the file input strategy 

	PDGame pd1 = new PDGame(file);		//PDGame object
    
    System.out.println("***Starting A Game of Prisoner's Dilemma ***" + "\n\n");  //start of the program
    
    System.out.println("HERE ARE STRATEGIES AVAILABLE FOR THE COMPUTER\n");
    ArrayList<String> strategies = pd1.getStrategies();			//arraylist with the strategies  
    for(int i = 0; i<3; i++)
    {
      System.out.println("\n" + strategies.get(i));
    }
     
    //try catch to make sure the user enneters a number between 1-4
    while(flag == true)
    {
      try
      {
        System.out.print("\n\nSelect a strategy from above for the Computer to use in the 5 rounds : ");
        choice = scan.nextInt();   //scan the number choice
        if(choice<1 || choice>3)	//if the input isnt a 1, 2, or 3, throw exception
          throw new Exception();
        else
          flag = false;				//else bbreak out of the loop
      }
      catch(Exception e)
      {
        System.out.println("\nPlease enter a value between 1-3");		//output line for the error message
        scan.nextLine();			//scan the next line for the input
      }
    }
    pd1.setStrategy(choice);   //will set the stategy to the choice  
//----------------------------------------------------------------------------------------
   int counter = 0;			//counter for the 5 rounds
   int choice2 = 0;			//choice2 for talk or stay quiet 
   boolean flag2 = true;	//flag for the next loop

   while(counter<5)
   {
	  curtime = new Date().toString();
      while(flag2 == true)
      {
         try{
             System.out.println("\nHere are your choices:");
             System.out.println("1 is to stay silent, 2 is to betray");
             choice2 = scan.nextInt();			//scan for choice2

             if(choice2 == 1 || choice2 == 2)
               flag2 = false;					//if choice is 1 or 2, break the loop
             else
               throw new Exception();
         }
         catch(Exception e)
         {
           System.out.println("\nPlease enter either 1 or 2");
           scan.nextLine();
         }
      }   //while(flag2 == true)
      
      String round = pd1.playRound(choice2); // returns the result of each round
      System.out.println(round); //display the result
      counter+=1;			//increase the counter by 1
      flag2 = true;			//set the flag back to true
    }
   
//-----------------------------------------------------------------------------------------------
   
   System.out.println("\nEND OF ROUNDS, GAME OVER --GAME STATS --");

   System.out.println(pd1.getScores()); // display the prison sentence for both user and computer

   GameStat stat;
   stat = pd1.getStats();  // get that Gamestat object from PDGame get methods
   hashmap.put(curtime, stat);  // update the hashmap

   System.out.println("The summary of all the games are : \n");  // display the summary of all games
   Set<String> keySet = hashmap.keySet();  // get the keyset of the hashmap in a Set
   for (String searchKey : keySet)   // use foreach to get every key and display the GameStat values
   {   
	   GameStat result = hashmap.get(searchKey);
	   System.out.println(searchKey + " : Winner is " + result.getWinner() + ". The computer used " + result.getCompStrategy());
   }
}
}
  
