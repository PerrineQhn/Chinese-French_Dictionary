namespace DictionnaireZhFR;

public class ChangeLanguageCommand : CommandBase
{
    LocalizationService localizationService;
    string newLang;

    public ChangeLanguageCommand(LocalizationService localizationService) : base(localizationService)
    {
        this.localizationService = localizationService;
    }

    public override string Execute(string input)
    {
        newLang = input;
        localizationService.ChangeLanguage(newLang);
        return _localizationService.GetTextArg("LanguageChanged", newLang);
    }
}