using System.Collections.Generic;

namespace DAC.Core.Security
{
    public class Module
    {
        private int m_ModuleID;        
        private string m_ModuleName;
        private string m_Note;

        public Module()
        {
            m_ModuleID = -1;            
            m_ModuleName = string.Empty;
            m_Note = string.Empty;
        }

        public virtual int ModuleID
        {
            get { return m_ModuleID; }
            set { m_ModuleID = value; }
        }      

        public virtual string ModuleName
        {
            get { return m_ModuleName; }
            set { m_ModuleName = value; }
        }

        public virtual string Note
        {
            get { return m_Note; }
            set { m_Note = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Module castObj = (Module)obj;
            return (castObj != null) &&
                (this.m_ModuleID == castObj.ModuleID);
        }

        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * m_ModuleID.GetHashCode();
            return hash;
        }
    }

    public class ModuleCollection : List<Module>
    { }
}
