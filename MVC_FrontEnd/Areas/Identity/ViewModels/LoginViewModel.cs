using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_FrontEnd.Areas.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Error: email is not set!")]
        public string? Email { get; set; }
    }
}
