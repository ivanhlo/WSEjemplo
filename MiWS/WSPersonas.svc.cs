using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MiWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WSPersonas : IWSPersonas
    {
        public Persona ObtenerPersona(string Identificacion)
        {
            if (Identificacion == "0")
            {
                return new Persona() { Nombre = "Felipe", Edad = 99 };
            }
            else if (Identificacion == "1")
            {
                return new Persona() { Nombre = "Patricia", Edad = 24 };
            }
            else
            {
                return new Persona() { Error = "Persona no encontrada" };
            }
        }
    }
}
