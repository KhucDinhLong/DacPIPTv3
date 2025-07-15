namespace DAC.DAL.ViewModels
{
    public class DacExportDetailVM
    {
        public long Id { get; set; }
        public int? ExportId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
