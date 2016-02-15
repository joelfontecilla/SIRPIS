using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Comun.Entidades;

namespace Controlador.Translator
{
    public class MenuTranslator
    {
        private Menu _menu;
        private Menu[] _menus;

        public MenuTranslator(){}

        private Menu NewMenu(string ID, string NOMBRE, string NIVEL)
        {
            _menu = new Menu();
            _menu.ID = ID;
            _menu.Nombre = NOMBRE;
            _menu.Nivel = NIVEL;
            _menu.Activo = true;
            return _menu;
        }

        public Menu GetMenu(IDataReader param)
        {
            _menu = null;
            if (param.Read())
            {
                string id = (!param.IsDBNull(param.GetOrdinal("ID"))) ? (param.GetString(param.GetOrdinal("ID"))) : string.Empty;
                string nombre = (!param.IsDBNull(param.GetOrdinal("NOMBRE"))) ? (param.GetString(param.GetOrdinal("NOMBRE"))) : string.Empty;
                string nivel = (!param.IsDBNull(param.GetOrdinal("NIVEL"))) ? (param.GetString(param.GetOrdinal("NIVEL"))) : string.Empty;
                _menu = NewMenu(id, nombre, nivel);
            }
            return _menu;
        }

        public Menu[] GetMenus(IDataReader param)
        {
            _menus = null;

            if (param.Read())
            {
                List<Menu> list = new List<Menu>();
                while (param.Read())
                {
                    string id = (!param.IsDBNull(param.GetOrdinal("ID"))) ? (param.GetString(param.GetOrdinal("ID"))) : string.Empty;
                    string nombre = (!param.IsDBNull(param.GetOrdinal("NOMBRE"))) ? (param.GetString(param.GetOrdinal("NOMBRE"))) : string.Empty;
                    string nivel = (!param.IsDBNull(param.GetOrdinal("NIVEL"))) ? (param.GetString(param.GetOrdinal("NIVEL"))) : string.Empty;
                    list.Add(NewMenu(id, nombre, nivel));
                }
                _menus = list.ToArray();
            }

            return _menus;
        }

    }
}
