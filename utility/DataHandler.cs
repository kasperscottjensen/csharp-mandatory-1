namespace mandatory_1.utility;
using models;

public class DataHandler
{
    
    private League? _league;
    private List<Team> _teams = new();
    private List<List<Match>> _roundRobin = new();
    private List<List<GSLMatch>> _gsl = new();
    private List<List<Match>> _finals = new();

    public DataHandler()
    {
        HandleLeague();
        HandleTeams();
        HandleRoundRobin();
        HandleGsl();
        HandleFinals();
        ValidateData();
    }

    private void HandleLeague()
    {
        string?[] data = FileReader.ReadFile("setup/league.csv")[0];
        
        _league = new League(
            fullName: data[0],
            abbr: data[1],
            location: data[2],
            advanceGroup: int.Parse(data[3]!),
            advanceMsi: int.Parse(data[4]!),
            format: data[5],
            prizePool: int.Parse(data[6]!)
        );
        Console.WriteLine("league.csv structure is valid");
    }

    private void HandleTeams()
    {
        List<string?[]> data = FileReader.ReadFile("setup/teams.csv");
        
        foreach (var array in data)
        {
            _teams.Add(new Team(
                    fullName: array[0],
                    abbr: array[1],
                    lastRank: int.Parse(array[2]!)
            ));
        }
        Console.WriteLine("teams.csv structure is valid");
    }

    private void HandleRoundRobin()
    {
        string[] files = FileReader.GetFiles("roundrobin");
        
        foreach (var file in files)
        {
            List<string?[]> data = FileReader.ReadFile("roundrobin/" + Path.GetFileName(file));
            List<Match> round = new();
            
            foreach (var array in data)
            {
                round.Add(new Match(
                    id: int.Parse(array[0]!),
                    date: array[1],
                    team1: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[2])),
                    team2: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[3])),
                    winner: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[4]))
                ));
            }
            RoundRobin.Add(round);
            Console.WriteLine($"{Path.GetFileName(file)} structure is valid");
        }
    }

    private void HandleGsl()
    {
        string[] files = FileReader.GetFiles("gsl");
        
        foreach (var file in files)
        {
            string filename = Path.GetFileName(file);
            
            List<string?[]> data = FileReader.ReadFile("gsl/" + filename);
            List<GSLMatch> round = new();
            
            foreach (var array in data)
            {
                round.Add(new GSLMatch(
                    id: int.Parse(array[0]!),
                    date: array[1],
                    team1: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[2])),
                    team2: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[3])),
                    winner: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[4])),
                    tag: filename
                ));
            }
            _gsl.Add(round);
            Console.WriteLine($"{Path.GetFileName(file)} structure is valid");
        }
    }
    
    private void HandleFinals()
    {
        string[] files = FileReader.GetFiles("finals");
        
        foreach (var file in files)
        {
            List<string?[]> data = FileReader.ReadFile("finals/" + Path.GetFileName(file));
            List<Match> round = new();
            
            foreach (var array in data)
            {
                round.Add(new Match(
                    id: int.Parse(array[0]!),
                    date: array[1],
                    team1: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[2])),
                    team2: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[3])),
                    winner: _teams.Find(team => team.Abbr != null && team.Abbr.Equals(array[4]))
                ));
            }
            _finals.Add(round);
            Console.WriteLine($"{Path.GetFileName(file)} structure is valid");
        }
    }

    private void ValidateData()
    {
        Console.WriteLine("testing all object attributes for null and empty ...");
        Validator.Validate(_league);
        
        IEnumerable<object> allObjects = _teams.Cast<object>()
            .Concat(_roundRobin.SelectMany(x => x.Cast<object>()))
            .Concat(_gsl.SelectMany(x => x.Cast<object>()))
            .Concat(_finals.SelectMany(x => x.Cast<object>()));
        
        foreach (var obj in allObjects)
        {
            Validator.Validate(obj);
        }
        Console.WriteLine("data is valid");
    }
    
    public League? League => _league;
    public List<Team> Teams => _teams;
    public List<List<Match>> RoundRobin => _roundRobin;
    public List<List<GSLMatch>> Gsl => _gsl;
    public List<List<Match>> Finals => _finals;
    
}