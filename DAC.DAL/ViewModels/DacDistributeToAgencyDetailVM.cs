namespace DAC.DAL.ViewModels
{
    public class DacDistributeToAgencyDetailVM
    {
        public long Id { get; set; }
        public int? DistributeToAgencyId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
