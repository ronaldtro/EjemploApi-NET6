using haciendoApi.Datos;
using haciendoApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace haciendoApi.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController: ControllerBase
    {
        [HttpGet] //ActionResult = codigo 200,300..
        public async Task <ActionResult<List <ModeloProducto>>> Get()
        {
            var funcion = new DatoProducto();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] ModeloProducto parametros)
        {
            var funcion = new DatoProducto();
            await funcion.InsertarProducto(parametros);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] ModeloProducto producto)
        {
            var funcion = new DatoProducto();
            producto.id = id;
            await funcion.EditarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new DatoProducto();
            var mProducto = new ModeloProducto();
            mProducto.id = id;
            await funcion.EliminarProducto(mProducto);
            return NoContent();
        }
    }
}
