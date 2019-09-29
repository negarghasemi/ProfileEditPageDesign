using Windows.ApplicationModel;
using PageDesign.Contracts;

namespace PageDesign.UWP.Implementations
{
    public class UWPAppVersionService : IAppVersionService
    {
        public string GetAppVersion()
        {
            return $"{Package.Current.Id.Version.Major}.{Package.Current.Id.Version.Minor}";
        }
    }
}
