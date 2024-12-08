namespace DictionnaireZhFR;
public class GetAllInformationCommand : CommandBase
{

    public override string Execute(string word)
    {
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            ChineseCharacterType type;

            if (entry["Caractère Simplifié"] == word)
            {
                type = ChineseCharacterType.Simplified;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Traduction"]}";
            }
            else if (entry["Traduction"] == word)
            {
                type = ChineseCharacterType.FrenchTranslation;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLe pinyin : {entry["Pinyin"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
            }
            else if (entry["Pinyin"] == word)
            {
                type = ChineseCharacterType.Pinyin;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Le sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLa traduction : {entry["Traduction"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
            }
            else if (entry["Caractère Traditionnel"] == word)
            {
                type = ChineseCharacterType.Traditional;
                Console.WriteLine($"Type de caractère analysé : {type}");

                return $"Informations pour {word} :\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Traduction"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
            }
        }

        // Si aucun résultat n'est trouvé
        string message = $"Aucune information trouvée pour '{word}'.";
        Console.WriteLine(message);
        return message;
    }
}