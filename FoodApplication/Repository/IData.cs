using FoodApplication.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace FoodApplication.Repository
{
    public interface IData
    {
        Task<ApplicationUser> GetUser(ClaimsPrincipal claims);
          
         

       
    }
}
