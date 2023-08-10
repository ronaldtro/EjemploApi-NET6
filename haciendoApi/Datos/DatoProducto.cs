using haciendoApi.Conexion;
using haciendoApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace haciendoApi.Datos
{
    public class DatoProducto
    {
        ConexionDb cn = new ConexionDb();
        public async Task<List<ModeloProducto>> MostrarProductos()
        {
            var lista = new List<ModeloProducto>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var cmd = new SqlCommand("mostrarProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProductos = new ModeloProducto();

                            mProductos.id = (int)item["id"];
                            mProductos.descripcion = (string)item["descripcion"];
                            mProductos.precio = (decimal)item["precio"];
                            lista.Add(mProductos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProducto(ModeloProducto producto)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var cmd = new SqlCommand("insertarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task EditarProducto(ModeloProducto producto)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var cmd = new SqlCommand("editarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", producto.id);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task EliminarProducto(ModeloProducto producto)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var cmd = new SqlCommand("eliminarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", producto.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

        }

    }
}
