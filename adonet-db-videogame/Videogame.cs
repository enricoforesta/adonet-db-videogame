using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
        public DateOnly Release_date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }

        public int Software_house_id { get; set; }

        public Videogame(string name, string overview, string release_date,DateTime created_at, DateTime update_at, int software_house_id) 
        {
            this.Name = name;
            this.Overview = overview;
            this.Release_date = DateOnly.ParseExact(release_date, "dd/MM/yyyy") ;
            this.Created_at = created_at;
            this.Update_at = update_at;
            this.Software_house_id = software_house_id;
        }
    }

    public static class VideogameManager 
    {
        public static string SqlStringa = "Data Source=localhost; Initial Catalog=db_videogames; Integrated Security=True;";

        public static void InserisciVideogioco(Videogame videogame)
        {
            using SqlConnection connessioneSql = new SqlConnection(SqlStringa);
            try
            {
                connessioneSql.Open();
                string query = @"INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id)
                            VALUES (@name, @overview, @release_date, @created_at, @updated_at, @software_house_id)";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                // Parametri
                cmd.Parameters.Add(new SqlParameter("@name", videogame.Name));
                cmd.Parameters.Add(new SqlParameter("@overview", videogame.Overview));
                cmd.Parameters.Add(new SqlParameter("@release_date", videogame.Release_date));
                cmd.Parameters.Add(new SqlParameter("@created_at", videogame.Created_at));
                cmd.Parameters.Add(new SqlParameter("@updated_at", videogame.Update_at));
                cmd.Parameters.Add(new SqlParameter("@software_house_id", videogame.Software_house_id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RicercaVideogiocoId(int videogameId)
        {
            using SqlConnection connessioneSql = new SqlConnection(SqlStringa);
            try
            {
                connessioneSql.Open();
                string query = @"SELECT * FROM videogames WHERE Id = @videogameId";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@videogameId", videogameId));

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetOrdinal("Id");
                    int name = reader.GetOrdinal("name");
                    int overview = reader.GetOrdinal("overview");
                    int release_date = reader.GetOrdinal("release_date");
                    int created_at = reader.GetOrdinal("created_at");
                    int updated_at = reader.GetOrdinal("updated_at");
                    int software_house_id = reader.GetOrdinal("software_house_id");

                    Console.WriteLine($"ID: {reader.GetInt64(id)}");
                    Console.WriteLine($"Nome: {reader.GetString(name)}");
                    Console.WriteLine($"Descrizione: {reader.GetString(overview)}");
                    Console.WriteLine($"Data di rilascio: {reader.GetDateTime(release_date)}");
                    Console.WriteLine($"Data di Creazione: {reader.GetDateTime(created_at)}");
                    Console.WriteLine($"Data ultima modifica: {reader.GetDateTime(updated_at)}");
                    Console.WriteLine($"Software house Id: {reader.GetInt64(software_house_id)}");
                }
                else
                {
                    Console.WriteLine("Non è stato trovato alcun videogioco con l'ID specificato");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void RicercaVideogiocoNome(string nome)
        {
            using SqlConnection connessioneSql = new SqlConnection(SqlStringa);
            try
            {
                connessioneSql.Open();
                string query = @"SELECT * FROM videogames WHERE name LIKE '%' + @nome + '%'";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@nome", nome));

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetOrdinal("Id");
                    int name = reader.GetOrdinal("name");
                    int overview = reader.GetOrdinal("overview");
                    int release_date = reader.GetOrdinal("release_date");
                    int created_at = reader.GetOrdinal("created_at");
                    int updated_at = reader.GetOrdinal("updated_at");
                    int software_house_id = reader.GetOrdinal("software_house_id");

                    Console.WriteLine($"ID: {reader.GetInt64(id)}");
                    Console.WriteLine($"Nome: {reader.GetString(name)}");
                    Console.WriteLine($"Descrizione: {reader.GetString(overview)}");
                    Console.WriteLine($"Data di rilascio: {reader.GetDateTime(release_date)}");
                    Console.WriteLine($"Data di Creazione: {reader.GetDateTime(created_at)}");
                    Console.WriteLine($"Data ultima modifica: {reader.GetDateTime(updated_at)}");
                    Console.WriteLine($"Software house Id: {reader.GetInt64(software_house_id)}");
                }
                else
                {
                    Console.WriteLine("Non è stato trovato alcun videogioco con nome specificato");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CancellareVideogiocoId(int videogameId)
        {
            using (SqlConnection connessioneSql = new SqlConnection(SqlStringa))
            {
                try
                {
                    connessioneSql.Open();
                    string query = @"DELETE FROM videogames WHERE Id = @videogameId";

                    using (SqlCommand cmd = new SqlCommand(query, connessioneSql))
                    {
                        cmd.Parameters.AddWithValue("@videogameId", videogameId);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Videogioco eliminato con successo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
