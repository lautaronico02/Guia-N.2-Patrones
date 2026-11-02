using System;

namespace EjercicioB1
{
    public class Contador
    {
        private static Contador _instancia;
        private int _valor = 0;

        private Contador() { Console.WriteLine("Creando contador"); }

        public static Contador Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Contador();
                return _instancia;
            }
        }

        public int Siguiente()
        {
            _valor++;
            return _valor;
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var a = Contador.Instancia;
            var b = Contador.Instancia;
            Console.WriteLine(a.Siguiente());
            Console.WriteLine(b.Siguiente());
            Console.WriteLine(Contador.Instancia.Siguiente());
            Console.WriteLine(ReferenceEquals(a, b));
        }
    }
}

// ¿Qué imprime?: Imprime en el siguiente orden
// Creando contador
// 1
// 2
// 3
// True

// ¿Cuántas veces aparece "Creando contador" y por qué?: 1 sola, ya que es la primera y única vez que se crea el contador
// cuando se le llama por primera vez, al verificar cada vez con el If que ya no es nulo, no la imprime de nuevo.

// ¿Por qué b.Siguiente() no devuelve 1?: Porque siempre pasa por el proceso del método Siguiente(), 
// que hace que cada vez que se llame haga ++ y se sume 1 más al valor del contador y aunque llame a o b, sigue siendo el mismo contador y hace la suma siempre.


// Al principio me confundí y ver el valor a y el b me hizo pensar que eran 2 contadores pero es el mismo con ++, porque es patrón Singleton
// y después recordé la teoría.
// Y por los ejemplos que ví no me di cuenta al principio del método Siguiente() que sucede entre llamada y llamada a la instancia.