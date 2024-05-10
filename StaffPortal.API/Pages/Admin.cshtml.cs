using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StaffPortal.API.Models;
using System.Text.Json;
using System.Text;

namespace StaffPortal.API.Pages
{
    public class AdminModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AdminModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        [BindProperty]
        public Staff NewStaff { get; set; }

        public List<Gender> Genders { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<Staff> StaffList { get; set; }

        public string SuccessMessage { get; set; }
        public List<string> ValidationErrors { get; set; } = new List<string>();

        public async Task OnGetAsync()
        {
            await LoadDataAsync();
        }

       // [ValidateAntiForgeryToken]
        public async Task OnPostAsync()
        {
            // Handle form submission
            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, reload data and return
                await LoadDataAsync();
                return;
            }

            var json = JsonSerializer.Serialize(NewStaff);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //  var apiUrl = $"{_configuration["ApiBaseUrl"]}/api/Staff";
            var response = await _httpClient.PostAsync($"{_configuration["ApiBaseUrl"]}/api/Staff", content);

            if (response.IsSuccessStatusCode)
            {
                SuccessMessage = "Staff added successfully.";
                await LoadDataAsync();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ValidationErrors.Add(error);
                await LoadDataAsync();
            }
        }



        public async Task OnPostDeleteAsync(string? employeeNumber)
        {
            var response = await _httpClient.DeleteAsync($"/api/Staff/{employeeNumber}");

            if (response.IsSuccessStatusCode)
            {
                SuccessMessage = "Staff deleted successfully.";
                await LoadDataAsync();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ValidationErrors.Add(error);
            }
        }

        private async Task LoadDataAsync()
        {
            //  var gendersResponse = await _httpClient.GetAsync("/api/Gender");


            Genders = await _httpClient.GetFromJsonAsync<List<Gender>>($"{_configuration["ApiBaseUrl"]}/api/Gender");
            // Genders = await JsonSerializer.DeserializeAsync<List<Gender>>(await gendersResponse.Content.ReadAsStreamAsync());
            Qualifications = await _httpClient.GetFromJsonAsync<List<Qualification>>($"{_configuration["ApiBaseUrl"]}/api/Qualification");
            StaffList = await _httpClient.GetFromJsonAsync<List<Staff>>($"{_configuration["ApiBaseUrl"]}/api/Staff");

        }
    }
}
