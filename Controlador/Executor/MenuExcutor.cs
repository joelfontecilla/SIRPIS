using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun.Entidades;
using Controlador.Translator;
using DAO.Dao;

namespace Controlador.Executor
{
    public class MenuExecutor
    {
        private DaoMenu _dao;
        private MenuTranslator _translator;

        public MenuExecutor()
        {
            _dao = new DaoMenu();
            _translator = new MenuTranslator();
        }

        public Menu[] ExcuteConsultAllDeparment()
        {
            Menu[] deparments = null;
            try
            {
                deparments = _translator.GetMenus(_dao.ConsultAllDepartment());
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return deparments;
        }

        public void menu() { }
    }
}
