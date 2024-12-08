namespace DictionnaireZhFR
{
    public class GetFrenchCommand : CommandBase
    {
        public override string Execute(string chineseWord)
        {
            var data = dictionnaire.ObtenirDonneesDictionnaire();

            foreach (var entry in data)
            {
                if (entry["Simpl"] == chineseWord || entry["Trad"] == chineseWord || entry["Pinyin"] == chineseWord)
                {
                    // Créer une instance de WordInfo pour la correspondance trouvée
                    var wordInfo = new WordInfo(
                        entry["Simpl"],
                        entry["Trad"],
                        entry["Pinyin"],
                        entry["Translations"]
                    );

                    string result = $"Traduction française pour '{chineseWord}': {wordInfo.Translations}";
                    Console.WriteLine(result);
                    return result;
                }
            }

            string message = $"Aucune traduction trouvée pour '{chineseWord}'.";
            Console.WriteLine(message);
            return message;
        }
    }
}