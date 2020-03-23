namespace Basin.Config.Interfaces
{
    public interface IDriverConfig
    {
        int Timeout { get; set; }
        string Browser { get; set; }
    }
}