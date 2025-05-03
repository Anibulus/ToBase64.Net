namespace Base64;

public static class PathService
{
    /// <summary>
    /// Retorna el directio en el que se encuentra el ejecutable.
    /// </summary>
    /// <returns></returns>
    public static string? ExecutionPath()
    {
        string executionPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var executableDirectory = Path.GetDirectoryName(executionPath);
        Console.WriteLine($"Directorio del ejecutable {executableDirectory}");
        return executableDirectory;
    }

    /// <summary>
    /// Retorna el directorio actual de trabajo. Es decir, desde donde se ejecuto.
    /// Por ejemplo, si fue llamado desde ~/Desktop
    /// </summary>
    /// <returns></returns>
    public static string CurrentDirectory()
    {
        string currentDirectory = Environment.CurrentDirectory;
        return currentDirectory;
    }
}
