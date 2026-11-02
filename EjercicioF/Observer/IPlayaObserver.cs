using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioF
{
    public interface IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento);
    }
}