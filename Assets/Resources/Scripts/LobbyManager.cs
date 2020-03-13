using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.LunacyIncorporation.Kalandria
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {

        #region Public Fields


        [Tooltip("The prefab used to instance the player")]
        public GameObject playerPrefab;


        #endregion


        #region Private Serializable Fields


        [Tooltip("Maximum number of players")]
        private byte maxPlayers = 2;


        #endregion

        #region Private Fields

        private string gameVersion = "0.1";

        private bool isConnecting;


        #endregion

        #region MonoBehavior Callbacks


        private void Awake()
        {
            // *Critical*
            // this makes sure we can use PhotonNetwork.loadLevel() on the master client and all clients in that same room sync their level
            Debug.Log("Scenes are synced");
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// Start the connection process.
        /// - if already connected, attemp to join a random room
        /// - if not yet connected, connect this application instance to photon cloud network
        /// </summary>
        public void Connect()
        {
            Debug.Log("Connect fires");
            isConnecting = PhotonNetwork.ConnectUsingSettings();

            if (PhotonNetwork.IsConnected)
            {
                // *Critical*, Attempt joining a random room
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }


        #endregion


        #region MonoBehaviorPunCallbacks Callbacks


        public override void OnConnectedToMaster()
        {
            Debug.Log("Pun basics tut/launcher: OnConnectedToMaster() was called by PUN");
            // #Critical: We try to join a random room, if we can't we will be called back with OnJoinRandomFailed()
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            //progressLabel.SetActive(false);
            //controlPanel.SetActive(true);
            Debug.LogWarningFormat("PUN Basics Tut/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exist or are full.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayers });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

            //#Critical: we only load if we are the first player, else we rely on the auto sync
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("We load the room for one player");

                // #Critical
                // Load the Room Level --> This will be a lobby soon
                PhotonNetwork.LoadLevel("LobbyRoom");
            }
            else
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                {
                    Debug.Log("Load the full game room");
                    PhotonNetwork.LoadLevel("GameMapTest");
                }
            }
        }

        public void DevLoad()
        {
            Debug.Log("Load the test room");
            PhotonNetwork.LoadLevel("GameMapTest");
        }
        #endregion

    }
}

