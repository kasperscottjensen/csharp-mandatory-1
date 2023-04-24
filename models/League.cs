namespace mandatory_1.models;

public class League
{

    private string? _fullName;
    private string? _abbr;
    private string? _location;
    private int _advanceGroup;
    private int _advanceMsi;
    private string? _format;
    private int _prizePool;

    public League(
        string? fullName = null,
        string? abbr = null,
        string? location = null,
        int advanceGroup = default,
        int advanceMsi = default,
        string? format = null,
        int prizePool = default
    )
    {
        _fullName = fullName;
        _abbr = abbr;
        _location = location;
        _advanceGroup = advanceGroup;
        _advanceMsi = advanceMsi;
        _format = format;
        _prizePool = prizePool;
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

    public string? Location
    {
        get => _location;
        set => _location = value;
    }

    public int AdvanceGroup
    {
        get => _advanceGroup;
        set => _advanceGroup = value;
    }

    public int AdvanceMsi
    {
        get => _advanceMsi;
        set => _advanceMsi = value;
    }

    public string? Format
    {
        get => _format;
        set => _format = value;
    }

    public int PrizePool
    {
        get => _prizePool;
        set => _prizePool = value;
    }
    
}