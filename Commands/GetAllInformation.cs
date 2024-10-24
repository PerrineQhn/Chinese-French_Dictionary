public class GetAllInformationCommand
{
    public void GetAllInformation(string Word)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        var data = dictionnaire.ObtenirDonneesDictionnaire();
        bool found = false;

        foreach (var entry in data)
        {
            if (entry["Simplifier"] == Word)
            {
                Console.WriteLine($"Informations pour {Word} :");
                Console.WriteLine($"Le sinogramme traditionnel est : {entry["Traditionnel"]}");
                Console.WriteLine($"Le pinyin : {entry["Pinyin"]}");
                Console.WriteLine($"La traduction : {entry["Traduction"]}");
                found = true;
                break;
            }
            else if (entry["Traduction"] == Word)
            {
                Console.WriteLine($"Informations pour {Word} :");
                Console.WriteLine($"Le sinogramme traditionnel est : {entry["Traditionnel"]}");
                Console.WriteLine($"Le pinyin : {entry["Pinyin"]}");
                Console.WriteLine($"Le sinogramme simplifié : {entry["Simplifier"]}");
                found = true;
                break;
            }
            else if (entry["Pinyin"] == Word)
            {
                Console.WriteLine($"Informations pour {Word} :");
                Console.WriteLine($"Le sinogramme traditionnel est : {entry["Traditionnel"]}");
                Console.WriteLine($"La traduction : {entry["Traduction"]}");
                Console.WriteLine($"Le sinogramme simplifié : {entry["Simplifier"]}");
                found = true;
                break;
            }
            else if (entry["Traditionnel"] == Word)
            {
                Console.WriteLine($"Informations pour {Word} :");
                Console.WriteLine($"Le pinyin : {entry["Pinyin"]}");
                Console.WriteLine($"La traduction : {entry["Traduction"]}");
                Console.WriteLine($"Le sinogramme simplifié : {entry["Simplifier"]}");
                found = true;
                break;
            }

        }   
        if (!found)
        {
            Console.WriteLine("Aucune information trouvée pour ce mot.");
        }
    }
}