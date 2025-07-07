using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    public class MenuGroup
    {
        private Guid m_GroupID;
        private string m_MenuID;

        public MenuGroup()
        {
            m_GroupID = new Guid();
            m_MenuID = string.Empty;
        }

        public virtual Guid GroupID
        {
            get { return m_GroupID; }
            set { m_GroupID = value; }
        }
        public virtual string MenuID
        {
            get { return m_MenuID; }
            set { m_MenuID = value; }
        }
    }

    public class MenuGroupCollection : List<MenuGroup>
    { }
}
