# Dictionnaire Français <-> Chinois

Bienvenue dans le dictionnaire interactif chinois-français ! Ce programme vous permet de rechercher facilement des sinogrammes (simplifiés et traditionnels), leur translittération en pinyin, et leur traduction en français. Pratique pour explorer la langue chinoise, il fonctionne à partir d'un fichier de données JSON qui est généré automatiquement si nécessaire.

### D'où viennent les données ?

Les données sont extraites d'un fichier XML (`cfdict.xml` obtenus ici [chine.in](https://chine.in/mandarin/dictionnaire/CFDICT/) ) contenant les sinogrammes, le pinyin et les traductions françaises. Si ce fichier JSON n'existe pas déjà, le programme le crée au démarrage en transformant les données du XML en un format lisible.

---

## Comment utiliser le programme ?

L'application fonctionne avec des commandes que vous entrez dans la console. Voici une liste des commandes disponibles et ce qu'elles font (ici les commandes sont en français):

⚠️ Une tabulation est à utiliser entre la commande et l'argument, une seule recherche à la fois est possible.

### **1. ObtenirSinogramme**

- **À quoi ça sert ?** : Trouver les sinogrammes simplifiés liés à un mot français ou à son pinyin.
- **Comment l'utiliser ?** : `ObtenirSinogramme   <mot-français ou pinyin>`
- **Exemple** : `ObtenirSinogramme    bonjour`
- **Équivalent dans les autres langues** : `GetSinogram`, `获取汉字`

---

### **2. ObtenirTraditionnel**

- **À quoi ça sert ?** : Obtenir les sinogrammes traditionnels à partir d'un sinogramme simplifié ou d'un pinyin.
- **Comment l'utiliser ?** : `ObtenirTraditionnel    <sinogramme-simplifié ou pinyin>`
- **Exemple** : `ObtenirTraditionnel 你好`
- **Équivalent dans les autres langues** : `GetTraditional`, `获取繁体`

---

### **3. ObtenirFrancais**

- **À quoi ça sert ?** : Trouver la traduction française d'un mot chinois, qu'il soit en sinogramme ou en pinyin.
- **Comment l'utiliser ?** : `ObtenirFrancais <sinogramme ou pinyin>`
- **Exemple** : `ObtenirFrancais  你好`
- **Équivalent dans les autres langues** : `GetFrench`, `获取法文`

---

### **4. ObtenirPinyin**

- **À quoi ça sert ?** : Récupérer le pinyin (translittération) d'un sinogramme simplifié ou traditionnel.
- **Comment l'utiliser ?** : `ObtenirPinyin <sinogramme>`
- **Exemple** : `ObtenirPinyin  你好`
- **Équivalent dans les autres langues** : `GetPinyin`, `获取拼音`

---

### **5. ObtenirToutesInformations**

- **À quoi ça sert ?** : Afficher toutes les infos sur un mot : sinogrammes (simplifié et traditionnel), pinyin, et traduction française.
- **Comment l'utiliser ?** : `ObtenirToutesInformations <mot ou sinogramme>`
- **Exemple** : `ObtenirToutesInformations  au revoir`
- **Équivalent dans les autres langues** : `GetAllInformation`, `获取所有信息`

---

### **6. ChangerLangue**

- **À quoi ça sert ?** : Permet de changer la langue de l'interface, trois choix possible : chinois (zh), français (fr) et anglais (en).
- **Comment l'utiliser ?** : `ChangerLangue   <lang>`
- **Exemple**: `ChangerLangue  zh`
- **Équivalent dans les autres langues** : `ChangeLanguage`, `更改语言`

---

### **7. Aide**

- **À quoi ça sert ?** : Obtenir un petit résumé des commandes disponibles.
- **Comment l'utiliser ?** : `Aide`
- **Équivalent dans les autres langues** : `Help`, `帮助`

---

### **8. Quitter**

- **À quoi ça sert ?** : Fermer l'application.
- **Comment l'utiliser ?** : `Quitter`
- **Équivalent dans les autres langues** : `Exit`, `退出`

--

### **9. LireFichierSauvegarde**

- **À quoi ça sert?** : Permet d'afficher le fichier de sauvegarde dans la console.
- **Comment l'utiliser ?** : `LireFichierSauvegarde <chemin_fichier_sauvegarder>`
- **Équivalent dans les autres langues** : `ReadSaveFile`, `读取保存文件`

### Sauvegarde de la recherche

À chaque recherche, vous avez la possibilité de sauvegarder les résultats dans un fichier texte (`Output/searches.txt`). Pratique pour garder une trace de ce que vous avez exploré !

---
