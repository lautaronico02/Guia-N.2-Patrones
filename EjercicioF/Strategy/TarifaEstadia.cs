using System;
using System.Collections.Generic;

namespace EjercicioF
{
    public class TarifaEstadia : ITarifa
    {
        public string Nombre => "Estadía";
        public decimal Calcular(int minutos)
        {
            // Es necesario utilizar un if para discernir si la estadía se pasó de las 12 horas, o sea, 720 minutos.
            if (minutos <= 720)
            {
                return 6000;
            }
            else // Si se pasa de los 720 minutos, se le cobra también las horas extra como la tarifa común.
            {
                int extra = minutos - 720;
                decimal horasExtra = (decimal)Math.Ceiling(extra / 60.0);
                return 6000 + horasExtra * 1200;
            }
        }
    }
}