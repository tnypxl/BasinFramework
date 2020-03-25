namespace Basin.Config.Interfaces
{
    public interface ILoginConfig
    {
        string Role { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Token { get; set; }
    }
}