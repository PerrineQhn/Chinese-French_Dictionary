namespace DictionnaireZhFR;

public class SaveResearch
{
    private readonly string folderPath = "Output";
    private readonly string filePath;
    private readonly LocalizationService _localizationService;

    public SaveResearch(LocalizationService localizationService)
    {
        _localizationService = localizationService;

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
                sw.WriteLine(_localizationService.GetTextArg("{0} : Command = {1}, Word = {2}", DateTime.Now, command, word));
                sw.WriteLine(_localizationService.GetTextArg("Result : {0}", result));
                sw.WriteLine(new string('-', 50)); // Séparation pour plus de lisibilité
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(_localizationService.GetText("ErrorSavingSearch") + $" : {ex.Message}");
        }
    }
}