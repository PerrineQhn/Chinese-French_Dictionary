namespace DictionnaireZhFR
{
    public class GetTraditionalCommand : CommandBase
    {
        public override string Execute(string chineseWord)
        {
            var data = dictionnaire.ObtenirDonneesDictionnaire();

            foreach (var entry in data)
            {
                if (entry["Simpl"] == chineseWord || entry["Pinyin"] == chineseWord)
                {
                    // Créer une instance de WordInfo pour la correspondance trouvée
                    var wordInfo = new WordInfo(
                        entry["Simpl"],
                        entry["Trad"],
                        entry["Pinyin"],
                        entry["Translations"]
                    );

                    string result = $"Caractère traditionnel pour '{chineseWord}': {wordInfo.Traditional}";
                    Console.WriteLine(result);
                    return result;
                }
            }

            string message = $"Aucun caractère traditionnel trouvé pour '{chineseWord}'.";
            Console.WriteLine(message);
            return message;
        }
    }
}