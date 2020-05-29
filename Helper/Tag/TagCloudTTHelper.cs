using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SkillTreeRazorPageBlogSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTreeRazorPageBlogSample.Helper.Tag
{
    public class TagCloudTTHelper : TagHelper
    {



        private readonly RazorPageBlogContext _context;
        private readonly IUrlHelperFactory UrlHelperFactory;
        private readonly IActionContextAccessor Accessor;




        public TagCloudTTHelper(
            RazorPageBlogContext context,
            IUrlHelperFactory urlHelperFactory, 
            IActionContextAccessor accessor)
        {
            _context = context;
            UrlHelperFactory = urlHelperFactory;
            Accessor = accessor;
        }

       

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var actionContext = Accessor.ActionContext;
            var urlHelper = UrlHelperFactory.GetUrlHelper(actionContext);


            var data = _context.TagCloud.ToDictionary(d => d.Name, d => d.Amount);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='card my-4'>");
            sb.AppendLine("<h5 class='card-header'>Tag Cloud</h5>");
            sb.AppendLine("<div class='card-body'>");
            sb.AppendLine("<ul class='list-unstyled mb-0'>");

            foreach(var item in data)
            {

                string url = urlHelper.Page("index", "tag", new { tag = item.Key });

                //var allDatakk = new Dictionary<string, string> { { "tag", item.Key }, { "p", "1" } };
                sb.AppendLine("<li class='d-inline'>");
                sb.AppendLine($"<a href='{url}'>{item.Key}({item.Value})</a>");
                sb.AppendLine("</li >");
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");


            output.Content.SetHtmlContent(sb.ToString() );
        }

    }
}
