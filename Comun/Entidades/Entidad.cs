using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.Entidades
{
    [Serializable]
    public class Entidad
    {
        private object _id;

        public object ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
