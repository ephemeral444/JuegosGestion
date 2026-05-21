using GestionJ_biblioteca.Entidades;
using Presentaciones_biblioteca.Interfaces;
using Newtonsoft.Json;


namespace Presentaciones_biblioteca.Implementaciones
{
    public class BibliotecaUsuarios_Presentacion : IBibliotecaUsuarios_Presentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<BibliotecaUsuarios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/BibliotecaUsuarios/Get";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<BibliotecaUsuarios>();

            return JsonConvert.DeserializeObject<List<BibliotecaUsuarios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/BibliotecaUsuarios/Post";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BibliotecaUsuarios();

            return JsonConvert.DeserializeObject<BibliotecaUsuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/BibliotecaUsuarios/Put";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BibliotecaUsuarios();

            return JsonConvert.DeserializeObject<BibliotecaUsuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5031/api/BibliotecaUsuarios/Delete";
            datos["Entidad"] = entidad;
            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new BibliotecaUsuarios();

            return JsonConvert.DeserializeObject<BibliotecaUsuarios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}