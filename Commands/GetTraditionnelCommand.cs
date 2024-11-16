public class GetTraditionalCommand
{
    public string GetTraditional(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simpl"] == chineseWord || entry["Pinyin"] == chineseWord)
            {
                string result = $"Caractère traditionnel pour '{chineseWord}' : {entry["Trad"]}";
                Console.WriteLine(result);
                return result;
            }
        }

        string noResultMessage = $"Aucun caractère traditionnel trouvé pour '{chineseWord}'.";
        Console.WriteLine(noResultMessage);
        return noResultMessage;
    }
}