using ARGDriver.Client.Interfaces;
using ARGDriver.Client.Services;
using ARGDriver.Shared.Models.Settings;
using Microsoft.AspNetCore.Components;
using System;

namespace ARGDriver.Client.Pages.Components.Settings
{
    public partial class UserEditComponent
    {
        [Parameter] public int Id { get; set; }

        private User user = new User();

        private List<Rol> ListadoRoles = new List<Rol>();
        [Inject] IUserServices UserServices { get; set; }
        [Inject] IRolServices RolServices { get; set; }
        [Inject] NavigationManager nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ListadoRoles = await RolServices.GetAllRoles();
            user = await UserServices.GetUserById(Id);
            StateHasChanged();
            //user = new User() 
            //{ Id = u1.Id, 
            //  Name = u1.Name,
            //  Surname = u1.Surname,
            //  DocumentType = u1.DocumentType,
            //  Document = u1.Document,
            //  Address = u1.Address,
            //  RolId = u1.RolId,
            //  Rol = u1.Rol,
            //  Status = u1.Status
            //};
        }

        private async Task UpdateUser()
        {
            var u2 = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                DocumentType = user.DocumentType,
                Document = user.Document,
                Address = user.Address,
                RolId = user.RolId,
                Rol = user.Rol,
                Status = user.Status
            };
            await UserServices.UpdateUser(Id, u2);
            nav.NavigateTo("ListadoUsuarios");
            StateHasChanged();
        }
    }
}
