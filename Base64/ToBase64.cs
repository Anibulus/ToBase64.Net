using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Base64;

public class ToBase64
{
    private string _filePath;
    private string? _currentPath;
    public string base64Content;

    public ToBase64(string filePath)
    {
        if (!Path.IsPathRooted(filePath))
        {
            _currentPath = PathService.CurrentDirectory();
            filePath = Path.Combine(_currentPath, filePath);
        }
        _filePath = filePath;
    }

    /// <summary>
    /// Lee el archivo y lo convierte a base64
    /// </summary>
    /// <returns></returns>
    public ToBase64 ConvertToBase64()
    {
        string result = string.Empty;
        if (!File.Exists(_filePath))
            Console.WriteLine($"El archivo no existe, se busco en la ruta {_filePath}");

        try
        {
            base64Content = ReadAndConvertToBase64(_filePath);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error al procesar el archivo. {exception.Message}");
        }

        return this;
    }

    /// <summary>
    /// Crea el archivo a partir del contenido en base64 y lo situa en donde se ejecuto el .dll
    /// </summary>
    /// <returns></returns>
    public async Task<ToBase64> ToFile()
    {
        FileInfo fileInfo = new FileInfo(_filePath);
        string nameFile = fileInfo.Name + ".txt";
        string path = Path.Combine(_currentPath, nameFile);
        if (File.Exists(path))
            File.Delete(path);

        // Write content
        writeContent(path, base64Content);

        return this;
    }

    Func<string, string> ReadAndConvertToBase64 = (path) =>
    {
        byte[] content = File.ReadAllBytes(path);
        string result = Convert.ToBase64String(content);
        return result;
    };

    Action<string, string> writeContent = async (string path, string content) =>
    {
        try
        {
            Stream file = File.Create(path);
            using (StreamWriter writer = new StreamWriter(file))
            {
                await writer.WriteLineAsync(content);
                writer.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
}
