using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class CajaObserver : IPlayaObserver
    {
        private decimal _recaudado = 0;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo != TipoEventoPlaya.Egreso) return;
            _recaudado += evento.Importe;
            Console.WriteLine($"[Caja] Cobrado $ {evento.Importe:N0} a {evento.Patente}. Recaudado: $ {_recaudado:N0}");
        }
    }
}