using System;

namespace RPG_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personaje jugador = new Personaje();
            jugador.Vida = 100;
            jugador.Ataque = 5;

            Personaje enemigo = new Personaje();
            enemigo.Vida = 100;
            enemigo.Ataque = 5;

            // --- Nombre del jugador ---
            do
            {
                Console.WriteLine("Inserte el nombre para su personaje:");
                try { jugador.Nombre = Console.ReadLine(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            } while (string.IsNullOrWhiteSpace(jugador.Nombre));

            Console.Clear();

            // --- Nombre del enemigo ---
            do
            {
                Console.WriteLine("Inserte el nombre para el enemigo:");
                try { enemigo.Nombre = Console.ReadLine(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            } while (string.IsNullOrWhiteSpace(enemigo.Nombre));

            Console.Clear();

            // Una sola instancia de Random para todo Program
            Random rng = new Random();

            // --- Bucle de combate ---
            while (jugador.Vida > 0 && enemigo.Vida > 0)
            {
                // Mostrar estadísticas
                Console.WriteLine($"\n{jugador.Nombre}: Vida={jugador.Vida} | Ataque={jugador.Ataque}");
                Console.WriteLine($"{enemigo.Nombre}: Vida={enemigo.Vida} | Ataque={enemigo.Ataque}");
                Console.WriteLine("----------------------------------");

                // --- Turno del jugador ---
                int opcion = 0;
                do
                {
                    string[] movimientos = { "1-Atacar", "2-Curar" };
                    Menu menu = new Menu();
                    opcion = menu.MakeMenu("Seleccione una accion", movimientos, 1);
                } while (opcion < 1 || opcion > 2);

                switch (opcion)
                {
                    case 1:
                        string resultadoAtaque = jugador.Atacar(enemigo);
                        Console.WriteLine(resultadoAtaque);
                        break;

                    case 2:
                        decimal cantidadCura = rng.Next(1, 101) * 0.1m;
                        string resultadoCura = jugador.Curar(cantidadCura);
                        Console.WriteLine(resultadoCura);
                        break;
                }

                // Verificar fin de combate tras turno del jugador
                if (enemigo.Vida <= 0) break;

                // --- Turno del enemigo ---
                Console.WriteLine("\n-- Turno del enemigo --");
                Console.WriteLine(enemigo.TurnoEnemigo(jugador));
            }

            // --- Mensaje de victoria o derrota ---
            Console.WriteLine("\n========== FIN DEL COMBATE ==========");

            if (jugador.Vida <= 0 && enemigo.Vida <= 0)
                Console.WriteLine("¡Ambos cayeron al mismo tiempo! Empate.");
            else if (jugador.Vida <= 0)
                Console.WriteLine($"Derrota. {enemigo.Nombre} ganó el combate.");
            else
                Console.WriteLine($"¡Victoria! {jugador.Nombre} ganó el combate.");

            Console.ReadKey();
        }
    }
}
