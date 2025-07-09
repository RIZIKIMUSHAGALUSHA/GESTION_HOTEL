using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_HOTEL
{
    internal class Classe
    {
        int id;
        string designation;
        int prix;

        public int Id { get => id; set => id = value; }
        public string Designation { get => designation; set => designation = value; }
        public int Prix { get => prix; set => prix = value; }
    }
}
