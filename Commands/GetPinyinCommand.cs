namespace DictionnaireZhFR;

public class GetPinyinCommand : CommandBase
{
    private readonly LocalizationService _localizationService;

    public GetPinyinCommand(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public override string Execute(string chineseWord)
    {
        List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (Dictionary<string, string> entry in data)
        {
            if (entry["Simpl"] == chineseWord || entry["Trad"] == chineseWord)
            {
                // Créer une instance de WordInfo pour la correspondance trouvée
                WordInfo wordInfo = new WordInfo(
                    entry["Simpl"],
                    entry["Trad"],
                    entry["Pinyin"],
                    entry["Translations"]
                );

                string result = _localizationService.GetText("PinyinFound") + $" {wordInfo.Pinyin} ";
                // string result = $"Pinyin pour '{chineseWord}': {wordInfo.Pinyin} ";
                Console.WriteLine(result);
                return result;
            }
        }

        string message = _localizationService.GetText("PinyinNotFound") + $" '{chineseWord}'.";
        // string message = $"Aucun Pinyin trouvé pour '{chineseWord}'.";
        Console.WriteLine(message);
        return message;
    }
}
