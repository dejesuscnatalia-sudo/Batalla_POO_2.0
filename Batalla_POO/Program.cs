namespace Batalla_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");



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
                O = menu.MakeMenu("Seleccione una operacion", Operaciones, 1);
            } while (O < 1 || O > 2);
        }
    }
}
