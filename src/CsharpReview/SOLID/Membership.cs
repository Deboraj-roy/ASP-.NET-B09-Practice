using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Membership
    {
        public void CreateAccount(string username, string password)
        {
            string encrypePassword = EncryptPassWord(password);
            //more code
        }
        private string EncryptPassWord(string passWord)
        {
            throw new NotImplementedException();
            //apply your encryption algorithm
        }
    }
}
