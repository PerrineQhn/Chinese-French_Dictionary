namespace DictionnaireZhFR
{
    public class WordInfo
    {
        public string Simplified { get; set; }
        public string Traditional { get; set; }
        public string Pinyin { get; set; }
        public string Translations { get; set; }

        // Constructeur vide
        public WordInfo()
        {
        }

        // Constructeur pour un seul sinogramme
        public WordInfo(string sinogram)
        {
            Simplified = sinogram;
        }

        // Constructeur pour simplifié et traditionnel
        public WordInfo(string simplified, string traditional)
        {
            Simplified = simplified;
            Traditional = traditional;
        }

        // Constructeur complet
        public WordInfo(string simplified, string traditional, string pinyin, string translations)
        {
            Simplified = simplified;
            Traditional = traditional;
            Pinyin = PinyinUtils.ConvertNumericPinyinToAccented(pinyin);
            Translations = translations;
        }

        // Méthode ToString pour un seul sinogramme
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Traditional))
            {
                return Traditional; // Priorise la version traditionnelle.
            }
            if (!string.IsNullOrEmpty(Simplified))
            {
                return Simplified; // Utilise la version simplifiée si traditionnelle est vide.
            }
            return $"Simplified: {Simplified}, Traditional: {Traditional}, Pinyin: {Pinyin}, Translations: {Translations}";
        }
    }
}