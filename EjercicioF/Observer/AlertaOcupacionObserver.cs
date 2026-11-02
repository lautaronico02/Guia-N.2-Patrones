using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= 2)
            {
                Console.WriteLine($"[Alerta] ¡Quedan {evento.LugaresLibres} lugares!");
            }
        }
    }
}