public class GetFrenchCommand
{
    // Récupere la traduction française d'un mot chinois donné en argument

    public void Traduction(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simplifier"] == chineseWord || entry["Traditionnel"] == chineseWord || entry["Pinyin"] == chineseWord)
            {
                Console.WriteLine($"La traduction française pour {chineseWord} est : {entry["Traduction"]}");
            }
        }   
        
    }
}