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


        //Validacion Correo electronico

        public static bool EsCorreoElectronicoValido(string correoElectronico)
        {
            var trimmedEmail = correoElectronico.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(correoElectronico);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        //Fecha nacimiento futura

        public static bool EsFechaNacimientoFutura(DateOnly fechaNacimiento)
        {
            var hoy = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return (fechaNacimiento >= hoy ? false : true);

        }



    }

}

