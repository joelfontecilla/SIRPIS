using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.Entidades
{
    public class Menu : Entidad
    {
        private string _nombre;
        private string _nivel;
        private bool _activo;

        public Menu() { }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}
