using System.Threading.Tasks;
using Base64;

class Program
{
    public static async Task Main(string[] args)
    {
        string filePath = string.Empty;
        if (!args.Any())
        {
            while (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Escriba la ruta del archivo que desea convertir a 'base64'");
                filePath = Console.ReadLine() ?? "";
            }
        }
        else
        {
            filePath = args[0];
        }

        try
        {
            var convertion = new ToBase64(filePath);
            await convertion.ConvertToBase64().ToFile();
            Console.WriteLine(convertion.base64Content);
            Console.WriteLine("El archivo fue convertido a base64 y se guardo en tu ruta actual");
        }
        catch (Exception ex)
        {
            Console.WriteLine("No fue posbile convertir el archivo a base64");
            Console.WriteLine(ex.Message);
        }
    }
}
