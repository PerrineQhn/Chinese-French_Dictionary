namespace DictionnaireZhFR;

public abstract class CommandBase
{
    private readonly LocalizationService _localizationService;

    public CommandBase(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    // Accès au dictionnaire (commun à toutes les commandes)
    protected Dictionnaire dictionnaire = new Dictionnaire(new LocalizationService());
    protected string[] arguments;

    public CommandBase()
    {
    }

    public CommandBase(string[] commandArgument)
    {
        arguments = commandArgument;
    }

    // Méthode abstraite que chaque commande doit implémenter et retourner une chaîne
    public abstract string Execute(string input);

}