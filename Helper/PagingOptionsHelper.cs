﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList.Mvc.Core.Common;
using X.PagedList.Web.Common;

namespace SkillTreeRazorPageBlogSample.Helper
{
    public static class PagingOptionsHelper
    {
        public static PagedListRenderOptions FrontEnd =>
          new PagedListRenderOptions {

              UlElementClasses = new List<string> { "pagination", "justify-content-center", "mb-4" },
              LiElementClasses = new List<string>{ "page-item" },
              PageClasses = new List<string>{ "page-link" },
              LinkToPreviousPageFormat = "←Older",
              LinkToNextPageFormat = "Newer→",
              DisplayLinkToFirstPage = PagedListDisplayMode.Never,
              DisplayLinkToLastPage = PagedListDisplayMode.Never,
              DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
              DisplayLinkToNextPage = PagedListDisplayMode.Always,
              DisplayLinkToIndividualPages = false



          };

    }
}
