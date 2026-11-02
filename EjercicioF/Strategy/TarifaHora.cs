using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class TarifaHora : ITarifa
    {
        public string Nombre => "Hora";
        public decimal Calcular(int minutos)
        {
            // Se usa (decimal)Math.Ceiling para redondear para arriba // y aclarar que sea un decimal, ya que el redondeo devuelve double.
            decimal horas = (decimal)Math.Ceiling(minutos / 60.0); 
            return horas * 1200;
        }
    }
}
