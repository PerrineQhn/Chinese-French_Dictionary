public class GetSinogramCommand
{
    // Récupere le sinogramme d'un mot français donné en argument
    
    public string GetSimplifier(string frenchWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        Console.WriteLine("Recherche du sinogramme...");

        var data = dictionnaire.ObtenirDonneesDictionnaire();

        List<(string Sinogram, string Pinyin)> sinograms = new List<(string, string)>();

        foreach (var entry in data)
        {
            
            if (entry["Translations"].Contains(frenchWord))
            {
                sinograms.Add((entry["Simpl"], entry["Pinyin"]));
            }

        }
        if (sinograms.Count == 0)
        {
            string message = $"Aucun sinogramme trouvé pour '{frenchWord}'.";
            Console.WriteLine(message);
            return message;
        }

        string result = string.Join("\n", sinograms);
        Console.WriteLine($"Sinogrammes trouvés pour '{frenchWord}':\n{result}");
        return result;
    }
}