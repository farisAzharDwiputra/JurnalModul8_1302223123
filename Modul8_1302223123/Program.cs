// See https://aka.ms/new-console-template for more information

using static BankTransferConfig;

internal class program
{
    public static void Main(string[] args)
    {
        TransferConfig Config = new TransferConfig();
        string inputBaru;
        TransferConfig Count = new TransferConfig();

        Config.kondisiConfig1();
        inputBaru = Console.ReadLine();

        Config.Cek(inputBaru);
        
        Console.WriteLine(inputBaru + 6000);

        Config.kondisiConfig2();
    }
}