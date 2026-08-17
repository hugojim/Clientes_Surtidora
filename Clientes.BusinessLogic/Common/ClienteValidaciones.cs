using Clientes.DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Common
{
    public static class ClienteValidaciones
    {



        //Fecha nacimiento futura

        public static bool EsFechaNacimientoFutura(DateOnly? fechaNacimiento)
        {
            var hoy = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return (fechaNacimiento >= hoy ? false : true);

        }



    }

}

