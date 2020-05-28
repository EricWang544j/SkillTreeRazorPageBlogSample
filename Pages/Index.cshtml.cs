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

        [ViewData]
        public string handler { set; get; }   //記錄tag的字串，供tag後的分頁使用
        [ViewData]
        public string tagName { set; get; }   //記錄tag的字串，供tag後的分頁使用
        [ViewData]
        public string search_q { set; get; }  //記錄search的字串，供search後的分頁使用






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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">頁次</param>
        /// <param name="q">search的字串</param>
        public void OnGet(int? p , string q) {

            var pageIndex = p.HasValue ? p.Value < 1 ? 1 : p.Value : 1;
            var qu = _context.Articles.AsQueryable();
            if (string.IsNullOrWhiteSpace(q) == false) {

                search_q = q;

                qu = qu.Where(p => p.Body.Contains(q));

            }


            Article = qu.OrderBy(p => p.Title).Select(p => new MyClass
            {
                Id = p.Id,
                CoverPhoto = p.CoverPhoto,
                Title = p.Title,
                Body = p.Body.Substring(0, 200),
                CreateDate = p.CreateDate,
                Tags = p.Tags

            }).ToPagedList(pageIndex, 5);

        }


        public void OnGetTag(string tag, int? p)
        {
             handler = "tag" ;
             tagName = tag;


            var pageIndex = p.HasValue ? p.Value < 1 ? 1 : p.Value : 1;

            var qu = _context.Articles.AsQueryable();
            if (string.IsNullOrWhiteSpace(tag)==false) {
                qu = qu.Where(p => p.Tags.Contains(tag));
            }

            Article = qu.OrderBy(p => p.Title).Select(p => new MyClass
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
