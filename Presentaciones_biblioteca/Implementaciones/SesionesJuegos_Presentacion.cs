using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class SesionesJuegos_Presentacion : ISesionesJuegos_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<SesionesJuegos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/SesionesJuegos/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<SesionesJuegos>();

            return JsonConvert.DeserializeObject<List<SesionesJuegos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public SesionesJuegos Guardar(SesionesJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/SesionesJuegos/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SesionesJuegos();

            return JsonConvert.DeserializeObject<SesionesJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public SesionesJuegos Modificar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/SesionesJuegos/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SesionesJuegos();

            return JsonConvert.DeserializeObject<SesionesJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public SesionesJuegos Eliminar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/SesionesJuegos/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new SesionesJuegos();

            return JsonConvert.DeserializeObject<SesionesJuegos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}