using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public interface ITarifa
    {
        string Nombre { get; }
        decimal Calcular(int Minutos);
    }
}
