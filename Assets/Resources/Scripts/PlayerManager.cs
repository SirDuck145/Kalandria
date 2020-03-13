using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.LunacyIncorporation.Kalandria
{
    public class PlayerManager : MonoBehaviourPun
    {

        #region Public Serializable Fields

        [Tooltip("The local reference to the camera controller")]
        public static GameObject localPlayerInstance;


        #endregion

        // Start is called before the first frame update
        void Start()
        {
        }



        #region Ipun Observable


        private void Awake()
        {
            if (localPlayerInstance == null)
            {
                if (photonView.IsMine)
                {
                    localPlayerInstance = gameObject;
                }
            }

            // #Critical
            // We flag as dont destory on load so that the instance survives level sync giving a seamless experience when levels load
            DontDestroyOnLoad(gameObject);

        }
        #endregion


    }
}
