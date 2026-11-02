using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioD1
{
    public interface ITemperaturaObserver
    {
        void Actualizar(double grados);
    }
    public class Termometro
    {
        private readonly List<ITemperaturaObserver> _observadores = new List<ITemperaturaObserver>();
        public void Suscribir(ITemperaturaObserver o) => _observadores.Add(o);
        public void Desuscribir(ITemperaturaObserver o) => _observadores.Remove(o);
        public void Medir(double grados)
        {
            Console.WriteLine($"Termómetro: {grados}°");
            foreach (var o in _observadores.ToList())
                o.Actualizar(grados);
        }
    }
    public class PantallaCocina : ITemperaturaObserver
    {
        public void Actualizar(double grados) => Console.WriteLine($" Pantalla: {grados}°");
    }
    public class AlarmaCalor : ITemperaturaObserver
    {
        public void Actualizar(double grados)
        {
            if (grados > 30)
                Console.WriteLine(" ¡Alarma! Hace demasiado calor");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var termo = new Termometro();
            termo.Suscribir(new PantallaCocina());
            termo.Suscribir(new AlarmaCalor());
            termo.Medir(25);
            termo.Medir(34);
        }
    }
}