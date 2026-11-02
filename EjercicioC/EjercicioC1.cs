using System.Collections.Generic;
using System;

namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);
        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");
            foreach (var o in _observadores.ToList()) // Estaba recorriendo una lista modificada en tiempo de ejecución.
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
        }
    }
}


// ¿Cuál es el error y de qué tipo es?:
// El error era que al recorrer la lista, dicha lista se modificaba al mismo tiempo, 
// lo cual es un error en ejecución, o sea una excepción InvalidOperationException.


// ¿Por qué ocurre?:
// AvisoUnico al hacer su método Actualizar(), llama a Desuscribir(this), que hace un .Remove sobre la lista _observadores 
// mientras el foreach de Sonar la recorre al mismo tiempo.

// ¿Cómo se corrige?:
// Se le debe agregar el método .ToList(). Al agregar .ToList() dentro del foreach, se genera una copia de la lista original,
// para recorrer esa y no la original.
// Con la correción, recorre la COPIA de esa lista, Desuscribir quita AvisoUnico de la lista ORIGINAL,
// y como son dos listas distintas, se recorre tranquilamente la copia y ya no hay excepción.

// Llegué a pensar que era un error de compilación por no recordar que aunque se llamen igual los parámetros, existen localmente cada uno
// Medio tramposo el ejercicio si no tenés bien instalado C# y sintáxis en general en la cabeza.