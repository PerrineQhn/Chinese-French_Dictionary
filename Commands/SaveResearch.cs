namespace DictionnaireZhFR;

public class SaveResearch
{
    private readonly string folderPath = "Output";
    private readonly string filePath;

    public SaveResearch()
    {
        // Créer le dossier si nécessaire
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Définir le chemin complet du fichier
        filePath = Path.Combine(folderPath, "searches.txt");
    }

    public void Save(string command, string word, string result)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{DateTime.Now}: Commande = {command}, Mot = {word}");
                sw.WriteLine($"Résultat : {result}");
                sw.WriteLine(new string('-', 50)); // Séparation pour plus de lisibilité
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde de la recherche : {ex.Message}");
        }
    }
}