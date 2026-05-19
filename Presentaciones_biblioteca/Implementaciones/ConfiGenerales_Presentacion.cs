using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class ConfiGenerales_Presentacion : IConfiGenerales_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<ConfiGenerales> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfiGenerales/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<ConfiGenerales>();

            return JsonConvert.DeserializeObject<List<ConfiGenerales>>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGenerales Guardar(ConfiGenerales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfiGeneral/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGenerales();

            return JsonConvert.DeserializeObject<ConfiGenerales>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGenerales Modificar(ConfiGenerales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfiGenerales/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGenerales();

            return JsonConvert.DeserializeObject<ConfiGenerales>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGenerales Eliminar(ConfiGenerales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/ConfiGenerales/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGenerales();

            return JsonConvert.DeserializeObject<ConfiGenerales>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}