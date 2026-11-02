using System;

namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }
    public class Canal
    {
        private readonly List<IObservador> _suscriptores = new List<IObservador>();
        public void Suscribir(IObservador o) => _suscriptores.Add(o);
        public void Desuscribir(IObservador o) => _suscriptores.Remove(o);
        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");
            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }
    public class Fan : IObservador
    {
        private readonly string _nombre;
        public Fan(string nombre) => _nombre = nombre;
        public void Actualizar(string video) => Console.WriteLine($" {_nombre} mira {video}");
    }
    public class Estadisticas : IObservador
    {
        private int _avisos = 0;
        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var canal = new Canal();
            var lu = new Fan("Lu");
            canal.Suscribir(lu);
            canal.Suscribir(new Fan("Tomi"));
            canal.Suscribir(new Estadisticas());
            canal.Publicar("Patrones en C#");
            canal.Desuscribir(lu);
            canal.Publicar("Observer en WinForms");
        }
    }
}

// Qué imprime, en orden:
//
//Nuevo video: Patrones en C#
// Lu mira Patrones en C#
// Tomi mira Patrones en C#
// Avisos registrados: 1
// Nuevo video: Observer en WinForms
// Tomi mira Observer en WinForms
// Avisos registrados: 2

// ¿Por qué Lu no aparece en la segunda publicación?:
// Lu no aparece en la segunda publicación porque primero se la desuscribió del canal, 
// lo cual hace que el método Publicar, con el foreach cuando recorra la lista, no la encuentre.

// ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?:
// No, no la conoce, sólo conoce a la interfaz IObservador, que es el tipo de su lista,
// y de los parámetros de Suscribir y Desuscribir.
// La prueba de esto es que no se referencia nunca a Fan dentro de Canal.

// Cuesta observer la verdad, se entiende con la analogía de la suscripción como Youtube, pero terminé de entender
// cómo es que Canal no conoce a Fan.