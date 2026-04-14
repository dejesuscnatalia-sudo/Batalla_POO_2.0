using System;
using System.Collections.Generic;

namespace RPG_TEST
{
    internal class Personaje
    {
        // Una sola instancia estática de Random para toda la clase
        private static readonly Random rng = new Random();

        private string nombre;
        private decimal vida;
        private decimal ataque;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public decimal Vida
        {
            get { return vida; }
            set
            {
                // Llegar a 0 es normal en combate, no es un error
                vida = value < 0 ? 0 : value;
            }
        }

        public decimal Ataque
        {
            get { return ataque; }
            set
            {
                if (value <= 0)
                    throw new Exception("El ataque debe ser mayor que cero.");
                ataque = value;
            }
        }

        // Retorna una descripción del resultado en lugar de lanzar excepciones informativas
        public string Atacar(Personaje enemigo)
        {
            if (enemigo == null)
                throw new Exception("No hay enemigo para atacar.");

            int tirada = rng.Next(1, 101);

            if (tirada <= 10)
            {
                AtaqueFurioso(enemigo);
                decimal incremento = rng.Next(1, 101) * 0.05m;
                AumentarAtaque(incremento);
                return $"¡ATAQUE FURIOSO! {Nombre} infligió el doble de daño. (Ataque +{incremento})\nVida de {enemigo.Nombre}: {enemigo.Vida}";
            }
            else if (tirada <= 50)
            {
                enemigo.Vida -= Ataque;
                decimal incremento = rng.Next(1, 101) * 0.05m;
                AumentarAtaque(incremento);
                return $"{Nombre} atacó con éxito. (Ataque +{incremento})\nVida de {enemigo.Nombre}: {enemigo.Vida}";
            }
            else
            {
                return $"{Nombre} falló el ataque.";
            }
        }

        public string Curar(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("La cantidad de curación debe ser positiva.");

            int tirada = rng.Next(1, 101);

            if (tirada <= 50)
            {
                decimal vidaAnterior = Vida;
                Vida += cantidad;

                if (Vida > 100)
                {
                    decimal curacionReal = 100 - vidaAnterior;
                    Vida = 100;
                    return $"{Nombre} se curó {curacionReal} puntos (vida máxima alcanzada). Vida: {Vida}";
                }
                return $"{Nombre} se curó {cantidad} puntos. Vida: {Vida}";
            }
            else
            {
                return $"La curación de {Nombre} falló.";
            }
        }

        public void AtaqueFurioso(Personaje enemigo)
        {
            decimal daño = Ataque * 2;
            enemigo.Vida -= daño;
        }

        public string TurnoEnemigo(Personaje jugador)
        {
            int accion = rng.Next(1, 101);

            if (Vida > 50)
            {
                // Con vida alta: 85% atacar, 15% curarse
                if (accion <= 85)
                {
                    return EjecutarAtaque(jugador);
                }
                else
                {
                    decimal cantidad = rng.Next(1, 101) * 0.05m;
                    return Curar(cantidad);
                }
            }
            else
            {
                // Con vida baja: 60% curarse, 40% atacar
                if (accion <= 60)
                {
                    decimal cantidad = rng.Next(1, 101) * 0.05m;
                    return Curar(cantidad);
                }
                else
                {
                    return EjecutarAtaque(jugador);
                }
            }
        }


        public string AtaqueOscuro(Personaje enemigo)
        {
            if (enemigo == null)
                throw new Exception("No hay enemigo para atacar.");

            int probabilidad = rng.Next(1, 101);

            if (probabilidad <= 5)
            {
                decimal daño = Ataque * 3;
                enemigo.Vida -= daño;
                return $"¡ATAQUE OSCURO! {Nombre} infligió el triple de daño. Vida de {enemigo.Nombre}: {enemigo.Vida}";
            }
            return $"{Nombre} intentó Ataque Oscuro pero falló.";
        }

        public void AumentarAtaque(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("El aumento de ataque debe ser positivo.");
            Ataque += cantidad;
        }

        // Método privado para no duplicar la lógica de ataque
        private string EjecutarAtaque(Personaje jugador)
        {
            int tirada = rng.Next(1, 101);

            if (tirada <= 5)
                return AtaqueOscuro(jugador);
            else if (tirada <= 80) // Falla solo el 20% del tiempo en lugar del 50%
                return Atacar(jugador);
            else
                return $"{Nombre} falló el ataque.";
        }
    }
}
