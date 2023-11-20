using Modules.Common;
using UnityEngine;

namespace Modules.Services.DataService
{
    public class ApplicationContext : IApplicationContext
    {
        private const string k_CanvasPath = "Canvas";
        private const string k_PlayerPath = "Player";


        public GameObject Canvas { get; private set; }
        public GameObject Player { get; private set; }


        public ApplicationContext()
        {
            GetAvailableTemplates();
        }

        private void GetAvailableTemplates()
        {
            Canvas = Resources.Load<GameObject>(k_CanvasPath);
            Player = Resources.Load<GameObject>(k_PlayerPath);
        }
    }
}