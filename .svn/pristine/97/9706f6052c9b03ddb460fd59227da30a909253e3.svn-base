using System;
using System.Collections.Generic;

namespace DAC.Core.Security
{
    public class GroupUser
    {
        private Guid m_GroupID;
        private string m_LoginID;

        public GroupUser()
        {
            m_GroupID = new Guid();
            m_LoginID = string.Empty;
        }

        public GroupUser(Guid groupId, string sLoginID)
        {
            m_GroupID = groupId;
            m_LoginID = sLoginID;
        }
        
        public virtual Guid GroupID
        {
            get { return m_GroupID; }
            set { m_GroupID = value; }
        }

        public virtual string LoginID
        {
            get { return m_LoginID; }
            set { m_LoginID = value; }
        }
    }

    public class GroupUserCollection : List<GroupUser>
    {
    }
}
