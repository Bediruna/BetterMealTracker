using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Searching for banana products...");
        await OFFDataTools.SearchProducts("banana");
    }
}