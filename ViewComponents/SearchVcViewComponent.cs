using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTreeRazorPageBlogSample.ViewComponents
{
    public class SearchVcViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            //ViewData.Model = tags.Split(',');

            return View();  //也可以自已指定 View("Index");
        }


    }
}
