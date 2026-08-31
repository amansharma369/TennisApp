namespace Tennis.Domain.Services;

public class TennisScoringEngine
{
    int player1Point = 0;
    int player2Point = 0;
    int setsWonByPlayer1 = 0;
    int setsWonByPlayer2 = 0;
    int gamesWonByPlayer1 = 0;
    int gamesWonByPlayer2 = 0;
    int player1TieBreakPoint = 0;
    int player2TieBreakPoint = 0;
    int[] Point = {0, 15, 30, 40, 41,42}; // 41 represents advantage
    public void RecordPoint(int number)
    {
        try
        {
            // Implementation for recording a point
        // Console.WriteLine("enter player id (1 or 2) who won the point");
        // int number = Convert.ToInt32(Console.ReadLine());
        Points(number);
        Console.WriteLine($"Current Score: Player 1 - {Point[player1Point]}, Player 2 - {Point[player2Point]}");


        Game(player1Point, player2Point);
        Console.WriteLine($"Games Won: Player 1 - {gamesWonByPlayer1}, Player 2 - {gamesWonByPlayer2}");
        
        
        Set(gamesWonByPlayer1, gamesWonByPlayer2);
        Console.WriteLine($"Sets Won: Player 1 - {setsWonByPlayer1}, Player 2 - {setsWonByPlayer2}");
        
        
        int matchResult = Match(setsWonByPlayer1, setsWonByPlayer2);
        if (matchResult == 1)
        {
            Console.WriteLine("Player 1 wins the match");
        }
        else if (matchResult == 2)
        {
            Console.WriteLine("Player 2 wins the match");
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }   
    public void Points(int playerId)
    {
        if (playerId == 1)
        {
            player1Point++;
        }
        else if (playerId == 2)
        {
            player2Point++;
        }
        else
        {
            Console.WriteLine("Invalid player id");
            return;
        }
    }
    public void Game(int player1Point, int player2Point)
    {
        if (player1Point >= 4 && player1Point - player2Point >= 2)
        {
            Console.WriteLine("Player 1 wins the game");
            gamesWonByPlayer1++;
            DefaultPoints();
        }
        else if (player2Point >= 4 && player2Point - player1Point >= 2)
        {
            Console.WriteLine("Player 2 wins the game");
            gamesWonByPlayer2++;
            DefaultPoints();
        }
        else if (player1Point == 3 && player2Point == 3)
        {
            Console.WriteLine("Deuce");
        }
        else if (player1Point == 4 && player2Point == 4)
        {
            Console.WriteLine("Deuce");
            DefaultDeuce();
        }
        else if (player1Point == 4 && player2Point == 3)
        {
            Console.WriteLine("Player 1 has advantage");
        }
        else if (player2Point == 4 && player1Point == 3)
        {
            Console.WriteLine("Player 2 has advantage");
        }
    }
    public void Set(int gamesWonByPlayer1, int gamesWonByPlayer2)
    {
        if (gamesWonByPlayer1 >= 6 && gamesWonByPlayer1 - gamesWonByPlayer2 >= 2)
        {
            Console.WriteLine("Player 1 wins the set");
            setsWonByPlayer1++;
            DefaultGames();
        }
        else if (gamesWonByPlayer2 >= 6 && gamesWonByPlayer2 - gamesWonByPlayer1 >= 2)
        {
            Console.WriteLine("Player 2 wins the set");
            setsWonByPlayer2++;
            DefaultGames();
        }
        else if (gamesWonByPlayer1 == 6 && gamesWonByPlayer2 == 6)
        {
            Console.WriteLine("Tie-break");
            TieBreak();
        }
    }
    public int Match(int setsWonByPlayer1, int setsWonByPlayer2)
    {
        if (setsWonByPlayer1 == 2)
        {
            Console.WriteLine("Player 1 wins the match");
            // DefaultSet();
            return 1;
        }
        else if (setsWonByPlayer2 == 2)
        {
            Console.WriteLine("Player 2 wins the match");
            // DefaultSet();
            return 2;
        }
        return 0;
    }
    public void TieBreak()
    {
        Console.WriteLine("Tie-break is has started.");
        while (!(gamesWonByPlayer1 == 0))
        {
            Console.WriteLine($"Current Tie-break Score: Player 1 - {player1TieBreakPoint}, Player 2 - {player2TieBreakPoint}");
            Console.WriteLine("enter player id (1 or 2) who won the tie break point");
            int pointWinner = Convert.ToInt32(Console.ReadLine());
            TieBreakPoints(pointWinner);
        }
    }
    public void TieBreakPoints(int playerId)
    {
        if (playerId == 1)
        {
            player1TieBreakPoint++;
        }
        else if (playerId == 2)
        {
            player2TieBreakPoint++;
        }
        else
        {
            Console.WriteLine("Invalid player id");
            return;
        }

        if (player1TieBreakPoint >= 7 && player1TieBreakPoint - player2TieBreakPoint >= 2)
        {
            Console.WriteLine("Player 1 wins the tie-break and the set");
            setsWonByPlayer1++;
            DefaultGames();
            DefaultTieBreakPoints();
        }
        else if (player2TieBreakPoint >= 7 && player2TieBreakPoint - player1TieBreakPoint >= 2)
        {
            Console.WriteLine("Player 2 wins the tie-break and the set");
            setsWonByPlayer2++;
            DefaultGames();
            DefaultTieBreakPoints();
        }
    }
    public void DefaultPoints()
    {
        player1Point = 0;
        player2Point = 0;
    }
    public void DefaultTieBreakPoints()
    {
        player1TieBreakPoint = 0;
        player2TieBreakPoint = 0;
    }
    public void DefaultGames()
    {
        gamesWonByPlayer1 = 0;
        gamesWonByPlayer2 = 0;
    }
    public void DefaultDeuce()
    {
        player1Point = 3;
        player2Point = 3;
    }
    
}