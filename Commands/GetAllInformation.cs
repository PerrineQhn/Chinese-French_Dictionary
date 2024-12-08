namespace DictionnaireZhFR;
public class GetAllInformationCommand : CommandBase
{

    public override string Execute(string word)
    {
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        // Normaliser l'entrée utilisateur
        string normalizedInput = word.Trim().ToLower();
        string accentedInput = PinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
        string withoutTones = PinyinUtils.RemovePinyinTones(accentedInput);

        foreach (var entry in data)
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