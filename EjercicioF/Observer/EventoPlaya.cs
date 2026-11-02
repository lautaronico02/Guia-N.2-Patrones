using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public enum TipoEventoPlaya
    {
        Ingreso,
        Egreso
    }

    public class EventoPlaya
    {
        public TipoEventoPlaya Tipo { get; }
        public string Patente { get; }
        public decimal Importe { get; }
        public int LugaresLibres {  get; }

        public EventoPlaya(TipoEventoPlaya tipo, string patente, decimal importe, int lugaresLibres)
        {
            Tipo = tipo;
            Patente = patente;
            Importe = importe;
            LugaresLibres = lugaresLibres;
        }
    }
}
