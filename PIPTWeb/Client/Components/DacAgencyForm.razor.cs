using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Components
{
    public partial class DacAgencyForm
    {
        [Parameter] public DacAgency agency { get; set; }
        [Parameter] public bool IsAdmin { get; set; }
        [Parameter] public string UserName { get; set; }
        [Parameter] public string HeaderText { get; set; }
        [Parameter] public string ButtonText { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
        [Inject] ICustomersService customerService { get; set; }
        [Inject] IDacAgencyService agencyService { get; set; }
        [Inject] IProvincesService provinceService { get; set; }
        [Inject] IDacRegionsService regionService { get; set; }
        private List<Customers> LstCustomers = new List<Customers>();
        private List<Customers> LstSelectedCustomers = new List<Customers>();
        private List<DacAgency> LstAgencies = new List<DacAgency>();
        private List<DacAgency> LstSelectedAgencies = new List<DacAgency>();
        private List<Province> LstProvinces = new List<Province>();
        private List<Province> LstSelectedProvinces = new List<Province>();
        private List<DacRegion> LstRegions = new List<DacRegion>();
        private List<DacRegion> LstSelectedRegions = new List<DacRegion>();
        protected override async Task OnInitializedAsync()
        {
            LstCustomers = await customerService.GetCustomers(true);
            LstAgencies = await agencyService.GetAgencies(true);
            LstProvinces = await provinceService.GetProvinces(true);
            LstRegions = await regionService.GetRegions(true);
            if (agency != null)
            {
                if (agency.CustomerId.HasValue && agency.CustomerId > 0)
                {
                    var customer = await customerService.GetCustomerById(agency.CustomerId.Value);
                    if (customer != null)
                    {
                        LstSelectedCustomers.Add(customer);
                    }    
                }
                if (!string.IsNullOrWhiteSpace(agency.DependCode))
                {
                    var SelectedAgency = await agencyService.GetAgencyByCode(agency.DependCode);
                    if (SelectedAgency != null)
                    {
                        LstSelectedAgencies.Add(SelectedAgency);
                    }
                }
                if (!string.IsNullOrWhiteSpace(agency.ProvinceCode))
                {
                    var province = await provinceService.GetProvinceByCode(agency.ProvinceCode);
                    if (province != null)
                    {
                        LstSelectedProvinces.Add(province);
                    }
                }
                if (!string.IsNullOrWhiteSpace(agency.Region))
                {
                    var region = await regionService.GetRegionByCode(agency.Region);
                    if (region != null)
                    {
                        LstSelectedRegions.Add(region);
                    }
                }
            } 
                
            StateHasChanged();
        }
        private async Task<List<Customers>> filterCustomerFunction(List<Customers> allCustomer, string filter, CancellationToken token)
        {
            return await Task.FromResult(allCustomer.Where(i => i.Name.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<Customers> getCustomerByIdAsync(List<Customers> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.Id.ToString() == id));
        }
        private void OnCustomerChange()
        {
            if (agency != null && LstSelectedCustomers.Count > 0)
            {
                agency.CustomerId = LstSelectedCustomers[0].Id;
            }
        }
        private async Task<List<DacAgency>> filterAgencyFunction(List<DacAgency> allAgency, string filter, CancellationToken token)
        {
            return await Task.FromResult(allAgency.Where(i => i.Name.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<DacAgency> getAgencyByIdAsync(List<DacAgency> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.ID.ToString() == id));
        }
        private void OnAgencyChange()
        {
            if (agency != null && LstSelectedAgencies.Count > 0)
            {
                agency.DependCode = LstSelectedAgencies[0].Code;
            }
        }
        private async Task<List<Province>> filterProvinceFunction(List<Province> allProvince, string filter, CancellationToken token)
        {
            return await Task.FromResult(allProvince.Where(i => i.Name.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<Province> getProvinceByIdAsync(List<Province> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.ID.ToString() == id));
        }
        private void OnProvinceChange()
        {
            if (agency != null && LstSelectedProvinces.Count > 0)
            {
                agency.ProvinceCode = LstSelectedProvinces[0].Code;
            }
        }
        private async Task<List<DacRegion>> filterRegionFunction(List<DacRegion> allRegion, string filter, CancellationToken token)
        {
            return await Task.FromResult(allRegion.Where(i => i.RegionArea.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<DacRegion> getRegionByIdAsync(List<DacRegion> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.ID.ToString() == id));
        }
        private void OnRegionChange()
        {
            if (agency != null && LstSelectedRegions.Count > 0)
            {
                agency.Region = LstSelectedRegions[0].RegionCode;
            }
        }
    }
}
