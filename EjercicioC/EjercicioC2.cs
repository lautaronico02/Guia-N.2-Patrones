using System;

namespace EjercicioC2
{

    public interface IEnvioStrategy
    {
        string tipo { get; }

        decimal Calcular(decimal pesoKg);
    }
    public class Moto : IEnvioStrategy
    {
        public string tipo => "Moto";
        public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    }
    public class Camion : IEnvioStrategy
    {
        public string tipo => "Camión";
        public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    }
    public class Bicicleta : IEnvioStrategy
    {
        public string tipo => "Bicicleta";
        public decimal Calcular(decimal pesoKg) => 1000 + pesoKg * 10;
    }
    public class Estandar : IEnvioStrategy
    {
        public string tipo => "Estándar";
        public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    }
}


// ¿Cuál es el error y de qué tipo es?:
// Es un error de diseño, ya que nunca utiliza Strategy al sólo recorrer ifs,
// y encima, rompe el principio Open/Closed.

// ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?:
// Devuelve 3000 + pesoKg * 70, como si fuera un Default si no es moto o camión
// Lo grave es que uno puede pasar una bicicleta o una camioneta 
// y siempre cobrará lo mismo por cualquier otra que no sea moto o camión.
// Para darle a la bicicleta su tarifa hay que abrir EnvioStrategy y agregar otro if.

// ¿Cómo se corrige? (escribí las clases):
// Corrección aplicada, ya utilizando Strategy como corresponde.
// Una clase por estrategia, sin if, y con el manejo de una opción "Estándar". 
// Si llega un tipo que no tiene estrategia propia, se debe utilizar simple factory,
// para lanzar una excepción.

// Me tomé la libertad de agregar a mano la clase Bicicleta inventada para que se vea que así quedaría
// cumpliendo el principio Open/Closed.