using EjercicioB1;
using System;

namespace EjercicioB2
{

    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }
    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";
        public decimal Calcular(decimal total) => 0;
    }
    public class Propina10 : IPropina
    {
        public string Nombre => "10%";
        public decimal Calcular(decimal total) => total * 0.10m;
    }
    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;
        public PropinaFija(decimal monto) => _monto = monto;
        public string Nombre => "Fija";
        public decimal Calcular(decimal total) => _monto;
    }
    public class Cuenta
    {
        private IPropina _propina;
        public Cuenta(IPropina propina) => _propina = propina;
        public void CambiarPropina(IPropina propina) => _propina = propina;
        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);
            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var cuenta = new Cuenta(new SinPropina());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new Propina10());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new PropinaFija(1500));
            cuenta.Mostrar(20000);
        }
    }
}
// ¿Qué imprime?: Imprime en el siguiente orden
// Sin propina: 20000
// 10%: 22000
// Fija: 21500

// En este código, ¿quién es el contexto y quiénes son las estrategias?:
// El contexto es la clase Cuenta, y las estrategias son las clases SinPropina, Propina10 y PropinaFija.
// El contexto Cuenta, usa una estrategia que se decidirá a partir de lo que el cliente pide y nunca sabe cuál es, 
// porque siempre la ve como IPropina.

// ¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?:
// No se debió modificar nada, ya que el contexto (la clase Cuenta) toma la interfaz IPropina siempre, y cada clase estrategia que 
// se instancie, implementará esa interfaz y decidirá qué es. 
// Por lo tanto, se cumple el principio Open/Closed: abierto a extensión, cerrado a modificación.

// Buen ejercicio para terminar de comprender Strategy, me resultó más fácil entenderlo con este.