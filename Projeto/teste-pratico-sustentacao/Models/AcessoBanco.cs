using Oracle.ManagedDataAccess.Client;
namespace teste_pratico_sustentacao.Models
{
    public class AcessoBanco
    {
        public OracleConnection Conexao
        {
            get
            {
                var path = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XEPDB1))); User Id = system; Password = 123;";
                return new OracleConnection(path);
            }
        }
    }
}
