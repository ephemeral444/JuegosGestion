using Bailes_Biblioteca.Entidades;
using Bailes_Presentaciones.Interfaces;
using Newtonsoft.Json;

namespace Bailes_Presentaciones.Implementaciones
{
    public class Bailarinas_Presentacion : IBailarinas_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Bailarinas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Bailarinas/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Bailarinas>();

            return JsonConvert.DeserializeObject<List<Bailarinas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bailarinas Guardar(Bailarinas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Bailarinas/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bailarinas();

            return JsonConvert.DeserializeObject<Bailarinas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bailarinas Modificar(Bailarinas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Bailarinas/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bailarinas();

            return JsonConvert.DeserializeObject<Bailarinas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bailarinas Eliminar(Bailarinas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Bailarinas/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bailarinas();

            return JsonConvert.DeserializeObject<Bailarinas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}