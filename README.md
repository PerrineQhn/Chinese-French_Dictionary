# Dictionnaire Français <-> Chinois

Bienvenue dans le dictionnaire interactif chinois-français ! Ce programme vous permet de rechercher facilement des sinogrammes (simplifiés et traditionnels), leur translittération en pinyin, et leur traduction en français. Pratique pour explorer la langue chinoise, il fonctionne à partir d'un fichier de données JSON qui est généré automatiquement si nécessaire.

### D'où viennent les données ?

Les données sont extraites d'un fichier XML (`cfdict.xml` obtenus ici [chine.in](https://chine.in/mandarin/dictionnaire/CFDICT/) ) contenant les sinogrammes, le pinyin et les traductions françaises. Si ce fichier JSON n'existe pas déjà, le programme le crée au démarrage en transformant les données du XML en un format lisible.

---

## Comment utiliser le programme ?

L'application fonctionne avec des commandes que vous entrez dans la console. Voici une liste des commandes disponibles et ce qu'elles font :

### **1. GetSinogram**

- **À quoi ça sert ?** : Trouver les sinogrammes simplifiés liés à un mot français ou à son pinyin.
- **Comment l'utiliser ?** : `GetSinogram <mot-français ou pinyin>`
- **Exemple** : `GetSinogram bonjour`

---

### **2. GetTraditional**

- **À quoi ça sert ?** : Obtenir les sinogrammes traditionnels à partir d'un sinogramme simplifié ou d'un pinyin.
- **Comment l'utiliser ?** : `GetTraditional <sinogramme-simplifié ou pinyin>`
- **Exemple** : `GetTraditional 你好`

---

### **3. GetFrench**

- **À quoi ça sert ?** : Trouver la traduction française d'un mot chinois, qu'il soit en sinogramme ou en pinyin.
- **Comment l'utiliser ?** : `GetFrench <sinogramme ou pinyin>`
- **Exemple** : `GetFrench 你好`

---

### **4. GetPinyin**

- **À quoi ça sert ?** : Récupérer le pinyin (translittération) d'un sinogramme simplifié ou traditionnel.
- **Comment l'utiliser ?** : `GetPinyin <sinogramme>`
- **Exemple** : `GetPinyin 你好`

---

### **5. GetAllInformation**

- **À quoi ça sert ?** : Afficher toutes les infos sur un mot : sinogrammes (simplifié et traditionnel), pinyin, et traduction française.
- **Comment l'utiliser ?** : `GetAllInformation <mot ou sinogramme>`
- **Exemple** : `GetAllInformation bonjour`

---

### **6. help**

- **À quoi ça sert ?** : Obtenir un petit résumé des commandes disponibles.
- **Comment l'utiliser ?** : `help`

---

### **7. exit**

- **À quoi ça sert ?** : Fermer l'application.
- **Comment l'utiliser ?** : `exit`

---

## Bonus : Sauvegarder vos recherches

À chaque recherche, vous avez la possibilité de sauvegarder les résultats dans un fichier texte (`Output/searches.txt`). Pratique pour garder une trace de ce que vous avez exploré !

---
