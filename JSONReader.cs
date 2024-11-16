using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class JSONReader
{
    public static List<Dictionary<string, string>> ReadJSON(string jsonFilePath)
    {
        var records = new List<Dictionary<string, string>>();

        try
        {
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"Le fichier JSON '{jsonFilePath}' est introuvable.");
            }

            // Lecture et désérialisation du fichier JSON
            string jsonContent = File.ReadAllText(jsonFilePath);

            var jsonData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);

            if (jsonData == null || jsonData.Count == 0)
            {
                throw new Exception("Le fichier JSON est vide ou les données sont invalides.");
            }

            // Conversion des données en List<Dictionary<string, string>>
            foreach (var entry in jsonData)
            {
                var record = new Dictionary<string, string>();

                foreach (var kvp in entry)
                {
                    // Gestion des listes de traductions
                    if (kvp.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Array)
                    {
                        record[kvp.Key] = string.Join(", ", jsonElement.EnumerateArray().Select(e => e.GetString()));
                    }
                    else
                    {
                        record[kvp.Key] = kvp.Value?.ToString() ?? string.Empty;
                    }
                }

                records.Add(record);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier JSON : {ex.Message}");
        }

        return records;
    }
}