namespace NextMassConsole
{
    public class ConfigFile : IConfigFile
    {
        public string BaseConnectionString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }
        public string HereAppId { get; set; }
        public string HereAppCode { get; set; }
    }
}
