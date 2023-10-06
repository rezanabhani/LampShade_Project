using System.Collections.Generic;

namespace _0_Framework.Infrastructure
{
    public interface IPermissionsExposer
    {
        Dictionary<string, List<PermissionsDto>> Expose();
    }
}
