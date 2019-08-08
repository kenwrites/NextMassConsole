namespace NextMassConsole
{
    public interface IConfigFile
    {
        string BaseConnectionString { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        string InitialCatalog { get; set; }
        string HereAppId { get; set; }
        string HereAppCode { get; set; }
    }
}