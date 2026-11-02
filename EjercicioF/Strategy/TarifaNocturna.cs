using System;
using System.Collections.Generic;

namespace EjercicioF
{
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "Nocturna";
        public decimal Calcular(int minutos)
        {
            return 4500;
        }
    }
}