using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class Auditorias_Presentacion : IAuditorias_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Auditorias> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Auditorias/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Auditorias>();

            return JsonConvert.DeserializeObject<List<Auditorias>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Auditorias/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Auditorias/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Auditorias/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}