using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class Estadisticas_Presentacion : IEstadisticas_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Estadisticas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Estadisticas/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Estadisticas>();

            return JsonConvert.DeserializeObject<List<Estadisticas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estadisticas Guardar(Estadisticas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Estadisticas/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estadisticas();

            return JsonConvert.DeserializeObject<Estadisticas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estadisticas Modificar(Estadisticas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Estadisticas/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estadisticas();

            return JsonConvert.DeserializeObject<Estadisticas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Estadisticas Eliminar(Estadisticas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5081/api/Estadisticas/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Estadisticas();

            return JsonConvert.DeserializeObject<Estadisticas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}