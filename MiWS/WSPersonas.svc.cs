using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace MiWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WSPersonas : IWSPersonas
    {
        public Persona ObtenerPersona(string Identificacion)
        {
            /*var cadena = "";
            switch (filtro)
            {
                case "character":
                    cadena = "https://gateway.marvel.com:443/v1/public/characters/" + Identificacion + "?ts=1&apikey=a90d074cc0483b65fe3c15a6c9970912&hash=792414c616577193fbe3817ba81822a8";
                    break;
                case "comic":
                    cadena = "https://gateway.marvel.com:443/v1/public/characters/" + Identificacion + "/comics?ts=1&apikey=a90d074cc0483b65fe3c15a6c9970912&hash=792414c616577193fbe3817ba81822a8";
                    break;
                case "creator":
                    cadena = "https://gateway.marvel.com:443/v1/public/characters/" + Identificacion + "/comics?ts=1&apikey=a90d074cc0483b65fe3c15a6c9970912&hash=792414c616577193fbe3817ba81822a8";
                    break;
            }*/
            string url = "https://gateway.marvel.com:443/v1/public/characters/1009368/comics?ts=1&apikey=a90d074cc0483b65fe3c15a6c9970912&hash=792414c616577193fbe3817ba81822a8";
            var arrayDatos = new WebClient().DownloadString(url);
            dynamic json = JsonConvert.DeserializeObject(arrayDatos);
            string idLista = "";
            var numElem = 1;
            foreach (var result in json.data.results)
            {
                Console.WriteLine(result.id);
                if (numElem > 1)
                {
                    idLista = idLista + "," + result.id;
                }
                else
                {
                    idLista = result.id;
                }
                numElem++;
            }
            // hasta aquí ya tengo la lista de comics filtrada por id de personaje
            if (Identificacion == "0")
            {
                return new Persona() { Nombre = idLista, Edad = 99 };
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
