namespace mandatory_1.models;

public class Match
{

    private int _id;
    private string? _date;
    private Team? _team1;
    private Team? _team2;
    private Team? _winner;

    public Match(
        int id = default,
        string? date = default,
        Team? team1 = null,
        Team? team2 = null,
        Team? winner = null
    )
    {
        _id = id;
        _date = date;
        _team1 = team1;
        _team2 = team2;
        _winner = winner;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
    public string? Date
    {
        get => _date;
        set => _date = value;
    }

    public Team? Team1
    {
        get => _team1;
        set => _team1 = value;
    }

    public Team? Team2
    {
        get => _team2;
        set => _team2 = value;
    }

    public Team? Winner
    {
        get => _winner;
        set => _winner = value;
    }
    
}