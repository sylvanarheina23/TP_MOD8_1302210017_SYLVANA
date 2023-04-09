// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main(String[]args)
    {
        AppConfig appConfig = new AppConfig();

        appConfig.covidConfig.ubahSatuan();

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai {0:s}:", appConfig.covidConfig.satuan_suhu);
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        try
        {
            if (hari < 0)
            {
                throw new ArgumentException("Invalid");
            }

            if (appConfig.covidConfig.satuan_suhu == "celcius")
            {
                if(suhu >= 36.5 && suhu <= 37.5 && hari < appConfig.covidConfig.batas_hari_demam)
                {
                    Console.WriteLine(appConfig.covidConfig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(appConfig.covidConfig.pesan_ditolak);
                }
            }else
            {
                if(suhu >= 97.7 && suhu <= 99.5 && hari < appConfig.covidConfig.batas_hari_demam)
                {
                    Console.WriteLine(appConfig.covidConfig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(appConfig.covidConfig.pesan_ditolak);
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

