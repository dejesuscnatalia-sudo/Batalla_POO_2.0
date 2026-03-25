using System;
using System.Collections.Generic;
using System.Text;

namespace Batalla_POO
    internal class Personaje
    {
        private string nombre;
        private decimal vida;
        private decimal ataque;

        private string Nombre
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
        public void Atacar(Personaje enemigo)
        {
            try
            {
                if (enemigo == null)
                {
                    throw new Exception("No hay enemigo para atacar.");
                }

                enemigo.Vida -= Ataque;

               // Console.WriteLine(Nombre + " atacó a " + enemigo.Nombre);
                //Console.WriteLine("Daño causado: " + Ataque);
            }
            catch (Exception error)
            {
                trow new Exception ("Error al atacar: " + error.Message);
            }
        }
        public void Curar(int cantidad)
        {
            try
            {
                if (cantidad <= 0)
                {
                    throw new Exception("La cantidad de curación debe ser positiva.");
                }

                Vida += cantidad;

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
                throw new  Exception ("Error al aumentar ataque." );
            }
        }
    }
}
