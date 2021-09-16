using Infrastructure.Data;
using System;
using System.Linq;

namespace Business.MainModule
{
    public class LoginBusiness
    {
        private SqlContext ctx;
        public LoginBusiness()
        {
            ctx = new SqlContext();
        }

        public bool LoginUser(string nameuser,string psw)
        {
            var objLog=ctx.Usuarios.SingleOrDefault(e=>e.Tusername==nameuser && e.Tpassword==psw);
            if (objLog is null)
            {
                return false;
            }
            return true;
        }
    }
}
