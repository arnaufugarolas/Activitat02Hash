using System.Security.Cryptography;

namespace Activitat02Hash;

class Activitat02Hash
{ 
    [Obsolete("Obsolete")]
    static void Main(string[] args)
    {
        while (true)
            Menu();
    }


    [Obsolete("Obsolete")]
    public static void Menu()
    {
        Console.WriteLine("1. Generar hash\n2. Comprovar hash\n3. Sortir");
        short opcio = -1;
        while (opcio is < 1 or > 3)
        {
            Console.WriteLine("\nOpcio: ");
            opcio = Convert.ToInt16(Console.ReadLine());
        }
        
        switch (opcio)
        {
            case 1:
                GenerarHash();
                break;
            case 2:
                ComprovarHash();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opció incorrecta");
                break;
        }
    }

    [Obsolete("Obsolete")]
    private static void ComprovarHash()
    {
        string? fileName = "";
        while (string.Equals(fileName, "", StringComparison.Ordinal))
        {
            Console.Write("Nom del fitxer: ");
            fileName = Console.ReadLine();
        }
        
        byte[]? data = null;
        
        try
        {
            if (fileName != null) data = GetHash(File.ReadAllBytes(fileName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        byte[]? hash = null;
        
        try
        {
            if (fileName != null) hash = File.ReadAllBytes(fileName + ".hash");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        string dataHash = "";
        if (data != null)
        {
            dataHash = BitConverter.ToString(data).Replace("-", "").ToLower();
        }

        string hashHash = "";
        if (hash != null)
        {
            hashHash = BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        if (dataHash.Equals(hashHash))
        {
            Console.WriteLine("El hash del fitxer és correcte");
        } else
        {
            Console.WriteLine("El hash del fitxer no és correcte");
        }

    }

    [Obsolete("Obsolete")]
    private static void GenerarHash()
    {
        string? fileName = "";
        while (string.Equals(fileName, "", StringComparison.Ordinal))
        {
            Console.Write("Nom del fitxer: ");
            fileName = Console.ReadLine();
        }

        byte[]? data = null;
        
        try
        {
            if (fileName != null) data = GetHash(File.ReadAllBytes(fileName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        if (data != null)
        {
            File.WriteAllBytes(fileName + ".hash", data);
        }
    }

    [Obsolete("Obsolete")]
    public static byte[] GetHash(byte[] bytesIn)
    {
        var sha512 = new SHA512Managed();
        var hashResult = sha512.ComputeHash(bytesIn);
        
        sha512.Dispose();
        return hashResult;
    }
}