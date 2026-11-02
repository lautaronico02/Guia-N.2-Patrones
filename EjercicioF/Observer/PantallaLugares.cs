using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento) => Console.WriteLine($"[Pantalla] Lugares libres: {evento.LugaresLibres}");
    }
}