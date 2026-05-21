using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class Permisos_Presentacion : IPermisos_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Permisos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Permisos/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Permisos>();

            return JsonConvert.DeserializeObject<List<Permisos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Permisos Guardar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Permisos/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Permisos();

            return JsonConvert.DeserializeObject<Permisos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Permisos Modificar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Permisos/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Permisos();

            return JsonConvert.DeserializeObject<Permisos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Permisos Eliminar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Permisos/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Permisos();

            return JsonConvert.DeserializeObject<Permisos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}