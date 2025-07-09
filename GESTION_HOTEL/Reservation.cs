using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_HOTEL
{
    internal class Reservation
    {
        int id;
        int refClient;
        int refChambre;
        DateTime dateEntree;
        DateTime dateSortie;

        public int Id { get => id; set => id = value; }
        public int RefClient { get => refClient; set => refClient = value; }
        public int RefChambre { get => refChambre; set => refChambre = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateSortie { get => dateSortie; set => dateSortie = value; }
    }
}
