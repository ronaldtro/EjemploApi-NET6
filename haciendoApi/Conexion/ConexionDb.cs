namespace haciendoApi.Conexion
{
    public class ConexionDb
    {
        private string connectionString = string.Empty;

        public ConexionDb()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = builder.GetSection("ConnectionStrings:conexionMaestra").Value;
        }

        public string cadenaSql()
        {
            return connectionString;
        }

    }
}
