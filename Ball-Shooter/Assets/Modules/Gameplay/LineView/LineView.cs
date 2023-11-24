using UnityEngine;

namespace Modules.Gameplay
{
    public class LineView: MonoBehaviour
    {
        [SerializeField] private SizeSetter sizeSetter;

        public SizeSetter SizeSetter => sizeSetter;
    }
}