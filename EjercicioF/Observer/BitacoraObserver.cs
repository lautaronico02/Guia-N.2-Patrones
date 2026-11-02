using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEventoPlaya.Ingreso) Bitacora.Instancia.Registrar($"Ingresó {evento.Patente}");
            else Bitacora.Instancia.Registrar($"Egresó {evento.Patente} {evento.Importe:N0}");
        }
    }
}