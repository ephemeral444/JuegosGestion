using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class ControlJuegos_Presentacion : IControlJuegos_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<ControlJuegos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ControlJuegos/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<ControlJuegos>();

            return JsonConvert.DeserializeObject<List<ControlJuegos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public ControlJuegos Guardar(ControlJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ControlJuegos/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ControlJuegos();

            return JsonConvert.DeserializeObject<ControlJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public ControlJuegos Modificar(ControlJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ControlJuegos/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ControlJuegos();

            return JsonConvert.DeserializeObject<ControlJuegos>(
                respuesta["Valor"].ToString()!)!;
        }

        public ControlJuegos Eliminar(ControlJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ControlJuegos/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ControlJuegos();

            return JsonConvert.DeserializeObject<ControlJuegos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}