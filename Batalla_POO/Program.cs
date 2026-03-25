namespace Batalla_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int Estadisticas, O;
             O = 0;
             Game Jugador = new Game();
             Jugador.Nombre = null;
             Jugador.Vida = 100;
             Jugador.Ataque = 5;
             Game Enemigo = new Game();
             Enemigo.Nombre = "CPU 1";
             Enemigo.Vida = 100; 
             Enemigo.Ataque = 5;
             do
             {
                 Console.WriteLine("Inserte el nombre para su personaje");
                 Jugador.Nombre = Console.ReadLine();
             } while (Jugador.Nombre == "");
             Game Datos = new Game();
             Console.Clear();
             //pantalla de niveles 
             //jugador
             Console.WriteLine("");
             //primera acción: selección de movimiento
             do
             {
                 string[] Movimientos = new string[]
                 {
                     "1-Atacar",
                     "2-Curar",
                 };
                 Menu menu = new Menu();
                 Estadisticas = menu.MakeMenu($" {Game.Nombre} Vida={Jugador.Vida} | Ataque={Jugador.Ataque}\nEnemigo: Vida={Enemigo.Vida} | Ataque={Enemigo.Ataque}\nSeleccione una accion", Movimientos, 1);
             } while (O < 1 || O > 2);
            

            Random AtaqueEnemigo = new Random(); //contexto: da un numero al azar
            Random AtaqueJugador = new Random();
            Random CuracionEnemigo = new Random();
            Random CuracionJugador = new Random();
            Random AtaqueFurioso = new Random();
            Random AtaqueOscuro = new Random();
        
        
            decimal ae = AtaqueEnemigo.Next(1, 101);
            decimal aj = AtaqueJugador.Next(1, 101);
            decimal ce = CuracionEnemigo.Next(1, 101);
            decimal cj = CuracionJugador.Next(1, 101);
            decimal af = AtaqueFurioso.Next(1, 101);
            decimal ao = AtaqueOscuro.Next(1, 101);
        
            decimal curacionEnemigo = ce * 0.05m; //este hay que meterlo al ciclo donde se elije la opcion de curacion
            decimal curacionJugador = cj * 0.1m; //este hay que ponerlo en un if que dependa de si el enemigo esta con poca vida
        
            Console.WriteLine("Probabilidad: " + ae);
        
            if (ae <= 50)
            {
        
            Console.WriteLine("El ataque del enemigo ha sido exitoso");
            Random incremento = new Random();
            decimal incrementoAtaque = incremento.Next(1, 101);
            decimal incrementoFinal = incrementoAtaque * 0.05m;
            Console.WriteLine("El ataque del enemigo se ha incrementado en: " + incrementoFinal);
            //aqui incrementas el ataque del enemigo
                
        
            
            }
        
            else
            { 
                Console.WriteLine("El ataque del enemigo ha fallado");
            }
        
            if (aj <= 50) 
                {
                Console.WriteLine("Tu ataque ha sido exitoso");
                Random incremento = new Random();
                decimal incrementoAtaque = incremento.Next(1, 101);
                decimal incrementoFinal = incrementoAtaque * 0.1m;
                Console.WriteLine("Tu ataque se ha incrementado en: " + incrementoFinal);
                //aqui incrementas tu ataque
            }
            else
            {
                Console.WriteLine("Tu ataque ha fallado");
            }
        
            if (curacionEnemigo > 0)
            {
                Console.WriteLine("El enemigo se ha curado por: " + curacionEnemigo);
                //aqui incrementas la vida del enemigo
            }
        
            if (curacionJugador > 0)
            {
                Console.WriteLine("Te has curado por: " + curacionJugador);
                //aqui incrementas tu vida
            }
        
        
        
            if (af <= 10)
            {
                Console.WriteLine("Tu ataque furioso ha sido exitoso, has hecho el doble de daño");
                //aqui haces el doble de daño
            }
            else
            {
                Console.WriteLine("Tu ataque furioso ha fallado");
            }
        
            if (ao <= 5)
            {    
                Console.WriteLine("El ataque oscuro del enemigo ha sido exitoso, ha hecho el triple de daño");
                //aqui el enemigo hace el triple de daño
            }
            else
            {
                Console.WriteLine("El ataque oscuro del enemigo ha fallado");
            }
        }
    }
}
