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

                List<Dictionary<string, object>> dictionnary = new List<Dictionary<string, object>>();

                foreach (XElement word in doc.Descendants("word"))
                {
                    string GetElementValue(XElement parent, string elementName)
                    {
                        XElement element = parent.Element(elementName);
                        if (element != null)
                        {
                            return element.Value;
                        }
                        return string.Empty;
                    }

                    // Utilisation de la méthode pour obtenir les valeurs
                    string simpl = GetElementValue(word, "simp");
                    string trad = GetElementValue(word, "trad");
                    string pinyin = GetElementValue(word, "py");

                    List<string> traductions = word.Descendants("fr").Select(fr => fr.Value).ToList();

                    Dictionary<string, object> entry = new Dictionary<string, object>
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
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };
            string json = JsonSerializer.Serialize(words, options);
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Fichier JSON créé avec succès : {jsonFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde du fichier JSON : {ex.Message}");
        }
    }
}