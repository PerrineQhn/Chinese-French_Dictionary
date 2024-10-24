# Dictionnaire Chinois-Français

Ce projet est une application console en C# permettant de rechercher des informations dans un dictionnaire Chinois-Français à partir d'un fichier CSV. L'application offre des fonctionnalités telles que la recherche de sinogrammes, de pinyin, et de traductions, ainsi que l'affichage de toutes les informations associées à un mot donné.

## Fonctionnalités

- **GetSinogramCommand** : Recherche le sinogramme et son pinyin associé pour un mot français donné.
- **GetAllInformationCommand** : Récupère toutes les informations (sinogramme simplifié, sinogramme traditionnel, pinyin, traduction) pour un mot donné.
- **CommandInterpreter** : Interprète les commandes de l'utilisateur et exécute la fonction correspondante.

## Fichiers

- **Dico_Chinois_Francais.csv** : Fichier contenant le dictionnaire Chinois-Français avec les colonnes suivantes :
  - `Simplifier` : Sinogramme simplifié
  - `Traditionnel` : Sinogramme traditionnel
  - `Pinyin` : Transcription phonétique
  - `Categorie Grammaticale` : Catégorie grammaticale du mot
  - `Traduction` : Traduction française

- **Dictionnaire.cs** : Classe qui charge les données du dictionnaire à partir du fichier CSV et les stocke sous forme de liste de dictionnaires.
- **GetSinogramCommand.cs** : Classe qui permet de rechercher le sinogramme simplifié associé à un mot français donné.
- **GetAllInformationCommand.cs** : Classe qui permet de récupérer toutes les informations disponibles pour un mot donné.
- **CommandInterpreter.cs** : Classe qui interprète les commandes et arguments passés en ligne de commande pour exécuter les fonctionnalités appropriées.
- **Program.cs** : Point d'entrée principal de l'application.

## Prérequis

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 ou plus)
- Un éditeur de code comme [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)
