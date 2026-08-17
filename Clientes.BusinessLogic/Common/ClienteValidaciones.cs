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

        public static bool EsFechaNacimientoFutura(DateTime fechaNacimiento)
        {
            return (fechaNacimiento >= DateTime.Now ? false : true);

        }



    }

}

