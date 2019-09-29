using Android.Content;
using PageDesign.Contracts;

namespace PageDesign.Droid.Implementations
{
    public class AndroidAppVersionService : IAppVersionService
    {
        public Android.Content.Context Context { get; set; }

        public string GetAppVersion()
        {
            return Context.PackageManager.GetPackageInfo(Context.PackageName, 0).VersionName;
        }
    }
}
