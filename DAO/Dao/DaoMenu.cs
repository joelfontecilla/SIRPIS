using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO.Dao
{
    public class DaoMenu
    {
        private DaoBase _dao;
        private List<SqlParameter> _list;
        public DaoMenu()
        {
            _dao = new DaoBase();
        }

        public IDataReader ConsultAllDepartment()
        {
            IDataReader result = null;
            _list = new List<SqlParameter>();
            string sql = string.Empty;

            sql = "SELECT DISTINCT D_NAME NOMBRE, '1' NIVEL, SUBSTR(D_NAME,0,3) as ID";
            sql += " FROM CMS.DCS";
            sql += " WHERE ACTIVE = '1'";

            try
            {
                result = _dao.Consult(sql,_list).Tables[0].CreateDataReader();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            return result;

        }
    }
}
