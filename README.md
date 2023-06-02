
# API de gestion de films


Cette API permet de gérer une collection de films. Elle offre différentes fonctionnalités pour rechercher, trier et convertir les films en différents formats.

# Utilisation de l'API

L'API propose les endpoints suivants :

 - URL : `/api/movies/getAll` : Récupère tous les films de la collection.
 - URL : ` /api/movies/convertToXml` : Convertit la collection de films en format XML et renvoie le contenu XML.
 - URL : `/api/movies/getAllSortedBy?sortedBy={critere}` : Récupère tous les films de la collection triés selon le critère spécifié. 
   
   sortedBy : `Critère de tri (title, year, genre, director, actors, rating)`
 - URL : `/api/movies/search?{parametres}` :  Recherche des films correspondant aux critères spécifiés.
    
    Paramètres de requête (optionnels) :
    `title : Titre du film.
    year : Année de sortie du film.
    genre : Genre du film.
    director : Réalisateur du film.
    actors : Acteurs du film.
    ratingOperator : Opérateur de notation (> pour supérieur à, < pour inférieur à, = pour égal à).
    ratingValue : Valeur de notation.`
    
    
# Exemple d'utilisation

Récupérer tous les films :

`URL : /api/movies/getAll`
Méthode : GET

Convertir les films en XML :

`URL : /api/movies/convertToXml`
Méthode : GET

Récupérer tous les films triés par titre :

`URL : /api/movies/getAllSortedBy?sortedBy=title`
Méthode : GET

Rechercher des films par titre et genre :

`URL : /api/movies/search?title=avengers&genre=action`
Méthode : GET

# Dépendances
L'API utilise les dépendances suivantes : 

 - Microsoft.AspNetCore.Http
 - Microsoft.AspNetCore.Mvc
 - Newtonsoft.Json
 - System.Collections.Generic
 - System.IO
 - System.Linq


# Configuration

L'API a été développée avec ASP.NET Core et utilise le pipeline de requêtes HTTP. Elle est configurée pour utiliser HTTPS et nécessite une autorisation pour accéder aux endpoints.

# Exécution de l'API

Pour exécuter l'API, vous devez installer les dépendances, compiler et exécuter le code.

Assurez-vous d'avoir .NET SDK installé sur votre machine.

Ouvrez une invite de commande ou un terminal et placez-vous dans le répertoire contenant le code de l'API.

Exécutez la commande suivante pour restaurer les dépendances :


`dotnet restore`

Exécutez la commande suivante pour compiler l'API :


`dotnet build`

Exécutez la commande suivante pour lancer l'API :


`dotnet run`

L'API sera accessible à l'adresse https://localhost:<port>/api/movies, où <port> est le numéro de port utilisé par l'API.

Assurez-vous d'adapter les URLs et les paramètres en fonction de votre environnement et des besoins de votre application.
