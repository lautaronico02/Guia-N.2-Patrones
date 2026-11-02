using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EjercicioF
{
    public class Playa
    {
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();
        private readonly int _capacidad;
        private List<Vehiculo> _vehiculos = new List<Vehiculo>();

        public Playa(int capacidad) => _capacidad = capacidad;

        public int LugaresLibres => _capacidad - _vehiculos.Count;
        public void Suscribir(IPlayaObserver o) => _observadores.Add(o);

        public void Desuscribir(IPlayaObserver o) => _observadores.Remove(o);

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente)) throw new ArgumentException("La patente es obligatoria.");
            if (_vehiculos.Find(v => v.Patente == patente) != null) throw new InvalidOperationException($"La patente {patente} ya está en el playón.");
            if (LugaresLibres == 0) throw new InvalidOperationException("No quedan lugares libres por el momento.");
            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos.Add(new Vehiculo { Patente = patente, Tarifa = tarifa });
            Notificar(new EventoPlaya(TipoEventoPlaya.Ingreso ,patente, 0,LugaresLibres));
        }

        public decimal Egresar(string patente, int minutos)
        {
            Vehiculo vehiculo = _vehiculos.Find(v =>v.Patente == patente);
            if (vehiculo == null) throw new InvalidOperationException($"La patente {patente} no se encuentra en el playón.");
            decimal importe = vehiculo.Tarifa.Calcular(minutos);
            _vehiculos.Remove(vehiculo);
            Notificar(new EventoPlaya(TipoEventoPlaya.Egreso, patente, importe, LugaresLibres));
            return importe;
        }

        private void Notificar(EventoPlaya evento)
        {
            foreach (var o in _observadores.ToList())
            {
                o.Actualizar(evento);
            }
        }
    }
}