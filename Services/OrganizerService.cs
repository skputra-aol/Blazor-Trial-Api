using BlazorApp.Models;
using BlazorApp.Helpers.Pagination;
using BlazorApp.Models.Organizers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IOrganizerService
    {
        User User { get; }
        Task Initialize();
        Task Register(AddOrganizer model);
        Task<PagingResponse<Organizer>> GetAll(int page, int perPage);
        Task<Organizer> GetById(string id);
        Task Update(string id, EditOrganizer model);
        Task Delete(string id);
    }

    public class OrganizerService : IOrganizerService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private string _organizerKey = "organizer";

        public Organizer organizer { get; private set; }
        public User User { get; private set; }

        public OrganizerService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(_userKey);
        }


        public async Task Register(AddOrganizer model)
        {
            await _httpService.Post("/api/v1/organizers", model);
        }

        public async Task<PagingResponse<Organizer>> GetAll(int page, int perPage)
        {
            return await _httpService.Get<PagingResponse<Organizer>>($"/api/v1/organizers?page={page}&perPage={perPage}");
        }

        public async Task<Organizer> GetById(string id)
        {
            return await _httpService.Get<Organizer>($"/api/v1/organizers/{id}");
        }

        public async Task Update(string id, EditOrganizer model)
        {
            await _httpService.Put($"/api/v1/organizers/{id}", model);

        }

        public async Task Delete(string id)
        {
            
            await _httpService.Delete($"/api/v1/organizers/{id}");

        }
    }
}