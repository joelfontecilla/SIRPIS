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

        public Menu GetMenu(IDataReader param)
        {
            _menu = null;
            if (param.Read())
            {
                _menu = new Menu();
                _menu.ID = (!param.IsDBNull(param.GetOrdinal("ID"))) ? (param.GetString(param.GetOrdinal("ID"))) : string.Empty;
                _menu.Nombre = (!param.IsDBNull(param.GetOrdinal("NOMBRE"))) ? (param.GetString(param.GetOrdinal("NOMBRE"))) : string.Empty;
                _menu.Nivel = (!param.IsDBNull(param.GetOrdinal("NIVEL"))) ? (param.GetString(param.GetOrdinal("NIVEL"))) : string.Empty;
                _menu.Activo = true;
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
                    _menu = new Menu();
                    _menu.ID = (!param.IsDBNull(param.GetOrdinal("ID"))) ? (param.GetString(param.GetOrdinal("ID"))) : string.Empty;
                    _menu.Nombre = (!param.IsDBNull(param.GetOrdinal("NOMBRE"))) ? (param.GetString(param.GetOrdinal("NOMBRE"))) : string.Empty;
                    _menu.Nivel = (!param.IsDBNull(param.GetOrdinal("NIVEL"))) ? (param.GetString(param.GetOrdinal("NIVEL"))) : string.Empty;
                    _menu.Activo = true;
                    list.Add(_menu);
                }
                _menus = list.ToArray();
            }

            return _menus;
        }

    }
}
