namespace DAC.DAL.ViewModels
{
    public class DacDistributeToStoreDetailsVM
    {
        public long Id { get; set; }
        public int? DistributeToStoreId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
