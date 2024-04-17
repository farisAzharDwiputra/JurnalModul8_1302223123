using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class BankTransferConfig
{

	public string lang { get; set; }
	public class Transfers {
		public string threshold { get; set; }
		public string low_fee { get; set; }
		public string high_fee { get; set; }

	}
	public  List<string> methods { get; set; }
	public class konfirmasi
	{
		public string en { get; set; }
		public string id { get; set; }
	}
	public Transfers transfer { get; set; }
	public konfirmasi confirmation { get; set; }

	public BankTransferConfig() { }
}

	public class TransferConfig
	{
	public BankTransferConfig config;

	private const string filePath = "C:\\Users\\LENOVO\\Desktop\\semester 4\\Kontruksi Perangkat Lunak (KPL)\\Modul8_1302223123\\Modul8_1302223123\\bank_transfer_config.json";

    public TransferConfig()
	{
		try
		{
			ReadConfigJson();
		}
		catch
		{
			PrintConfig();

            Default();
		}

	}

	public void ReadConfigJson()
	{
		string configDataJson = File.ReadAllText(filePath);
		config = JsonSerializer.Deserialize<BankTransferConfig>(configDataJson);

	}
        public void Default()
	{
		
		config = new BankTransferConfig();

		config.lang = "en";
		config.transfer.threshold = "25000000";
        config.transfer.low_fee = "6500";
		config.transfer.high_fee = "15000";
		config.methods = ["RTO(real - time)", "SKN", "RTGS", "BI FAST"];
        config.confirmation.en = "yes";
		config.confirmation.id = "ya";
    }

    public void PrintConfig()
    {
        JsonSerializerOptions Option = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        string output = JsonSerializer.Serialize(config);
        File.WriteAllText(filePath, output);

    }

	public void kondisiConfig1()
	{
		string input = Console.ReadLine();
		if(input == "en")
		{
			Console.Write("Please insert the amount of money to transfer: ");
		}
		else if(input == "id")
		{
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
		}
	}

    public void kondisiConfig2()
    {
        string input = Console.ReadLine();
        if (input == "en")
        {
			config.confirmation.en = "Select transfer method :";
        }
        else if (input == "id")
        {
            config.confirmation.id = "Pilih metode transfer :";
        }
    }

	public void Cek(string input)
	{
		int length = input.Length;
		if (input.Length <= config.transfer.threshold.Length)
		{
			Console.WriteLine($"Transaksi yang anda lakukan {config.transfer.low_fee} ");
		}else if (input.Length >= config.transfer.threshold.Length)
		{
            Console.WriteLine($"Transaksi yang anda lakukan {config.transfer.high_fee} ");
        }
	}

}