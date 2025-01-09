namespace DictionnaireZhFR
{
    public class GetFrenchCommand : CommandBase
    {
        public GetFrenchCommand(LocalizationService localizationService) : base(localizationService)
        {
        }

        public override string Execute(string chineseWord)
        {
            List<Dictionary<string, string>> data = dictionnaire.ObtenirDonneesDictionnaire();

            foreach (Dictionary<string, string> entry in data)
            {
                if (entry["Simpl"] == chineseWord || entry["Trad"] == chineseWord || entry["Pinyin"] == chineseWord)
                {
                    // Créer une instance de WordInfo pour la correspondance trouvée
                    WordInfo wordInfo = new WordInfo(
                        entry["Simpl"],
                        entry["Trad"],
                        entry["Pinyin"],
                        entry["Translations"]
                    );

                    string result = _localizationService.GetText("FrenchTranslation") + $"'{chineseWord}': {wordInfo.Translations}";
                    Console.WriteLine(result);
                    return result;
                }
            }

            string message = _localizationService.GetText("NoTranslationFound") + $"'{chineseWord}'.";
            Console.WriteLine(message);
            return message;
        }
    }
}