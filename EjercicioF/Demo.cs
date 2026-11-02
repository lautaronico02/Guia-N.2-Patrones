using EjercicioF;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    // Ítem H: Justificación.
    //
    // Singleton (Bitácora)
    // Resuelve que haya 1 sola instancia de bitácora para toda la playa.
    // Sin singleton, los registros quedarían repartidos en muchas bitácoras propias para cada registro y nadie las tiene juntas como corresponde.
    // Además, cuando queramos llamar a MostrarTodo(), aparecería una bitácora nueva, recién instanciada, por ende, vacía.
    //
    // Strategy (ITarifa y sus estrategias)
    // Resuelve el hecho de tener que hacer un listado de muchos ifs o un switch entero para poder decidir qué tarifa aplicar.
    // Y sin el patrón Strategy, tendríamos que romper el principio Open/Closed, teniendo que abrir y modificar Playa.cs, simplemente para 
    // poder agregar una tarifa nueva, como por ejemplo una moto.
    //
    // Factory (TarifaFactory)
    // Resuelve convirtiendo los códigos de texto "HORA", "ESTADIA" y "NOCHE" a objetos a través del método TarifaFactory.Crear(), en un único lugar
    // haciendo que sea la correcta. Incluso avisando si llega un código inválido como "SEMANAL".
    // Y sin este patrón, el switch de TarifaFactory debería ir en el método Playa.Ingresar, mezclado con sus propias validaciones y avisos, 
    // inclusive si otra parte del sistema necesitara crear tarifas, habría que copiar TODO ese mismo switch para otra cosa.
    //
    // Observer (Playa y sus suscriptores)
    // Resuelve el no hacerle conocer a Playa.cs que existen las clases PantallaLugares, AlertaOcupacion, Caja y Bitacora,
    // sin quedar la clase Playa atada a 4 clases que nada tienen que ver con ella.
    // Además con Observer, los suscriptores se suscriben o desuscriben con el programa corriendo, sin el patrón no se podría.
    // Sin observer, es romper Open/Closed modificando los métodos Ingresar() y Egresar() para agregar avisos nuevos.
    public static class Demo
    {
        public static void Ejecutar()
        {
            var playa = new Playa(10);
            var pantalla = new PantallaLugares();
            playa.Suscribir(pantalla);
            playa.Suscribir(new CajaObserver());
            playa.Suscribir(new AlertaOcupacionObserver());
            playa.Suscribir(new BitacoraObserver());

            playa.Ingresar("SSD553", "HORA");
            playa.Ingresar("GRS163", "NOCHE");
            playa.Ingresar("CSS245", "ESTADIA");
            playa.Ingresar("GHW639", "ESTADIA");
            playa.Ingresar("SDS238", "NOCHE");
            playa.Ingresar("ZXQ742", "HORA");
            playa.Ingresar("RVO483", "HORA");
            playa.Ingresar("BYU281", "ESTADIA");

            playa.Egresar("SSD553", 150);
            playa.Egresar("CSS245", 900);

            playa.Desuscribir(pantalla);
            playa.Egresar("SDS238", 600);

            try { playa.Ingresar("XAZ332", "SEMANAL"); }
            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }

            Bitacora.Instancia.MostrarTodo();
        }
    }
}