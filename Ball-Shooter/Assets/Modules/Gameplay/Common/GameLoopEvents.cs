using System;

namespace Modules.Gameplay
{
    public class GameLoopEvents
    {
        public Action OnDestroyAllEnemies;
        public Action OnFail;
        public Action OnWin;
    }
}