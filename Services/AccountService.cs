using BlazorApp.Models;
using BlazorApp.Models.Account;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Helpers;
using System;
using System.Net;

namespace BlazorApp.Services
{
    public interface IAccountService
    {
        User User { get; }
        string info { get; set; }
        Task Initialize();
        Task Login(Login model);
        Task Logout(string? resInfo);
        Task Register(AddUser model);
        Task<IList<User>> GetAll();
        Task<User> GetById(string id);
        Task Update(string id, EditUser model);
        Task<Message> ChangePassword(string id, ChangePassword model);
        Task Delete(string id);
    }

    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        private string _info= "info";

        public User User { get; private set; }
        public string info { get;  set; }
        private string status { get; set; }

        public AccountService(
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
            info = await _localStorageService.GetItem<string>(_info);
        }

        public async Task Login(Login model)
        {
            try
            {
                User= null;
                User = await _httpService.Post<User>("/api/v1/users/login", model);
                await _localStorageService.SetItem(_info, "");
                await _localStorageService.SetItem(_userKey, User);
                
                
                if(User!=null)
                {
                    await _localStorageService.RemoveItem(_info);
                    var code = await AesCode.Encrypt(model.password);
                    User.code = code;
                    _navigationManager.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {
                _navigationManager.NavigateTo("account/logout/unauthorized");
            }
        }

        public async Task Logout(string? resInfo="")
        {
            User = null;
            info= resInfo;
            await _localStorageService.RemoveItem(_userKey);
            await _localStorageService.SetItem(_info, resInfo);
            _navigationManager.NavigateTo("account/login");
        }

        public async Task Register(AddUser model)
        {
            await _httpService.Post("/api/v1/users", model);
        }

        public async Task<IList<User>> GetAll()
        {
            var data=await _httpService.Get<User>($"/api/v1/users/{User.id}");
            List<User> list= new List<User>();
            list.Add(data);
            return list;
        }

        public async Task<User> GetById(string id)
        {
            return await _httpService.Get<User>($"/api/v1/users/{id}");
        }

        public async Task Update(string id, EditUser model)
        {
            await _httpService.Put($"/api/v1/users/{id}", model);
            
            // update stored user if the logged in user updated their own record
            if (id == User.id.ToString()) 
            {
                // update local storage
                User.firstName = model.firstName;
                User.lastName = model.lastName;
                User.email = model.email;
                await _localStorageService.SetItem(_userKey, User);
            }
        }

        public async Task<Message> ChangePassword(string id, ChangePassword model)
        {

            Message msg = new Message();
            string code="";
            try
            {
                if (id == "0") id = User.id.ToString();
                code = await AesCode.Decrypt(User.code);
                msg.Content = "";
                if (code == model.oldPassword)
                {
                    await _httpService.Put($"/api/v1/users/{id}/password", model);
                }
                else
                {
                    msg.Content = "Wrong Old Password !";
                }
            }
            catch(System.Exception ex){
                msg.Content=ex.Message;
                
            }
            return msg;
        }

        public async Task Delete(string id)
        {
            
            await _httpService.Delete($"/api/v1/users/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == User.id.ToString())
                await Logout();
        }
    }
}