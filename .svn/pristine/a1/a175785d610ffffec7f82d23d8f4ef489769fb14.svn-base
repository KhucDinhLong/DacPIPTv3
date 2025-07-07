using System;
using System.Collections.Generic;

namespace DAC.Core.Security
{
    public class Menu
    {
        private string m_MenuID;        
        private int m_MenuPosition;
        private string m_MenuValue;
        private string m_MenuFiliationID;
        private string m_FormName;

        public Menu()
        {
            m_MenuID = String.Empty;            
            m_MenuPosition = 0;
            m_MenuValue = String.Empty;
            m_MenuFiliationID = String.Empty;
            m_FormName = String.Empty;
        }

        public virtual string MenuID
        {
            get { return m_MenuID; }
            set { m_MenuID = value; }
        }        

        public virtual int MenuPosition
        {
            get { return m_MenuPosition; }
            set { m_MenuPosition = value; }
        }
        public virtual string MenuValue
        {
            get { return m_MenuValue; }
            set { m_MenuValue = value; }
        }
        public virtual string MenuFiliationID
        {
            get { return m_MenuFiliationID; }
            set { m_MenuFiliationID = value; }
        }
        public virtual string FormName
        {
            get { return m_FormName; }
            set { m_FormName = value; }
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Menu castObj = (Menu)obj;
            return (castObj != null) &&
                (this.m_MenuID == castObj.MenuID);
        }

        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * m_MenuID.GetHashCode();
            return hash;
        }
    }

    public class MenuCollection : List<Menu>
    {
    }
}
