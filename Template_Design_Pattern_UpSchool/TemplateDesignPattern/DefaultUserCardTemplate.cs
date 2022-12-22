using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_Design_Pattern_UpSchool.TemplateDesignPattern
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()//implemented inherited abstract class
        {
            return string.Empty;//DefaultUser will not see any footer object
        }

        protected override string SetImage()
        {
            return "<img class='card-img-top' src='/images/User1.png' style='width:50px;height:50px;'>";
        }

        protected override string SetInformations()
        {
            return string.Empty;
        }
    }
}
