namespace DictionnaireZhFR;

public class ReadFileCommand : CommandBase
{
    private readonly LocalizationService _localizationService;

    public ReadFileCommand(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public override string Execute(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine(_localizationService.GetTextArg("FileNotFound", filepath));
            // Console.WriteLine($"Le fichier '{filepath}' est introuvable.");
            return _localizationService.GetTextArg("FileNotFound", filepath);
        }    

        try
        {
            string content = File.ReadAllText(filepath);
            Console.WriteLine(content);
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine(_localizationService.GetText("Error") + $" : {ex.Message}");
            return $"Erreur : {ex.Message}";
        }
    }

}