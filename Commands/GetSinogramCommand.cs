public class GetSinogramCommand
{
    // Récupere le sinogramme d'un mot français donné en argument
    
    public void GetSimplifier(string frenchWord)
    {
        Dictionnaire dictionnaire = new Dictionnaire();
        
        Console.WriteLine("Recherche du sinogramme...");

        var data = dictionnaire.ObtenirDonneesDictionnaire();

        List<(string Sinogram, string Pinyin)> sinograms = new List<(string, string)>();

        foreach (var entry in data)
        {
            
            if (entry["Traduction"].Contains(frenchWord))
            {
                sinograms.Add((entry["Simplifier"], entry["Pinyin"]));
            }

        }
        if (sinograms.Count == 0)
        {
            Console.WriteLine("Aucun sinogramme trouvé pour ce mot.");
        }
        else if (sinograms.Count == 1)
        {
            var (sinogram, pinyin) = sinograms[0];
            Console.WriteLine($"Le sinogramme pour '{frenchWord}' est : {sinogram} ({pinyin})");
        }
        else
        {
            Console.WriteLine($"Plusieurs sinogrammes trouvés pour '{frenchWord}' :");
            foreach (var (sinogram, pinyin) in sinograms)
            {
                Console.WriteLine($"{sinogram} ({pinyin})");
            }
        }
    }
}