using System;
using System.Collections.Generic;

class Dictionnaire
{
    public List<Dictionary<string, string>> ObtenirDonneesDictionnaire()
    {
        string filePath = "Data/cfdict.json";

        // Appel à JSONReader pour lire et traiter le fichier JSON
        var data = JSONReader.ReadJSON(filePath);

        if (data == null || data.Count == 0)
        {
            Console.WriteLine("Aucune donnée trouvée dans le fichier JSON.");
            return new List<Dictionary<string, string>>();
        }

        // Débogage (optionnel)
        // Console.WriteLine("Contenu du dictionnaire chargé depuis le JSON :");
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