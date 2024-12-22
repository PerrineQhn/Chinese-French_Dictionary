using FuzzySharp;

namespace DictionnaireZhFR;
public class GetAllInformationCommand : CommandBase
{
    private readonly PinyinUtils _pinyinUtils = new PinyinUtils();

    public override string Execute(string word)
    {
        List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();

        // Normaliser l'entrée utilisateur
        string normalizedInput = word.Trim().ToLower();
        string accentedInput = _pinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
        string withoutTones = _pinyinUtils.RemovePinyinTones(accentedInput);

        List<string> results = new List<string>();

        foreach (Dictionary<string, string> entry in data)
        {
            ChineseCharacterType type;
            if (entry["Translations"] == word )
            {
                type = ChineseCharacterType.FrenchTranslation;
                results.Add($"Informations pour {word} ({type}) :\nLe sinogramme traditionnel est : {entry["Trad"]}\nLe pinyin : {entry["Pinyin"]}\nLe sinogramme simplifié : {entry["Simpl"]}\n");
            }

            else if (entry["Simpl"] == normalizedInput)
            {
                type = ChineseCharacterType.Simplified;
                results.Add($"Informations pour {word} ({type}) :\nLe sinogramme traditionnel est : {entry["Trad"]}\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Translations"]}\n");
            }
            
            else if (entry["Trad"] == normalizedInput)
            {
                type = ChineseCharacterType.Traditional;
                results.Add($"Informations pour {word} ({type}) :\nLe sinogramme simplifié : {entry["Simpl"]}\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Translations"]}\n");
            }
            
            else if (entry["Pinyin"] == word || entry["Pinyin"] != null && entry["Pinyin"].Split(' ').Contains(word)) 
            {
                type = ChineseCharacterType.Pinyin;
                results.Add($"Informations pour {word} ({type}) :\nLe sinogramme traditionnel est : {entry["Trad"]}\nLe sinogramme simplifié : {entry["Simpl"]}\nLa traduction : {entry["Translations"]}\n");
            }
        }

        if (results.Count > 0)
        {
            string output = string.Join("\n", results);
            Console.WriteLine(output);
            return output;
        }

        // Si aucun résultat n'est trouvé recherche avec une similarité de 80%
        List<string> allWords = data.SelectMany(entry =>
                                            GetTranslations(entry["Translations"])
                                            .Split(' ')
                                            .Concat(new[] { entry["Simpl"], entry["Trad"], entry["Pinyin"] }))
                                    .Distinct()
                                    .ToList();
                                

        var suggestions = Process.ExtractTop(normalizedInput, allWords, cutoff: 80, limit: 10);

        if (suggestions.Count() > 0)
        {
            string suggestionList = string.Join(", ", suggestions.Select(s => s.Value));
            Console.WriteLine($"Aucune information trouvée pour '{word}'. Suggestions : {suggestionList}");
            return $"Aucune information trouvée pour '{word}'. Suggestions : {suggestionList}";
        }
        else
        {
            Console.WriteLine($"Aucune information trouvée pour '{word}'.");
            return $"Aucune information trouvée pour '{word}'.";
        }
    }
    private string GetTranslations(string translations)
    {

        string translate = translations.Replace(",", " ");      
        return translate;
    }
}