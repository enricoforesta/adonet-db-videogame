using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }

        public int Software_house_id { get; set; }

        public Videogame(int id, string name, string overview,DateTime release_date,DateTime created_at, DateTime update_at, int software_house_id) 
        {
            this.Id = id;
            this.Name = name;
            this.Overview = overview;
            this.Release_date = release_date;
            this.Created_at = created_at;
            this.Update_at = update_at;
            this.Software_house_id = software_house_id;
        }
    }

    public static class VideogameManager
    {
        public static void InserisciVideogioco(Videogame videogame)
        {

        }

        public static Videogame RicercaVideogiocoId(Videogame videogame)
        {

        }
        public static Videogame RicercaVideogiocoNome(Videogame videogame)
        {

        }
        public static void CancellareVideogiocoId(Videogame videogame)
        {

        }
    }
}
