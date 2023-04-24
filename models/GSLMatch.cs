namespace mandatory_1.models;

public class GSLMatch : Match
{
    
    // Match with a tag identifying which GSL bracket it belongs to
    
    private string? _tag;
    
    public GSLMatch(
        int id = default,
        string? date = default,
        Team? team1 = null,
        Team? team2 = null,
        Team? winner = null,
        string? tag = default
    ) : base(id, date, team1, team2, winner)
    {
        _tag = tag;
    }

    public string? Tag
    {
        get => _tag;
        set => _tag = value;
    }
    
}