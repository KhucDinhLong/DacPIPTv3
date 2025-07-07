using System;
using System.Collections.Generic;

namespace DAC.Core.Security
{
    public class GroupAuthorization
    {
        private Guid m_GroupID;
        private Guid m_AuthorizationID;
        private Group m_Group;
        private Authorization m_Authorization;

        public GroupAuthorization()
        {            
            m_GroupID = new Guid();
            m_AuthorizationID = new Guid();
            m_Group = null;
            m_Authorization = null;
        }

        public GroupAuthorization(Guid groupID, Guid authorizationID)
        {
            m_GroupID = groupID;
            m_AuthorizationID = authorizationID;            
        }
      
        public virtual Guid GroupID
        {
            get { return m_GroupID; }
            set { m_GroupID = value; }
        }
        public virtual Guid AuthorizationID
        {
            get { return m_AuthorizationID; }
            set { m_AuthorizationID = value; }
        }
        public virtual Group Group
        {
            get { return m_Group; }
            set { m_Group = value; }
        }
        public virtual Authorization Authorization
        {
            get { return m_Authorization; }
            set { m_Authorization = value; }
        } 
    }

    public class GroupAuthorizationCollection : List<GroupAuthorization>
    {
    }
}
