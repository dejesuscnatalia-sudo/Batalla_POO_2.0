namespace Batalla_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Game Jugador = new Game();
             Jugador.Nombre = null;
             Jugador.Vida = 100;
             Jugador.Ataque = 5;
             Game Enemigo = new Game();
             Enemigo.Nombre = "CPU 1";
             Enemigo.Vida = 100;
             Enemigo.Ataque = 5;
             do
                 Random VariableX = new Random();
             {
                 Console.WriteLine("Inserte el nombre para su personaje");
                 Jugador.Nombre = Console.ReadLine();
             } while (Jugador.Nombre == "");
             Console.Clear();
            //pantalla de niveles 
            //jugador
            Console.writeline("");
            //primera acción: selección de movimiento
            do
            {
                Menu menu = new Menu();
                string[] Operaciones = new string[]
                {
                    "1-Atacar",
                    "2-Curar",
                    };
                O = menu.MakeMenu("Seleccione una accion", Operaciones, 1);
            } while (O < 1 || O > 2);
        }
    }
}
