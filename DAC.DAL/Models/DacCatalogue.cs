using System;
using System.Collections.Generic;

namespace DAC.DAL
{
    public class DacCatalogue
    {
        private int _Id;
        private string _Code;
        private string _Name;
        private string _LargeGroupCode;
        private string _Remark;

        public DacCatalogue()
        {
            _Id = -1;
            _Code = string.Empty;
            _Name = string.Empty;
            _LargeGroupCode = string.Empty;
            _Remark = string.Empty;
        }

        public virtual int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public virtual string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public virtual string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public virtual string LargeGroupCode
        {
            get { return _LargeGroupCode; }
            set { _LargeGroupCode = value; }
        }
        public virtual string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
    }
    //public class DacCatalogueCollection : List<DacCatalogue>
    //{ }
}
