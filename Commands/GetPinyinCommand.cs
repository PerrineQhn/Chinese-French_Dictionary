namespace DictionnaireZhFR;

public class GetPinyinCommand : CommandBase
{
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

                string result = $"Pinyin pour '{chineseWord}': {wordInfo.Pinyin} ";
                Console.WriteLine(result);
                return result;
            }
        }

        string message = $"Aucun Pinyin trouvé pour '{chineseWord}'.";
        Console.WriteLine(message);
        return message;
    }
}
