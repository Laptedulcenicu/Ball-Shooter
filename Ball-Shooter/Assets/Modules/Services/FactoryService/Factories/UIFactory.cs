using Modules.Common;

namespace Modules.Services.FactoryService
{
    public class UIFactory : IUIFactory
    {
        private IAssetProviderService _assetProviderService;

        public UIFactory(IAssetProviderService assetProviderService)
        {
            _assetProviderService = assetProviderService;
        }
    }
}