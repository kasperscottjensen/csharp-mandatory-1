namespace mandatory_1.utility;
using models;

public static class Sorter
{
    
    public struct Placement
    {
        public int Id;
        public string Name;
        public int Wins;
        public int Losses;
        public int Rank;
    }

    public struct GslResult
    {
        public List<GSLMatch> Opening;
        public List<GSLMatch> Upper;
        public List<GSLMatch> Lower1;
        public List<GSLMatch> Lower2;
    }

    public struct FinalsResult
    {
        public List<Match> Semi;
        public Match Grand;
    }
    
    public static List<Placement> RoundRobin(List<List<Match>> roundRobin)
    {
        List<Placement> placements = new();
        List<Match> allMatches = roundRobin.SelectMany(x => x).ToList();
        
        // Sort teams according to wins and calculate losses
        
        var teamsByWins = allMatches
            .Where(match => match.Winner != null)
            .GroupBy(match => match.Winner!.FullName)
            .Select(group => new { Name = group.Key, Wins = group.Count() })
            .OrderByDescending(x => x.Wins);
        
        foreach (var team in teamsByWins)
        {
            placements.Add(new Placement
                {
                    Name = team.Name!,
                    Wins = team.Wins,
                    Losses = roundRobin.Count() - team.Wins
                });
        }
        
        // Assign a rank to each team based on wins. 
        
        int currentRank = 1;
        
        for (int i = 0; i < placements.Count(); i++)
        {
            Placement placement = placements[i];
            if (i > 0 && placement.Wins < placements[i - 1].Wins)
            {
                currentRank++;
            }
            placement.Rank = currentRank;
            placement.Id = i + 1;
            placements[i] = placement;
        }
        return placements;
    }

    public static GslResult Gsl(List<List<GSLMatch>> gsl)
    {
        List<GSLMatch> allMatches = gsl.SelectMany(matches => matches).ToList();
        
        return new GslResult
        {
            Opening = allMatches.Where(match => match.Tag != null && match.Tag.Contains("opening")).ToList(),
            Upper = allMatches.Where(match => match.Tag != null && match.Tag.Contains("upper")).ToList(),
            Lower1 = allMatches.Where(match => match.Tag != null && match.Tag.Contains("lower1")).ToList(),
            Lower2 = allMatches.Where(match => match.Tag != null && match.Tag.Contains("lower2")).ToList()
        };
    }

    public static FinalsResult Finals(List<List<Match>> finals)
    {
        return new FinalsResult
        {
            Semi = finals.Find(list => list.Count() == 2)!,
            Grand = finals.Find(list => list.Count() == 1)![0]
        };
    }
    
}