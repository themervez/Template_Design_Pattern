using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template_Design_Pattern_UpSchool.DAL.Entities;

namespace Template_Design_Pattern_UpSchool.TemplateDesignPattern
{
    public abstract class UserCardTemplate
    {
        protected AppUser AppUser { get; set; }
        public void SetUser(AppUser appUser)//Sayfa yüklendiğinde gelen kullanıcı TagHelper içerisinde karşılanacak
        {
            AppUser = appUser;
        }
        protected abstract string SetImage();//Image Setting
        protected abstract string SetInformations();//Image Setting
        protected abstract string SetFooter();//Footer Area Setting

        //Template Features
        public string Build()
        {
            var sb = new StringBuilder();
            sb.Append("<div class='card'>");
            sb.Append(SetImage());
            sb.Append($@"<div class='card-body'>
                         <h5>{AppUser.UserName}</h5>
                         <p>{AppUser.Description}</p>");//Tüm kullanıcıların göreceği alanlar, html formatında
            sb.Append(SetInformations());
            sb.Append(SetFooter());//Kulllanıcılara göre değişecek alanlar, metod olarak
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
