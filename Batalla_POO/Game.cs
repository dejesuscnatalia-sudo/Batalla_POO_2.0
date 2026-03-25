using System;
using System.Collections.Generic;
using System.Text;

namespace Batalla_POO
{
    internal class Game
    {
        private string nombre;
        private decimal vida;
        private decimal ataque;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public decimal Vida;
        { get { return vida; }
         set { vida = value; }
        }
        public decimal Ataque
        { get { return ataque; }
         set { ataque = value; }
        }
    }
}
