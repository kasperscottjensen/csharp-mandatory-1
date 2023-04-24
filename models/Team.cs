namespace mandatory_1.models;

public class Team
{

    private string? _fullName;
    private string? _abbr;
    private int _lastRank;

    public Team(
        string? fullName = null,
        string? abbr = null,
        int lastRank = default
    )
    {
        _fullName = fullName;
        _abbr = abbr;
        _lastRank = lastRank;
    }

    public string? FullName
    {
        get => _fullName;
        set => _fullName = value;
    }

    public string? Abbr
    {
        get => _abbr;
        set => _abbr = value;
    }

    public int LastRank
    {
        get => _lastRank;
        set => _lastRank = value;
    }
    
}