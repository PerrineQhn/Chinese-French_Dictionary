public class GetTraditionalCommand
{
    public void GetTraditional(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simplifier"] == chineseWord || entry["Pinyin"] == chineseWord)
            {
                Console.WriteLine($"Le sinogramme traditionnel pour {chineseWord} est : {entry["Traditionnel"]}");
            }
        }   
        
    }
}