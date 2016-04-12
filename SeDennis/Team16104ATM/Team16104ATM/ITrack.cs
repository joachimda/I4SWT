namespace Team16104ATM
{
    public interface ITrack
    {
        double CurCompasCourse { get; set; }
        Position Position { get; set; }
        string Tag { get; set; }
        double Velocity { get; set; }
    }
}