using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTreeRazorPageBlogSample.Helper.Tag
{
    public class SearchTagHelper : TagHelper
    {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            StringBuilder st = new StringBuilder();

            st.AppendLine("<h5 class='card-header'>Search</h5>");
            st.AppendLine("<div class='card-body'>");
            st.AppendLine("<form asp-page='index' method='get'>");
            st.AppendLine("<div class='input-group'>");
            st.AppendLine("<input type='hidden' name='p' value='1'>");
            st.AppendLine("<input type='text' name='q' class='form-control' placeholder='Search for...'>");
            st.AppendLine("<span class='input-group-btn'>");
            st.AppendLine("<button class='btn btn-secondary' type='submit'>Go!</button>");
            st.AppendLine("</span>");
            st.AppendLine("</div>");
            st.AppendLine("</form>");
            st.AppendLine("</div>");


            output.Content.SetHtmlContent(st.ToString());

        }



    }
}
