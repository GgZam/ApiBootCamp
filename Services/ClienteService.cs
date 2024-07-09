using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ClienteService : ICliente
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

        public ClienteService(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCliente(double clienteId, string? nombreCliente, double identificacion)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes;
                if (clienteId == 0 && nombreCliente == null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(c => c.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "ok";
                }
                else if (clienteId != 0 && nombreCliente == null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(c => c.Estado.Equals("A") && c.ClienteId.Equals(clienteId)).ToListAsync();
                    respuesta.Mensaje = "ok";
                }
                else if (clienteId == 0 && nombreCliente != null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(c => c.Estado.Equals("A") && c.ClienteNombre.Equals(nombreCliente)).ToListAsync();
                    respuesta.Mensaje = "ok";
                }
                else if (clienteId == 0 && nombreCliente == null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(c => c.Estado.Equals("A") && c.Cedula.Equals(identificacion)).ToListAsync();
                    respuesta.Mensaje = "ok";
                }
                else if (clienteId != 0 && nombreCliente != null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(c => c.Estado.Equals("A") && c.ClienteId.Equals(clienteId) && c.ClienteNombre.Equals(nombreCliente) && c.Cedula.Equals(identificacion)).ToListAsync();
                    respuesta.Mensaje = "ok";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ClienteService", "GetCliente", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes.OrderByDescending(c => c.ClienteId).Select(c => c.ClienteId).FirstOrDefault();

                cliente.ClienteId = Convert.ToInt32(query) + 1;
                cliente.FechaHoraReg = DateTime.Now;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ClienteService", "PostCliente", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ClienteService", "PutCliente", ee.Message);
            }
            return respuesta;
        }
    }
}
