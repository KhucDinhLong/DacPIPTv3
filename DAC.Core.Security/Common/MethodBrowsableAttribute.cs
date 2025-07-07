using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    [Serializable]
    class MethodBrowsableAttribute : Attribute
    {
        private bool m_Browsable;
        public MethodBrowsableAttribute() { }
        public MethodBrowsableAttribute(bool browsable)
        {
            this.m_Browsable = browsable;
        }
        public bool Browsable
        {
            get { return m_Browsable; }
        }
    }
}
