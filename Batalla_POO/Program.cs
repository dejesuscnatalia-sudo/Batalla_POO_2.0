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
            int men=0;
            //Poner nombre
             do
             {
                 Console.WriteLine("Inserte el nombre para su personaje");
                 Jugador.Nombre = Console.ReadLine();
             } while (Jugador.Nombre == "");
             Console.Clear();
            //pantalla de niveles 
            
            //jugador
            Console.WriteLine("");
            //primera acción: selección de movimiento
            do
            {
                Menu menu = new Menu();
                string[] Operaciones = new string[]
                {
                    "1-Atacar",
                    "2-Curar",
                    };
                men = menu.MakeMenu("Seleccione una accion", Operaciones, 1);
            } while (men < 1 || men > 2);
            
        }
    }
}
