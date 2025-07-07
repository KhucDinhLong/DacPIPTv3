using System;
using System.Collections.Generic;

namespace DAC.Core.Security
{
    public enum UserStatus
    {
        OK = 1,
        Locked = 2,
        ExpiredDate = 3,
        NotExists = 4
    }
    public class User
    {
        private string          m_LoginID;
        private string          m_Password;
        private string          m_FullName;
        private string          m_Email;
        private DateTime        m_CreatedDate;
        private bool            m_LockedUser;
        private DateTime        m_LockedDate;
        private string          m_LockedReason;
        private DateTime        m_LastLogIn;
        private DateTime        m_LastChangedPassword;
        private DateTime        m_DeadlineOfUsing;

        public User()
        {
            m_LoginID = string.Empty;
            m_Password = string.Empty;
            m_FullName = string.Empty;
            m_Email = string.Empty;

            DateTime dtmDefault = new DateTime(1900, 1, 1);
            m_CreatedDate = dtmDefault;
            m_LockedUser = false;
            m_LockedDate = dtmDefault;
            m_LockedReason = string.Empty;
            m_LastLogIn = dtmDefault;
            m_LastChangedPassword = dtmDefault;
            m_DeadlineOfUsing = dtmDefault;
        }

        public virtual string LoginID
        {
            get { return m_LoginID; }
            set { m_LoginID = value; }
        }
        
        public virtual string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        public virtual string FullName
        {
            get { return m_FullName; }
            set { m_FullName = value; }
        }

        public virtual string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
       
        public virtual DateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }

        public virtual bool LockedUser
        {
            get { return m_LockedUser; }
            set { m_LockedUser = value; }
        }

        public virtual DateTime LockedDate
        {
            get { return m_LockedDate; }
            set { m_LockedDate = value; }
        }

        public virtual string LockedReason
        {
            get { return m_LockedReason; }
            set { m_LockedReason = value; }
        }

        public virtual DateTime LastLogIn
        {
            get { return m_LastLogIn; }
            set { m_LastLogIn = value; }
        }

        public virtual DateTime LastChangedPassword
        {
            get { return m_LastChangedPassword; }
            set { m_LastChangedPassword = value; }
        }

        public virtual DateTime DeadlineOfUsing
        {
            get { return m_DeadlineOfUsing; }
            set { m_DeadlineOfUsing = value; }
        }
    }

    public class UserCollection : List<User>
    { }
}
