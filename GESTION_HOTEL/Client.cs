using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_HOTEL
{
    internal class Client
    {
        int id;
        string nom;
        string adresse;
        string contact;
        int refCategorie;

        public int Id { get => id; set => id = value; }
       
        public string Adresse { get => adresse; set => adresse = value; }
        public string Contact { get => contact; set => contact = value; }
        public int RefCategorie { get => refCategorie; set => refCategorie = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
