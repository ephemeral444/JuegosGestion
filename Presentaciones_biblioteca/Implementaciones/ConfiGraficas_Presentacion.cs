using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class ConfiGraficas_Presentacion : IConfiGraficas_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<ConfiGraficas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/ConfiGraficas/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<ConfiGraficas>();

            return JsonConvert.DeserializeObject<List<ConfiGraficas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGraficas Guardar(ConfiGraficas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/ConfiGraficas/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGraficas();

            return JsonConvert.DeserializeObject<ConfiGraficas>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGraficas Modificar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/ConfiGraficas/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGraficas();

            return JsonConvert.DeserializeObject<ConfiGraficas>(
                respuesta["Valor"].ToString()!)!;
        }

        public ConfiGraficas Eliminar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/ConfiGraficas/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new ConfiGraficas();

            return JsonConvert.DeserializeObject<ConfiGraficas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}