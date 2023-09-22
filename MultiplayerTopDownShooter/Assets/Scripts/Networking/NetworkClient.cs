using UnityEngine;
using SocketIO;
using UnityEditor.MemoryProfiler;

namespace Project.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        public override void Start()
        {
            base.Start();
            SetupEvents();
        }

        public override void Update()
        {
            base.Update();
        }

        private void SetupEvents()
        {
            On("open", (E) =>
            {
                Debug.Log("Connection made to the server");
            });
        }
    }
}

