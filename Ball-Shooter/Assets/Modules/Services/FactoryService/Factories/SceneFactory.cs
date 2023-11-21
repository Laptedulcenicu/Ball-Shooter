using Modules.Common;

namespace Modules.Services.FactoryService
{
    public class SceneFactory : ISceneFactory
    {
        private IAssetProviderService _assetProviderService;

        public SceneFactory(IAssetProviderService assetProviderService)
        {
            _assetProviderService = assetProviderService;
        }
    }
}