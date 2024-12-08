namespace DictionnaireZhFR
{
    public class WordInfo
    {
        public string Simplified { get; set; }
        public string Traditional { get; set; }
        public string Pinyin { get; set; }
        public string Translations { get; set; }

        public WordInfo(string simplified, string traditional, string pinyin, string translations)
        {
            Simplified = simplified;
            Traditional = traditional;
            Pinyin = pinyin;
            Translations = translations;
        }

        public override string ToString()
        {
            return $"Simplified: {Simplified}, Traditional: {Traditional}, Pinyin: {Pinyin}, Translations: {Translations}";
        }
    }
}