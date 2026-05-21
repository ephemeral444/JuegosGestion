using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class GestorArchivos_Presentacion : IGestorArchivos_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<GestorArchivos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GestorArchivos/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<GestorArchivos>();

            return JsonConvert.DeserializeObject<List<GestorArchivos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public GestorArchivos Guardar(GestorArchivos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GestorArchivos/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GestorArchivos();

            return JsonConvert.DeserializeObject<GestorArchivos>(
                respuesta["Valor"].ToString()!)!;
        }

        public GestorArchivos Modificar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GestorArchivos/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GestorArchivos();

            return JsonConvert.DeserializeObject<GestorArchivos>(
                respuesta["Valor"].ToString()!)!;
        }

        public GestorArchivos Eliminar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GestorArchivos/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GestorArchivos();

            return JsonConvert.DeserializeObject<GestorArchivos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}