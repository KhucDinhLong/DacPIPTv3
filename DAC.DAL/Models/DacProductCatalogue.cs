using System;

namespace DAC.DAL
{
    public class DacProductCatalogue
    {

        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string LargeGroupCode { get; set; }
        public virtual string Remark { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public DacProductCatalogue()
        {
            Id = -1;
            Code = string.Empty;
            Name = string.Empty;
            LargeGroupCode = string.Empty;
            Remark = string.Empty;
            CreatedUser = string.Empty;
            CreatedDate = DateTime.Now;
            ModifiedUser = string.Empty;
            ModifiedDate = DateTime.Now;
        }
    }
    //public class DacProductCatalogueCollection : List<DacProductCatalogue>
    //{ }
}
