public class GetAllInformationCommand
{
    public string GetAllInformation(string Word)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();
        
        bool found = false;

        foreach (var entry in data)
        {
            if (entry["Caractère Simplifié"] == Word)
            {

                string result = $"Informations pour {Word} :\nLe sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Traduction"]}";
                Console.WriteLine(result);
                found = true;
                break;
            }
            else if (entry["Traduction"] == Word)
            {
                string result = $"Informations pour {Word} :\nLe sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLe pinyin : {entry["Pinyin"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
                Console.WriteLine(result);
                found = true;
                break;
            }
            else if (entry["Pinyin"] == Word)
            {
                string result = $"Le sinogramme traditionnel est : {entry["Caractère Traditionnel"]}\nLa traduction : {entry["Traduction"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
                Console.WriteLine(result);
                found = true;
                break;
            }
            else if (entry["Caractère Traditionnel"] == Word)
            {
                string result = $"Informations pour {Word} :\nLe pinyin : {entry["Pinyin"]}\nLa traduction : {entry["Traduction"]}\nLe sinogramme simplifié : {entry["Caractère Simplifié"]}";
                Console.WriteLine(result);
                found = true;
                break;
            }

        }   
        if (!found)
        {
            Console.WriteLine("Aucune information trouvée pour ce mot.");
        }

        string message = $"Aucune information trouvée pour '{Word}'.";
        return message;
    }
}