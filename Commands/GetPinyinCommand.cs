public class GetPinyinCommand
{
    public void GetPinyin(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simplifier"] == chineseWord || entry["Traditionnel"] == chineseWord)
            {
                Console.WriteLine($"Le pinyin pour {chineseWord} est : {entry["Pinyin"]}");
            }
        }   
    }
}