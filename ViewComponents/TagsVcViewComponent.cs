using Microsoft.AspNetCore.Mvc;
using SkillTreeRazorPageBlogSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTreeRazorPageBlogSample.ViewComponents
{
    public class TagsVcViewComponent : ViewComponent
    {
        private readonly RazorPageBlogContext _context;

        public TagsVcViewComponent(RazorPageBlogContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string tags)
        {
            ViewData.Model = tags.Split(',');

            return View();  //也可以自已指定 View("Index");
        }



    }
}
