public class GetPinyinCommand
{
    public string GetPinyin(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simpl"] == chineseWord || entry["Trad"] == chineseWord)
            {
                string result = $"Pinyin pour '{chineseWord}' : {entry["Pinyin"]}";
                Console.WriteLine(result);
                return result;
            }
        }   
        string message = $"Aucun Pinyin trouvé pour '{chineseWord}'.";
        Console.WriteLine(message);
        return message;
    }
}