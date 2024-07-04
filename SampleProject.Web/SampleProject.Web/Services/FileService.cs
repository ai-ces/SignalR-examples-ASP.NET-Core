using Microsoft.AspNetCore.Identity;
using SampleProject.Web.Models;
using System.Threading.Channels;
using SampleProject.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace SampleProject.Web.Services
{
    public class FileService(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager, Channel<(string userId, List<Product> products)> channel)
    {



        public async Task<bool> AddMessageToQueue()
        {

            var userId = userManager.GetUserId(httpContextAccessor!.HttpContext!.User);


            var products = await context.Products.Where(x => x.UserId == userId).ToListAsync();


            return channel.Writer.TryWrite((userId, products));


        }


    }
}