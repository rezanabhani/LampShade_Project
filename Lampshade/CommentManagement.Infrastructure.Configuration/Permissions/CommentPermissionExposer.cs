using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace CommentManagement.Infrastructure.Configuration.Permissions
{
    public class CommentPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDto>> Expose()
        {
            return new Dictionary<string, List<PermissionsDto>>
            {
                {
                    "CommentManagement", new List<PermissionsDto>
                    {
                        new PermissionsDto(CommentPermissions.ShowCommentManagement,"ShowCommentManagement"),
                        new PermissionsDto(CommentPermissions.ListComments,"ListComments"),
                        new PermissionsDto(CommentPermissions.SearchComments,"SearchComments"),
                        new PermissionsDto(CommentPermissions.CancelComment,"CancelComment"),
                        new PermissionsDto(CommentPermissions.ConfirmComment,"ConfirmComment"),
                    }
                },
            };
        }
    }
}
