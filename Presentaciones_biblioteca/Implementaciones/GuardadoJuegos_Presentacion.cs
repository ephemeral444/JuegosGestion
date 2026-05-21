using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class GuardadoJuegos_Presentacion : IGuardadoJuegos_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<GuardadoJuegos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GuardadoJuegos/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<GuardadoJuegos>();

            return JsonConvert.DeserializeObject<List<GuardadoJuegos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public GuardadoJuegos Guardar(GuardadoJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GuardadoJuegos/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GuardadoJuegos();

            return JsonConvert.DeserializeObject<GuardadoJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public GuardadoJuegos Modificar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GuardadoJuegos/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GuardadoJuegos();

            return JsonConvert.DeserializeObject<GuardadoJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public GuardadoJuegos Eliminar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/GuardadoJuegos/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GuardadoJuegos();

            return JsonConvert.DeserializeObject<GuardadoJuegos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}