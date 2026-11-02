using System;

namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }
    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje) // Creé métodos ficticios para probar y compilar nada más.
        => Console.WriteLine($"[MAIL a {destino}] {mensaje}");
    }
    public class NotificadorSms : INotificador
    {
        public void Enviar(string destino, string mensaje)
        => Console.WriteLine($"[SMS a {destino}] {mensaje}");


    }
    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            switch (canal)
            {
                case "MAIL": return new NotificadorMail();
                case "SMS": return new NotificadorSms();
                default: throw new ArgumentException($"Canal desconocido: {canal}");
            }
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            NotificadorFactory.Crear("MAIL").Enviar("nico@mail.com", "Hola");
            try { NotificadorFactory.Crear("WHATSAPP"); }
            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
        }
    }
}

// ¿Cuál es el error y de qué tipo es?:
// Es un error de compilación.
// El método Crear promete siempre devolver INotificador, y hay un camino que no devuelve nada,
// que es cuando el canal no es MAIL ni SMS.

// ¿Cómo se corrige?:
// Todos los caminos deben finalizar en un return o un throw
// (Me tomé la libertad de cambiarlo a un switch porque me parece más legible y simple a mí gusto)

// ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?:
// Porque es necesario marcar el problema en el momento que aparece.
// Si se utilizara un null, el error aparecería en otro lado cuando se intente utilizar el objeto,
// y como no hay una referencia al objeto que se llama, explota el programa y no te dice dónde exactamente.
// Con el throw, te dice dónde y cuándo exactamente.