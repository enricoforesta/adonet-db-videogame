namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            Videogame NuovoVideogioco = new Videogame("Call of Duty", "owerefihiadfh", "20/11/2024" , DateTime.Now, DateTime.Now, 3);
            while (continua)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Inserire un nuovo videogioco");
                Console.WriteLine("2. Ricercare un videogioco per ID");
                Console.WriteLine("3. Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa");
                Console.WriteLine("4. Cancellare un videogioco");
                Console.WriteLine("5. Chiudere il programma");

                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        VideogameManager.InserisciVideogioco(NuovoVideogioco);
                        break;
                    case "2":
                        Console.WriteLine("inserire ID");
                        int idInput = Convert.ToInt32(Console.ReadLine());
                        VideogameManager.RicercaVideogiocoId(idInput);
                        break;
                    case "3":
                        Console.WriteLine("inserire Nome");
                        string nomeInput = Console.ReadLine();
                        VideogameManager.RicercaVideogiocoNome(nomeInput);
                        break;
                    case "4":
                        Console.WriteLine("inserire ID da eliminare");
                        int idInputDelete = Convert.ToInt32(Console.ReadLine());
                        VideogameManager.CancellareVideogiocoId(idInputDelete);
                        break;
                    case "5":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }

                Console.WriteLine();
            }
        }

    }
}

