namespace Batalla_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Estadisticas;
            Personaje Jugador = new Personaje();
            Jugador.Vida = 100;
            Jugador.Ataque = 5;
            Personaje Enemigo = new Personaje();
            Enemigo.Nombre = "CPU 1";
            Enemigo.Vida = 100;
            Enemigo.Ataque = 5;
            Random AtaqueEnemigo = new Random(); //contexto: da un numero al azar
            Random AtaqueJugador = new Random();
            Random CuracionEnemigo = new Random();
            Random CuracionJugador = new Random();



            decimal ae = AtaqueEnemigo.Next(1, 101);
            decimal aj = AtaqueJugador.Next(1, 101);
            decimal ce = CuracionEnemigo.Next(1, 101);
            decimal cj = CuracionJugador.Next(1, 101);


            decimal curacionEnemigo = ce * 0.05m; //este hay que ponerlo en un if que dependa de si el enemigo esta con poca vida
            decimal curacionJugador = cj * 0.1m; //este hay que meterlo al ciclo donde se elije la opcion de curacion 
         do{   
            do
            {
                Console.WriteLine("Inserte el nombre para su personaje");
                Jugador.Nombre = Console.ReadLine();
            } while (Jugador.Nombre == "");
            Personaje Datos = new Personaje();
            Console.Clear();
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
                Estadisticas = menu.MakeMenu($"{Jugador.Nombre}: Vida={Jugador.Vida} | Ataque={Jugador.Ataque}\n{Enemigo.Nombre}: Vida={Enemigo.Vida} | Ataque={Enemigo.Ataque}\nSeleccione una accion", Movimientos, 1);
            } while (Estadisticas < 1 || Estadisticas > 2);



            switch (Estadisticas)
            {
                case 1:
                    if (aj <= 50) 
                        {
                            if (aj <= 10)
                                    {
                                        Jugador.Ataque *= 2;
                                        Enemigo.Vida -= Jugador.Ataque; 
                                        Console.WriteLine("Has realizado un ataque furioso, has hecho el doble de daño");
                                        //ataque furioso hace el doble de daño, si es golpe critico hace el 25% mas de daño, osea 2.25 veces el daño normal
                                    }        
                                Enemigo.Vida -= Jugador.Ataque;
                                Console.WriteLine("Tu ataque ha sido exitoso");
                                Random incremento = new Random();
                                decimal incrementoAtaque = incremento.Next(1, 101);
                                decimal incrementoFinal = incrementoAtaque * 0.1m;
                                Jugador.Ataque += incrementoFinal;
                                Console.WriteLine("Tu ataque se ha incrementado en: " + incrementoFinal);
                                //aqui incrementas tu ataque
                        }
                    break;
                case 2:
                    if (curacionJugador > 0)
                        {
                            Jugador.Vida += curacionJugador;
                            Console.WriteLine("Te has curado por: " + curacionJugador);
                            //aqui incrementas tu vida
                        }
                    else
                        {
                            Console.WriteLine("No pudiste curarte");
                        }
                    break;
            }
            
            Console.WriteLine("Probabilidad: " + ae);
        
           
                if (ae <= 50)
                    {                    
                        if (ae <= 5)
                               {

                                    Enemigo.Ataque *= 3;
                                    Jugador.Vida -= Enemigo.Ataque;
                                    Console.WriteLine("El enemigo ha realizado un ataque oscuro, has recibido el triple del daño");
                                    //ataque oscuro del enemigo hace el triple de daño, si es golpe critico hace el 25% mas de daño, osea 3.25 veces el daño normal

                               }
                        Jugador.Vida -= Enemigo.Ataque;
                        Console.WriteLine("El ataque del enemigo ha sido exitoso");
                        Random incremento = new Random();
                        decimal incrementoAtaque = incremento.Next(1, 101);
                        decimal incrementoFinal = incrementoAtaque * 0.05m;
                        Enemigo.Ataque += incrementoFinal;
                        Console.WriteLine("El ataque del enemigo se ha incrementado en: " + incrementoFinal);
                        //aqui incrementas el ataque del enemigo
    
                    }

                else
                    {
                        Console.WriteLine("El ataque del enemigo ha fallado");
                    }

           
               if (curacionEnemigo > 0)
                    {
                        Enemigo.Vida += curacionEnemigo;
                        Console.WriteLine("El enemigo se ha curado por: " + curacionEnemigo);
                        //aqui incrementas la vida del enemigo
                    }
                else
                    {
                        Console.WriteLine("El enemigo no pudo curarse");
                    }
                       
                }
            }while (Jugador.Vida >= 0 || Enemigo.Vida >= 0);
            }
        }
