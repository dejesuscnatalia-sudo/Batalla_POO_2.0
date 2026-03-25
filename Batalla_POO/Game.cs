using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalla_POO
{
    internal class Personaje
    {
        private string nombre;
        private decimal vida;
        private decimal ataque;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre no puede estar vacio.");

                }
                else
                {
                    nombre = value;

                }
            }
        }
        public decimal Vida
        {
            get { return vida; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("La vida no puede ser negativa");

                }
                else
                {
                    vida = value;

                }
            }
        }
        public decimal Ataque
        {
            get { return ataque; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("El ataque debe ser mayor que cero");

                }
                else
                {
                    ataque = value;

                }
            }
        }
         public decimal Atacar(Personaje enemigo)
 {
     try
     {
         if (enemigo == null)
         {
             throw new Exception("No hay enemigo para atacar.");
         }

          return enemigo.Vida -= Ataque;

         // Console.WriteLine(Nombre + " atacó a " + enemigo.Nombre);
         //Console.WriteLine("Daño causado: " + Ataque);
     }
     catch (Exception error)
     {
         throw new Exception("Error al atacar: " + error.Message);
     }
 }
 public decimal Curar(int cantidad)
 {
     try
     {
         if (cantidad <= 0)
         {
             throw new Exception("La cantidad de curación debe ser positiva.");
         }

         return Vida += cantidad;

         if (Vida > 100)
         {
             Vida = 100;
         }

         // Console.WriteLine(Nombre + " se curó " + cantidad + " puntos.");
     }
     catch
     {
         throw new Exception("Error al curar.");
     }
 }
         public void AtaqueFurioso(Personajes enemigo)
 {
     try
     {
         if (enemigo == null)
         {
             throw new Exception("No hay enemigo para atacar.");
         }
         Random random = new Random();
         int probabilidad = random.Next(1, 101);
         if (probabilidad <= 10)
         {
             decimal daño = Ataque * 2;
             enemigo.Vida -= daño;
             // Console.WriteLine(Nombre + " usó Ataque Furioso en " + enemigo.Nombre);
             // Console.WriteLine("Daño causado: " + daño);
         }
         else
         {
             // Console.WriteLine(Nombre + " intentó usar Ataque Furioso pero falló.");
         }
     }
     catch (Exception error)
     {
         throw new Exception("Error al usar Ataque Furioso: " + error.Message);
     }
 }
 public void AtaqueOscuro (Personajes enemigo)
 {
     try
     {
         if (enemigo == null)
         {
             throw new Exception("No hay enemigo para atacar.");
         }
         Random random = new Random();
         int probabilidad = random.Next(1, 101);
         if (probabilidad <= 5)
         {
             decimal daño = Ataque * 3;
             enemigo.Vida -= daño;
             // Console.WriteLine(Nombre + " usó Ataque Oscuro en " + enemigo.Nombre);
             // Console.WriteLine("Daño causado: " + daño);
         }
         else
         {
             // Console.WriteLine(Nombre + " intentó usar Ataque Oscuro pero falló.");
         }
     }
     catch (Exception error)
     {
         throw new Exception("Error al usar Ataque Oscuro: " + error.Message);
     }
 }

        private void AumentarAtaque(int cantidad)
        {
            try
            {
                if (cantidad <= 0)
                {
                    throw new Exception("El aumento de ataque debe ser positivo.");
                }

                Ataque += cantidad;

                //  Console.WriteLine(Nombre + " aumentó su ataque en " + cantidad);
            }
            catch
            {
                throw new Exception("Error al aumentar ataque.");
            }
        }
    }
}
