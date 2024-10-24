using System;
using System.Collections.Generic;
using System.IO;

class CSVReader
{
    public static List<Dictionary<string, string>> ReadCSV(string strPathFile)
    {
        // Création de la liste de dictionnaires pour stocker les données
        var records = new List<Dictionary<string, string>>();

        try
        {
            // Lecture du fichier
            using (StreamReader sr = new StreamReader(strPathFile))
            {
                // Lecture de la première ligne pour obtenir les en-têtes
                string headerLine = sr.ReadLine();
                if (string.IsNullOrEmpty(headerLine))
                    throw new Exception("Le fichier CSV est vide ou incorrect.");

                string[] headers = headerLine.Split(',');

                // Lecture de chaque ligne et ajout dans la liste de dictionnaires
                while (!sr.EndOfStream)
                {
                    // Lecture de la ligne
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] rows = line.Split(',');

                    // // Vérification du nombre de colonnes
                    // if (rows.Length != headers.Length)
                    // {
                    //     Console.WriteLine("Ligne ignorée car le nombre de colonnes ne correspond pas.");
                    //     continue;
                    // }

                    // Création d'un dictionnaire pour chaque ligne
                    var record = new Dictionary<string, string>();

                    // Remplissage du dictionnaire avec les données de la ligne
                    for (int i = 0; i < headers.Length; i++)
                    {
                        record[headers[i]] = rows[i];
                    }

                    // Ajout du dictionnaire à la liste principale
                    records.Add(record);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Erreur : Le fichier spécifié n'a pas été trouvé. Détails : {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier : {ex.Message}");
        }

        // Retour des données
        return records;
    }
}