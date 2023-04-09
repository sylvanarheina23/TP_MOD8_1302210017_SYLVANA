using System;
using System.Text.Json;

public class AppConfig
{
    public CovidConfig covidConfig;
    private string filePath;
    private const string filepath = @"covid_config.json";

    public AppConfig()
    {
        try
        {
            readConfigFile();
        }
        catch
        {
            setDefault();
            writeConfigFile();
        }
    }

    private CovidConfig readConfigFile()
    {
        string readResult = File.ReadAllText(filePath);
        covidConfig = JsonSerializer.Deserialize<CovidConfig>(readResult);
        return covidConfig;
    }

    private void setDefault()
    {
        string tolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        string terima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        covidConfig = new CovidConfig("celcius", 14, tolak, terima);
    }

    private void writeConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        String writeText = JsonSerializer.Serialize(covidConfig, options);
        File.WriteAllText(filepath, writeText);
    }
}