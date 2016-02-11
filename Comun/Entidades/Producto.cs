using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.Entidades
{
    public class Producto : Entidad
    {
        private string _nombre;
        private string _descripcion;
        private double _precio;
        private int _disponibilidad;

        public Producto() { }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Disponibilidad
        {
            get { return _disponibilidad; }
            set { _disponibilidad = value; }
        }
    }
}
