namespace DictionnaireZhFR;

public abstract class CommandBase
{
    // Accès au dictionnaire (commun à toutes les commandes)
    protected Dictionnaire dictionnaire = new Dictionnaire();

    // Méthode abstraite que chaque commande doit implémenter
    public abstract string Execute(string input);
}