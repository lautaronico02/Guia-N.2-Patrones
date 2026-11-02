using System;
using System.Collections.Generic;

namespace EjercicioF
{
    public class Bitacora // Las 3 reglas para el patrón Singleton.
    {
        private static Bitacora _instancia;
        private List<string> _registros = new List<string>();
        private int _numero = 0;

        private Bitacora() { } // Constructor privado.


        public static Bitacora Instancia // Creación y/o devolución de la instancia.
        {
            get
            {
                if (_instancia is null)
                {
                    _instancia = new Bitacora();
                }
                return _instancia;
            }
        }

        public void Registrar(string texto) // Registro nuevo de la bitácora.
        {
            _numero++;
            _registros.Add($"{_numero:00}. {texto}");
        }

        public void MostrarTodo() // Muestra todos los registros.
        {
            Console.WriteLine("--- Bitácora ---");
            foreach (string t in _registros)
            {
                Console.WriteLine(t);
            }
        }
    }
}