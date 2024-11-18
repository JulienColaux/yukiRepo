git flow init : Initialise Git Flow dans le projet.

git flow feature start <nom> : Crée une nouvelle branche de fonctionnalité à partir de develop.

git flow feature finish <nom> : Termine une fonctionnalité et fusionne dans develop.

git flow feature checkout <nom> : Passe sur une branche de fonctionnalité existante.

git flow release start <version> : Crée une branche de release à partir de develop.

git flow release finish <version> : Termine une release, fusionne dans main et develop, puis tague la version.

git flow hotfix start <nom> : Crée une branche hotfix à partir de main pour corriger un bug urgent.

git flow hotfix finish <nom> : Termine un hotfix, fusionne dans main et develop, puis tague la version.

git flow support start <nom> : Crée une branche de support à partir de n'importe quelle branche principale.

git flow support finish <nom> : Termine une branche de support (rarement utilisée dans la pratique).
