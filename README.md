# Microservices

Microservices ASP.NET Core, REST, C#

## Structure

* Ajout d'une Gateway Ocelot et Eureka en Java.
* App/Container individuel pour chaque opération CRUD
* Microservice de Conversion de température
* Deux clients :
  ** admin supportant Read, Update et Delete
  ** client pour la conversion supportant Create

## Docker

Dockerfiles + docker-compose pour orchestrer le tout, travail en cours

## Database

MongoDB

## TODOS

* Finir la Gateway avec Docker
* Réviser docker-compose.yml