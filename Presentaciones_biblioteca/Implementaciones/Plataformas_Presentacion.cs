using GestionJ_biblioteca.Entidades;
using Newtonsoft.Json;
using Presentaciones_biblioteca.Interfaces;

namespace Presentaciones_biblioteca.Implementaciones
{
    public class Plataformas_Presentacion : IPlataformas_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Plataformas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Plataformas/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Plataformas>();

            return JsonConvert.DeserializeObject<List<Plataformas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Plataformas Guardar(Plataformas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Plataformas/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Plataformas();

            return JsonConvert.DeserializeObject<Plataformas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Plataformas Modificar(Plataformas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Plataformas/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Plataformas();

            return JsonConvert.DeserializeObject<Plataformas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Plataformas Eliminar(Plataformas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/Plataformas/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Plataformas();

            return JsonConvert.DeserializeObject<Plataformas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}