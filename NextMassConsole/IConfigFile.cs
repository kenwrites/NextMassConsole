namespace NextMassConsole
{
    public interface IConfigFile
    {
        string BaseConnectionString { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}