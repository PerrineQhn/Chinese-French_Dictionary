public class GetFrenchCommand
{
    // Récupere la traduction française d'un mot chinois donné en argument

    public string Traduction(string chineseWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();

        foreach (var entry in data)
        {
            if (entry["Simpl"] == chineseWord || entry["Trad"] == chineseWord || entry["Pinyin"] == chineseWord)
            {
                string result = $"Traduction française pour '{chineseWord}' : {entry["Translations"]}";
                Console.WriteLine(result);
                return result;
            }
        }   
        string message = $"Aucune traduction trouvée pour '{chineseWord}'.";
        Console.WriteLine(message);
        return message;
        
    }

}