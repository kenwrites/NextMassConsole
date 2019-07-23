namespace NextMassConsole
{
    public interface IConfig
    {
        ConfigFile ReadConfigFile(string filename);
        void WriteConfigFile(ConfigFile file, string filename);
    }
}