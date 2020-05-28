using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SkillTreeRazorPageBlogSample.Data;
using X.PagedList;
using X.PagedList.Mvc.Core.Common;

namespace SkillTreeRazorPageBlogSample.Pages
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RazorPageBlogContext _context;



       

        public IndexModel(ILogger<IndexModel> logger, RazorPageBlogContext context)
        {
            _logger = logger;
            _context = context;

        }




        public class MyClass
        {
            public Guid Id { get; set; }
            public string CoverPhoto { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Tags { get; set; }
            public DateTime CreateDate { get; set; }
        }


        public IEnumerable<MyClass> Article { set; get; }




        //public void OnGet()
        //{

        //    //Articles = _context.Articles.ToList();
        //    Article = _context
        //              .Articles.OrderBy(p=>p.Title)
        //              .Select(d => new MyClass
        //              {
        //                  Id = d.Id,
        //                  CoverPhoto = d.CoverPhoto,
        //                  Title = d.Title,
        //                  Body = d.Body.Substring(0, 200),
        //                  CreateDate = d.CreateDate,
        //                  Tags = d.Tags
        //              })
        //              .ToList();
        //    //Debug.WriteLine( Articles[0].Title );
        //}



        public void OnGet(int? p) {

            var pageIndex = p.HasValue ? p.Value < 1 ? 1 : p.Value : 1;

            Article = _context.Articles.OrderBy(p => p.Title).Select(p => new MyClass
            {
                Id = p.Id,
                CoverPhoto = p.CoverPhoto,
                Title = p.Title,
                Body = p.Body.Substring(0, 200),
                CreateDate = p.CreateDate,
                Tags = p.Tags

            }).ToPagedList(pageIndex, 5);

            
        }

















    }
}
