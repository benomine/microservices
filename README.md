# Microservices C#

Microservices ASP.NET Core, REST, C#

## Structure

* Ajout d'une Gateway [Ocelot](https://ocelot.readthedocs.io/en/latest/index.html) et Eureka en Java pour le Discovery \(utilisation de Spring boot\).
* App/Container individuel pour chaque opération CRUD, utilisation de [Steeltoe](https://steeltoe.io/) pour le discovery et le lien avec Eureka.
* Microservice de Conversion de température.
* Deux clients :
        ** admin supportant Read, Update et Delete
        ** client pour la conversion faisant appel au µ-service Create

## Docker

Dockerfiles + docker-compose.yml pour orchestration

## Database

MongoDB sous Docker

## TODOS

* Revoir les clients en modifiant les ips/host des µ-services
* Finir la Gateway avec Docker : vérifier les adresses ip/hostname des µ-services
* Réviser docker-compose.yml
* Tests unitaires
* Déploiement