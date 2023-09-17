using System.Data.SqlClient;

namespace SistemaLoginWPF.Repositories
{
    public class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server=localhost,1433;Database=MVVMSistemaLoginWPF;User ID=sa;Password=M4rc3l0@2*23;Trusted_Connection=False; TrustServerCertificate=True;";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
