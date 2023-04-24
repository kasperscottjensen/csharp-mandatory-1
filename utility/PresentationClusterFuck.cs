namespace mandatory_1.utility;
using models;

public static class PresentationClusterFuck
{
    
    private static Random _rnd = new();
    private static List<string> _introSentence = new()
    {
        "who ended last year at an impressive rank",
        "coming back to defend their well deserved rank",
        "fighting tooth and nail to hold on to number",
        "wanting to show once again that they deserve their place at rank",
        "in a final attempt to supercede their rank from last year,"
    };

    public static void ResetAndContinue()
    {
        Console.ResetColor();
        Console.WriteLine("\nPress space to continue ...");
        while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        Console.Clear();
    }
    
    public static void Intro(League? league)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║          WELCOME TO THE LEC CHAMPIONSHIP         ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nLocation: {league!.Location}");
        Console.WriteLine($"Positions to advance to group play: {league.AdvanceGroup}");
        Console.WriteLine($"Positions to advance to MSI: {league.AdvanceMsi}");
        Console.WriteLine($"Format: {league.Format}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nPrize Pool: ${league.PrizePool}");
        ResetAndContinue();
    }

    public static void Teams(List<Team> teams)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║           NOW TO PRESENT OUR CONTENDERS          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        foreach (var team in teams)
        { 
            Console.WriteLine($"{team.FullName} ({team.Abbr}), {_introSentence[_rnd.Next(_introSentence.Count)]} {team.LastRank}.");
        }
        
        ResetAndContinue();
    }

    public static void RoundRobin(List<Sorter.Placement> placements)
    {
        int rounds = placements[0].Wins + placements[0].Losses;
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine($"║        ROUND ROBIN: {rounds} ROUNDS OF {placements.Count() / 2} MATCHES        ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nFor the fist part of the tournament, the {placements.Count()} teams");
        Console.WriteLine($"have fought each other over the course of {rounds} rounds.");
        Console.WriteLine("After shedding blood, sweat and tears, the standings are as follows:\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-5}\t{1,-15}\t{2,-5}\t{3,-5}\t{4,-10}\n", "Rank", "Team", "Wins", "Losses", "Advancing Position");
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        foreach (var team in placements)
        {
            Console.WriteLine("{0,-5}\t{1,-15}\t{2,-5}\t{3,-5}\t{4,-10}", team.Rank, team.Name, team.Wins, team.Losses, team.Id);
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nWith the opening rounds over, the prevailing teams move into group play!");
        Console.WriteLine("We serenade the losing teams for their valiant efforts.");
        
        ResetAndContinue();
    }

    public static void Gsl(Sorter.GslResult gslResult)
    {
        GslOpening(gslResult.Opening);
        GslUpper(gslResult.Upper);
        GslLower1(gslResult.Lower1);
        GslLower2(gslResult.Lower2);
    }

    private static void GslOpening(List<GSLMatch> opening)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║         GSL: Group Play Opening Matches          ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The teams will meet each other based on rank such that");
        Console.WriteLine("1 -> 5, 2 -> 6, 3 -> 7 and 4 -> 8.");
        Console.WriteLine("The teams will then proceed to upper and lower brackets");
        Console.WriteLine("to fight for a place in the semifinals!");
        Console.WriteLine("Let the group play matches commence!\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        
        foreach (var match in opening)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-10}\t{1,-5}", match.Team1!.Abbr, GetResultSymbol(match.Team1.Abbr!, match.Winner!.Abbr!));
            Console.WriteLine("{0,-10}\t{1,-5}\n", match.Team2!.Abbr, GetResultSymbol(match.Team2.Abbr!, match.Winner!.Abbr!));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{match.Winner.FullName} advances to the upper bracket.\n");
        }
        
        ResetAndContinue();
    }
    
    private static void GslUpper(List<GSLMatch> upper)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║                GSL: Upper Bracket                ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The winners of the opening matches will now fight to");
        Console.WriteLine("determine who will advance to the semifinals and who will");
        Console.WriteLine("have to join the second round of lower bracket play to");
        Console.WriteLine("fight a last stand for the remaining spots.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        
        foreach (var match in upper)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-10}\t{1,-5}", match.Team1!.Abbr, GetResultSymbol(match.Team1.Abbr!, match.Winner!.Abbr!));
            Console.WriteLine("{0,-10}\t{1,-5}\n", match.Team2!.Abbr, GetResultSymbol(match.Team2.Abbr!, match.Winner!.Abbr!));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{match.Winner.FullName} advances to the semifinals!\n");
        }
        
        ResetAndContinue();
    }
    
    private static void GslLower1(List<GSLMatch> lower1)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║            GSL: Lower Bracket Round 1            ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The losers of the opening matches will now fight to");
        Console.WriteLine("determine who will advance to the lower bracket round 2");
        Console.WriteLine("to fight a last stand for the remaining spots in the semi-");
        Console.WriteLine("finals against the losers of the upper bracket.");
        Console.WriteLine("Whoever loses now is out for good.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        
        foreach (var match in lower1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-10}\t{1,-5}", match.Team1!.Abbr, GetResultSymbol(match.Team1.Abbr!, match.Winner!.Abbr!));
            Console.WriteLine("{0,-10}\t{1,-5}\n", match.Team2!.Abbr, GetResultSymbol(match.Team2.Abbr!, match.Winner!.Abbr!));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{match.Winner.FullName} advances to round 2 of the lower bracket!\n");
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("A solemn goodbye to the losing teams. Well fought, and godspeed!");
        
        ResetAndContinue();
    }
    
    private static void GslLower2(List<GSLMatch> lower2)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║            GSL: Lower Bracket Round 2            ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The winners of the lower bracket round 1 will now fight");
        Console.WriteLine("against the losers of the upper bracket for the remaining");
        Console.WriteLine("spots in the semifinals.");
        Console.WriteLine("Whoever loses now is out for good.\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        
        foreach (var match in lower2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-10}\t{1,-5}", match.Team1!.Abbr, GetResultSymbol(match.Team1.Abbr!, match.Winner!.Abbr!));
            Console.WriteLine("{0,-10}\t{1,-5}\n", match.Team2!.Abbr, GetResultSymbol(match.Team2.Abbr!, match.Winner!.Abbr!));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{match.Winner.FullName} advances to the semifinals!\n");
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("A solemn goodbye to the losing teams. Well fought, and godspeed!");
        
        ResetAndContinue();  
    }

    private static char GetResultSymbol(string team, string winner)
    {
        if (team.Equals(winner))
        {
            return '\u2713';
        }
        return 'X';
    }

    public static void Finals(Sorter.FinalsResult finalsResult)
    {
        FinalsSemi(finalsResult.Semi);
        FinalsGrand(finalsResult.Grand);
    }

    private static void FinalsSemi(List<Match> semi)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║                    SEMI FINALS                   ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Now for the semi finals! The teams have fought hard and");
        Console.WriteLine("and will now decide who will stand face to face in the");
        Console.WriteLine("final clash of titans. To war!\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        
        foreach (var match in semi)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-10}\t{1,-5}", match.Team1!.Abbr, GetResultSymbol(match.Team1.Abbr!, match.Winner!.Abbr!));
            Console.WriteLine("{0,-10}\t{1,-5}\n", match.Team2!.Abbr, GetResultSymbol(match.Team2.Abbr!, match.Winner!.Abbr!));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{match.Winner.FullName} advances to the GRAND FINAL!\n");
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("A solemn goodbye to the losing teams. Well fought, and godspeed!");
        
        ResetAndContinue();  
    }

    private static void FinalsGrand(Match grand)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║                   GRAND FINAL                    ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("WHO WILL PREVAIL, AND WHO WILL FALL IN THIS FINAL");
        Console.WriteLine("BATTLE AMONG LEGENDS AND TITANS?\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-10}\t{1,-5}\n", "Matchup", "Result");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0,-10}\t{1,-5}", grand.Team1!.Abbr, GetResultSymbol(grand.Team1.Abbr!, grand.Winner!.Abbr!));
        Console.WriteLine("{0,-10}\t{1,-5}\n", grand.Team2!.Abbr, GetResultSymbol(grand.Team2.Abbr!, grand.Winner!.Abbr!));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{grand.Winner.FullName!.ToUpper()} IS THE VICTOR! ALL HAIL!\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        ResetAndContinue();
    }
}