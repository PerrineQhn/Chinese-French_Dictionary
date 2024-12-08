namespace DictionnaireZhFR
{
    public class GetTraditionalCommand : CommandBase
    {
        public override string Execute(string input)
        {
            var data = dictionnaire.ObtenirDonneesDictionnaire();

            // Normaliser l'entrée
            string normalizedInput = input.Trim().ToLower();
            string accentedInput = PinyinUtils.ConvertNumericPinyinToAccented(normalizedInput);
            string withoutTones = PinyinUtils.RemovePinyinTones(accentedInput);

            // Console.WriteLine($"Normalized Input: {normalizedInput}");
            // Console.WriteLine($"Accented Input: {accentedInput}");
            // Console.WriteLine($"Without Tones: {withoutTones}");

            // Liste pour stocker les résultats
            List<WordInfo> results = new List<WordInfo>();

            // Recherche dans le dictionnaire
            foreach (var entry in data)
            {
                string entryPinyin = entry["Pinyin"];
                string entryPinyinNoTones = PinyinUtils.RemovePinyinTones(PinyinUtils.ConvertNumericPinyinToAccented(entryPinyin));

                // Comparaison avec différentes formes de pinyin ou caractères chinois
                if (entry["Simpl"] == input || entryPinyin == input)
                {
                    results.Add(CreateWordInfo(entry));
                }
                else if (entryPinyin == normalizedInput)
                {
                    results.Add(CreateWordInfo(entry));
                }
                else if (entryPinyinNoTones == withoutTones)
                {
                    results.Add(CreateWordInfo(entry));
                }
            }

            if (results.Count == 0)
            {
                string message = $"Aucun caractère traditionnel trouvé pour '{input}'.";
                Console.WriteLine(message);
                return message;
            }

            // Générer un message contenant tous les résultats trouvés
            string output = string.Join("\n", results.Select(w => w.ToString()));
            Console.WriteLine($"Caractères traditionnels trouvés pour '{input}':\n{output}");
            return output;
        }

        private WordInfo CreateWordInfo(Dictionary<string, string> entry)
        {
            return new WordInfo(
                $" Traditionnel: {entry["Trad"]}"
            );
        }

        // public override string GetHelp()
        // {
        //     return "Obtenir le sinogramme traditionnel d'un mot chinois en entrant le sinogramme simplifié ou le pinyin.";
        // }
    }
}