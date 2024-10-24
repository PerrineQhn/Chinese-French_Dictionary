class Dictionnaire
{
    public List<Dictionary<string, string>> ObtenirDonneesDictionnaire()
    {
        var data = CSVReader.ReadCSV("Dico_Chinois_Francais.csv");

        // // Afficher les données lues pour le débogage
        // Console.WriteLine("Contenu du dictionnaire :");
        // foreach (var entry in data)
        // {
        //     foreach (var key in entry.Keys)
        //     {
        //         Console.Write($"{key}: {entry[key]}  ");
        //     }
        //     Console.WriteLine();
        // }

        return data;
    }
}