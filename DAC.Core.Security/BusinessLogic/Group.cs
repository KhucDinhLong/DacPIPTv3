using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    public class Group
    {
        private Guid m_GroupID;        
        private string m_GroupName;
        private string m_Note;
        private bool m_IsAdmin;

        public Group()
        {
            m_GroupID = new Guid();            
            m_GroupName = String.Empty;
            m_Note = String.Empty;
            m_IsAdmin = false;
        }
        public virtual Guid GroupID
        {
            get { return m_GroupID; }
            set { m_GroupID = value; }
        }        

        public virtual string GroupName
        {
            get { return m_GroupName; }
            set { m_GroupName = value; }
        }

        public virtual string Note
        {
            get { return m_Note; }
            set { m_Note = value; }
        }

        public virtual bool IsAdmin
        {
            get { return m_IsAdmin; }
            set { m_IsAdmin = value; }
        }
    }

    public class GroupCollection : List<Group>
    { }
}
