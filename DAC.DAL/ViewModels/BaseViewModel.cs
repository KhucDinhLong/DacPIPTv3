using System;

namespace DAC.DAL.ViewModels
{
    public class BaseViewModel<T>
    {
        public Exception ex { get; set; }
        public T ResponseData { get; set; }
        public string ErrorMessage { get; set; }
    }
}
