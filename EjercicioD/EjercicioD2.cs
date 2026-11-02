using System;

namespace EjercicioD2
{
    public interface IDescuento
    {
        decimal Aplicar(decimal precio);
    }
    public class SinDescuento : IDescuento
    {
        public decimal Aplicar(decimal precio) => precio;
    }
    public class DescuentoJubilado : IDescuento // 15% de descuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.85m;
    }
    public class DescuentoEstudiante : IDescuento // 10% de descuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.90m;
    }
    public static class DescuentoFactory
    {
        public static IDescuento Crear(string tipo)
        {
            switch (tipo)
            {
                case "JUBILADO": return new DescuentoJubilado();
                case "ESTUDIANTE": return new DescuentoEstudiante();
                case "NINGUNO": return new SinDescuento();
                default: throw new ArgumentException($"Tipo desconocido: {tipo}");
            }
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            string tipoElegido = "JUBILADO";
            IDescuento descuento = DescuentoFactory.Crear(tipoElegido);
            Console.WriteLine(descuento.Aplicar(10000m).ToString("0"));
        }
    } 
}

// ¿Por qué en este caso la factory sí está justificada?:
// Porque siempre llega como texto de parte del usuario y no se sabe cuál será y se debe convertir en el objeto correcto en único lugar.

// Admito tener que revisar muchas veces esto, porque me costó pero ahora lo comprendo.