package bur_pgk;
//Keeps track of the player and computer sentence and the number of rounds played. 
//Also has a string to record the strategy the computer used during the game. 

public class GameStat {

    String compStrategy;   
    int userSentence, compSentence;

    public GameStat() 
    {
        userSentence = 0;
        compSentence = 0;
    }

    public void update(int userSentence, int compSentence) 
    {
        this.userSentence += userSentence;
        this.compSentence += compSentence;
    }

    public String getWinner() 
    {
        if (userSentence < compSentence) 
        {
            return "Player";
        } 
        else if (compSentence < userSentence) 
        {
            return "Computer";
        } 
        else 
        {
            return "None";
        }

    }

    public int getUserSentence() 
    {
        return userSentence;
    }

    public int getCompSentence() 
    {
        return compSentence;
    }

    public void setCompStrategy(String compStrategy) 
    {
        this.compStrategy = compStrategy;
    }

    public String getCompStrategy() 
    {
        return compStrategy;
    }
}
