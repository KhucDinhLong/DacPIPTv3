using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    public class Authorization
    {
        private Guid m_AuthorizationID;
        private string m_Title;
        private string m_Description;
        private string m_MethodFullName;
        private int m_ModuleID;

        public Authorization()
        {
            m_AuthorizationID = new Guid();
            m_Title = String.Empty;
            m_Description = String.Empty;
            m_MethodFullName = String.Empty;
            m_ModuleID = -1;
        }
        public virtual Guid AuthorizationID
        {
            get { return m_AuthorizationID; }
            set { m_AuthorizationID = value; }
        }

        public virtual string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public virtual string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        public virtual string MethodFullName
        {
            get { return m_MethodFullName; }
            set { m_MethodFullName = value; }
        }

        public virtual int ModuleID
        {
            get { return m_ModuleID; }
            set { m_ModuleID = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Authorization castObj = (Authorization)obj;
            return (castObj != null) &&
                (this.m_AuthorizationID == castObj.AuthorizationID);
        }

        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * m_AuthorizationID.GetHashCode();
            return hash;
        }
    }

    public class AuthorizationCollection : List<Authorization>
    {}
}
