using FuzzySharp;

namespace DictionnaireZhFR;
public class GetAllInformationCommand : CommandBase
{
    private readonly PinyinUtils _pinyinUtils = new PinyinUtils();

    public GetAllInformationCommand(LocalizationService localizationService) : base(localizationService)
    {
    }

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
            if (entry["Translations"].Contains(normalizedInput))
            {
                type = ChineseCharacterType.Translation;
                results.Add(_localizationService.GetTextArg("Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLe pinyin : {4}\nLa traduction : {5}", word, type, entry["Trad"], entry["Simpl"], entry["Pinyin"], entry["Translations"]));
            }

            else if (entry["Simpl"].Contains(normalizedInput))
            {
                type = ChineseCharacterType.Simplified;
                results.Add(_localizationService.GetTextArg("Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe pinyin : {3}\nLa traduction : {4}\n", word, type, entry["Trad"], entry["Pinyin"], entry["Translations"]));
            }
            
            else if (entry["Trad"].Contains(normalizedInput))
            {
                type = ChineseCharacterType.Traditional;
                results.Add(_localizationService.GetTextArg("Informations pour '{0}' ({1}) :\nLe sinogramme simplifié : {2}\nLe pinyin : {3}\nLa traduction : {4}\n", word, type, entry["Simpl"], entry["Pinyin"], entry["Translations"]));
            }
            
            else if (entry["Pinyin"] == word || entry["Pinyin"] != null && entry["Pinyin"].Split(' ').Contains(word)) 
            {
                type = ChineseCharacterType.Pinyin;
                results.Add(_localizationService.GetTextArg("Informations pour '{0}' ({1}) :\nLe sinogramme traditionnel est : {2}\nLe sinogramme simplifié : {3}\nLa traduction : {4}\n", word, type, entry["Trad"], entry["Simpl"], entry["Translations"]));
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
            Console.WriteLine(_localizationService.GetTextArg("Aucune information trouvée pour '{0}'. Suggestions : {1}", word, suggestionList));
            return _localizationService.GetTextArg("Aucune information trouvée pour '{0}'. Suggestions : {1}", word, suggestionList);
        }
        else
        {
            Console.WriteLine(_localizationService.GetTextArg("Aucune information trouvée pour '{0}'.", word));
            return _localizationService.GetTextArg("Aucune information trouvée pour '{0}'.", word);
        }
    }
    private string GetTranslations(string translations)
    {

        string translate = translations.Replace(",", " ");      
        return translate;
    }
}