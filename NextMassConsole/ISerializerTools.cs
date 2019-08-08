namespace NextMassConsole
{
    public interface ISerializerTools
    {
        T ReadFile<T>(string filename);
        void WriteFile<T>(T file, string filename);
    }
}