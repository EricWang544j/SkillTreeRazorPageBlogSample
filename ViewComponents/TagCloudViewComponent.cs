using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using SkillTreeRazorPageBlogSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTreeRazorPageBlogSample.ViewComponents
{
    public class TagCloudViewComponent : ViewComponent
    {
        private readonly RazorPageBlogContext _context;
       


        public TagCloudViewComponent(RazorPageBlogContext context)
        {
            _context = context;
           
        }


        public IViewComponentResult Invoke()
        {
            ViewData.Model = _context.TagCloud.ToDictionary(d => d.Name, d => d.Amount);
            return View();
        }
    }


}
