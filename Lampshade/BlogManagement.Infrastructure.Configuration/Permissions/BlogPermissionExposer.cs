using _0_Framework.Infrastructure;
using System.Collections.Generic;

namespace BlogManagement.Infrastructure.Configuration.Permissions
{
    public class BlogPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "ShowBlogManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(BlogPermissions.ShowBlogManagement, "ShowBlogManagement"),
                    }
                },
                {
                    "ArticleManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(BlogPermissions.ShowArticleManagement, "ShowArticleManagement"),
                        new PermissionsDto(BlogPermissions.ListArticles, "ListArticles"),
                        new PermissionsDto(BlogPermissions.SearchArticles, "SearchArticles"),
                        new PermissionsDto(BlogPermissions.CreateArticle, "CreateArticle"),
                        new PermissionsDto(BlogPermissions.EditArticle, "EditArticle"),
                    }
                },
                {
                    "ArticleCategoryManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(BlogPermissions.ShowArticleCategoryManagement, "ShowArticleCategoryManagement"),
                        new PermissionsDto(BlogPermissions.ListArticleCategories, "ListArticleCategories"),
                        new PermissionsDto(BlogPermissions.SearchArticleCategories, "SearchArticleCategories"),
                        new PermissionsDto(BlogPermissions.CreateArticleCategory, "CreateArticleCategory"),
                        new PermissionsDto(BlogPermissions.EditArticleCategory, "EditArticleCategory"),
                    }
                },
            };
        }
    }
}
