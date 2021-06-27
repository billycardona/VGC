using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGC
{
    class Figura
    {
        public string franquicia;
        public string nombre;
        public string descripcion;
        public float precio;
        public string existencia;

        public Figura(string franquicia, string nombre, string descripcion, float precio, string existencia)
        {
            this.franquicia = franquicia;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.existencia = existencia;
        }
    }
}
