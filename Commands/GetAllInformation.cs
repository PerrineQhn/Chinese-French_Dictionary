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

        foreach (Dictionary<string, string> entry in data)
        {
            ChineseCharacterType type;

            if (entry["Simpl"] == word)
            {
                type = ChineseCharacterType.Simplified;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe sinogramme traditionnel est : {entry["Simpl"]}\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Translations"]}";
            }
            else if (entry["Translations"] == word)
            {
                type = ChineseCharacterType.FrenchTranslation;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe sinogramme traditionnel est : {entry["Trad"]}\nLe pinyin : {entry["Pinyin"]}\nLe sinogramme simplifié : {entry["Simpl"]}";
            }
            else if (entry["Pinyin"] == word || withoutTones == word || accentedInput == word)
            {
                type = ChineseCharacterType.Pinyin;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Le sinogramme traditionnel est : {entry["Trad"]}\nLa traduction : {entry["Translations"]}\nLe sinogramme simplifié : {entry["Simpl"]}";
            }
            else if (entry["Trad"] == word)
            {
                type = ChineseCharacterType.Traditional;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Translations"]}\nLe sinogramme simplifié : {entry["Simpl"]}";
            }
        }

        // Si aucun résultat n'est trouvé
        string message = $"Aucune information trouvée pour '{word}'.";
        Console.WriteLine(message);
        return message;
    }
}