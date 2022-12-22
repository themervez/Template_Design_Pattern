using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Design_Pattern_UpSchool.DAL.Entities;

namespace Template_Design_Pattern_UpSchool.TemplateDesignPattern
{
    public class UserCardTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;//Aracılığıyla giriş yapan kullanıcının bilgilerine ulaşıyoruz
        private readonly UserManager<AppUser> _userManager;
        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public AppUser AppUser { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated && user.EmailConfirmed) //Logged-In and E-mail Confirmed User
            {
                userCardTemplate = new PremiumUserCardTemplate();
            }

            else if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new GoldUserCardTemplate(); //Logged-In User
            }

            else
            {
                userCardTemplate = new DefaultUserCardTemplate(); //Default User
            }

            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());//userCardTemplate içerisinde oluşturulan bütün metodlar dahil edildi
        }
    }
}
