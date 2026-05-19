using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class ConfigAudios_Presentacion : IConfigAudios_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<ConfigAudios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfigAudios/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<ConfigAudios>();

            return JsonConvert.DeserializeObject<List<ConfigAudios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfigAudios Guardar(ConfigAudios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfigAudios/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfigAudios();

            return JsonConvert.DeserializeObject<ConfigAudios>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfigAudios Modificar(ConfigAudios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfigAudios/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfigAudios();

            return JsonConvert.DeserializeObject<ConfigAudios>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfigAudios Eliminar(ConfigAudios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfigAudios/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfigAudios();

            return JsonConvert.DeserializeObject<ConfigAudios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}