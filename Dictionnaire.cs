namespace DictionnaireZhFR;
public class Dictionnaire
{
    private readonly LocalizationService _localizationService;

    public Dictionnaire(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    public List<Dictionary<string, string>> ObtenirDonneesDictionnaire()
    {
        string filePath = "Data/cfdict.json";

        // Appel à JSONReader pour lire et traiter le fichier JSON
        JSONReader reader = new JSONReader(localizationService: _localizationService);
        List<Dictionary<string, string>> data = reader.ReadJSON(filePath);

        if (data == null || data.Count == 0)
        {
            throw new DictionnaireException(_localizationService.GetText("EmptyOrInvalidJSON"));
        }

        // Débogage (optionnel)
        // Console.WriteLine("Contenu du dictionnaire chargé depuis le JSON :");
        // foreach (var entry in data)
        // {
        //     foreach (var key in entry.Keys)
        //     {
        //         Console.Write($"{key}: {entry[key]}  ");
        //     }
        //     Console.WriteLine();
        // }

        return data;
    }
}