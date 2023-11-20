using Modules.Common;
using Modules.Services.Common;

namespace Modules.Services.DataService
{
    public interface IDataService
    {
        IApplicationContext ApplicationContext { get; }
        IPersistent Persistant { get; }
        IApplicationCache ApplicationCache { get; }
        IProgressData ProgressData { get; }
    }
}