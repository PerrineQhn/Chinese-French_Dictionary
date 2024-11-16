using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;

class Dictionnary_Creation
{
    public void CreateDictionnary_JSON(string xmlFilePath, string jsonFilePath)
    {
        try
        {
            if (!File.Exists(xmlFilePath))
            {
                Console.WriteLine($"Le fichier XML '{xmlFilePath}' est introuvable.");
                return;
            }

            using (StreamReader reader = new StreamReader(xmlFilePath, System.Text.Encoding.UTF8))
            {
                XDocument doc = XDocument.Load(reader);

                var dictionnary = new List<Dictionary<string, object>>();

                foreach (var word in doc.Descendants("word"))
                {
                    string simpl = word.Element("simp")?.Value ?? string.Empty;
                    string trad = word.Element("trad")?.Value ?? string.Empty;
                    string pinyin = word.Element("py")?.Value ?? string.Empty;

                    var traductions = word.Descendants("fr").Select(fr => fr.Value).ToList();

                    var entry = new Dictionary<string, object>
                    {
                        { "Simpl", simpl },
                        { "Trad", trad },
                        { "Pinyin", pinyin },
                        { "Translations", traductions }
                    };

                    dictionnary.Add(entry);
                }

                SaveToJson(dictionnary, jsonFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

    private void SaveToJson(List<Dictionary<string, object>> words, string jsonFilePath)
    {
        try
        {
            string json = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Fichier JSON créé avec succès : {jsonFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde du fichier JSON : {ex.Message}");
        }
    }
}