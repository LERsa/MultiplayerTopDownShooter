using UnityEngine;
using SocketIO;
using UnityEditor.MemoryProfiler;
using System.Collections.Generic;

namespace Project.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        [Header("Network Client")]
        [SerializeField] private Transform networkContainer;

        private Dictionary<string, GameObject> serverObjects;
            
        public override void Start()
        {
            base.Start();
            Initialize();
            SetupEvents();
        }

        public override void Update()
        {
            base.Update();
        }

        private void Initialize()
        {
            serverObjects = new Dictionary<string, GameObject>();
        }

        private void SetupEvents()
        {
            On("open", (E) =>
            {
                Debug.Log("Connection made to the server");
            });

            On("register", (E) =>
            {
                string id = E.data["id"].ToString().RemoveQuotes();

                Debug.Log($"Our Client's is {id}");
            });


            On("spawn", (E) =>
            {
                string id = E.data["id"].ToString().RemoveQuotes();

                GameObject go = new GameObject("Server ID:" + id);
                go.transform.SetParent(networkContainer);
                serverObjects.Add(id, go);
            });

           On("disconnected", (E) =>
            {
                string id = E.data["id"].ToString().RemoveQuotes();

                GameObject go = serverObjects[id];
                Destroy(go);
                serverObjects.Remove(id);
            });
        }
    }
}

