using System.Text.Json;

namespace DictionnaireZhFR;

class JSONReader
{
    private LocalizationService _localizationService;

    public JSONReader(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    public List<Dictionary<string, string>> ReadJSON(string jsonFilePath)
    {
        List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();

        try
        {
            // Vérifier si le fichier existe
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine(_localizationService.GetTextArg("FileNotFound", jsonFilePath));
                return records;
            }

            // Lire le contenu du fichier JSON
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Désérialiser les données
            List<Dictionary<string, object>> jsonData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);

            if (jsonData == null || jsonData.Count == 0)
            {
                Console.WriteLine(_localizationService.GetText("EmptyOrInvalidJSON"));
                return records;
            }

            // Traiter les données
            foreach (Dictionary<string, object> entry in jsonData)
            {
                Dictionary<string, string> record = new Dictionary<string, string>();

                foreach (KeyValuePair<string, object> kvp in entry)
                {
                    // Convertir les valeurs en texte, y compris les listes
                    if (kvp.Value is JsonElement element && element.ValueKind == JsonValueKind.Array)
                    {
                        record[kvp.Key] = string.Join(", ", element.EnumerateArray().Select(e => e.GetString()));
                    }
                    else
                    {
                        record[kvp.Key] = kvp.Value?.ToString() ?? "";
                    }
                }

                records.Add(record);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(_localizationService.GetText("Error") + $" : {ex.Message}");
        }

        return records;
    }
}