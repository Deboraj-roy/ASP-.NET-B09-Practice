using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ConnectionStringBuilder
    {
        private string _username;
        private string _password;
        private string _host;
        private int? _port;
        private string _database;
        private bool _trustedConnection;
        private bool _multipleActiveRecords;

        public ConnectionStringBuilder(string host, string database)
        {
            _host = host;
            _database = database;
        }
        public ConnectionStringBuilder SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }

        public ConnectionStringBuilder UseTrustedConnection() 
        {
            _trustedConnection = true;
            return this;
        }
        public ConnectionStringBuilder UseMultipleActiveRecords()
        {
            _multipleActiveRecords = true;
            return this;

        }
        public ConnectionStringBuilder UsePort(int port)
        {
            _port = port;
            return this;
        }
        public string GetConnectionString()
        {
            string port = _port.HasValue ? "," + _port : "";
            string credentials;

            if (!_trustedConnection)
            {
                credentials = $"User Id= {_username}; Password={_password};";
            }
            else
            {
                credentials = "Trusted_Connection = True;";
            }

            string activeRecordSet = string.Empty;

            if (_multipleActiveRecords)
            {
                activeRecordSet = "MultipleActiveResultSets = true;";
            }
            return $"Server={_host}{port};Database = {_database};{credentials}{activeRecordSet}";
        }
    }
}
