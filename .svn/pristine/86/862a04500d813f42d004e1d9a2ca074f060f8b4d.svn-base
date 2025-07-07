using System.Data.SqlClient;

namespace DAC.DAL
{
    public class GetDacDbConnection
    {
        public static string ConnectionString
        {
            get;
            set;
        }
    }
    public class DacDbConnection
    {
        private static SqlConnection _cnn = new SqlConnection(GetDacDbConnection.ConnectionString);
        public static SqlConnection SqlConnection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        public static void Open()
        {
            if (_cnn.State == System.Data.ConnectionState.Closed || _cnn.State == System.Data.ConnectionState.Connecting)
                _cnn.Open();
        }

        public static void Close()
        {
            if (_cnn != null && _cnn.State == System.Data.ConnectionState.Open)
                _cnn.Close();
        }
    }
}