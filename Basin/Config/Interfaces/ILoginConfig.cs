namespace Basin.Config.Interfaces
{
    public interface ILoginConfig
    {
        string Role { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Token { get; set; }
    }

    public class LoginConfig : ILoginConfig
    {
        public string Role { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}