using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CreateConversion.Models
{
    [BsonIgnoreExtraElements]
    public class Conversion
    {
        [BsonElement("nom")]
        public string Nom { get; set; }
        [BsonElement("nomUser")]
        public string NomUser { get; set; }
        [BsonElement("valeur")]
        public double Valeur { get; set; }
        [BsonElement("dateAppel")]
        public DateTime DateAppel { get; set; }

        [BsonConstructor]
        public Conversion(string nom, string nomUser, double valeur, DateTime dateAppel)
        {
            Nom = nom;
            NomUser = nomUser;
            Valeur = valeur;
            DateAppel = dateAppel;
        }
    }
}