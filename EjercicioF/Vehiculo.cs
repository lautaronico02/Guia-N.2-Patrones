using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class Vehiculo
    {
        public string Patente {  get; set; }
        public ITarifa Tarifa { get; set; }
    }
}