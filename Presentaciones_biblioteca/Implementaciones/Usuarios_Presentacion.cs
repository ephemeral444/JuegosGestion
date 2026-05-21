using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class Usuarios_Presentacion : IUsuarios_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Usuarios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Usuarios/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Usuarios>();

            return JsonConvert.DeserializeObject<List<Usuarios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Usuarios/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Usuarios();

            return JsonConvert.DeserializeObject<Usuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Usuarios/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Usuarios();

            return JsonConvert.DeserializeObject<Usuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Eliminar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Usuarios/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Usuarios();

            return JsonConvert.DeserializeObject<Usuarios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}