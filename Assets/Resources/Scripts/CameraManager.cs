using UnityEngine;
using Photon.Pun;


namespace Com.LunacyIncorporation.Kalandria
{
    public class CameraManager : MonoBehaviourPun
    {

        #region Public Fields

        [Tooltip("The distance the mouse must be from the edge of the screen to scroll")]
        [SerializeField]
        public int screenBounds;

        [Tooltip("The speed at which the camera pans")]
        [SerializeField]
        public int panSpeed;


        #endregion

        #region Private Fields

        private int screenWidth;
        private int screenHeight;

        #endregion


        void Start()    
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }

        private void Update()
        {
            ProcessInputs();
        }

        private void LateUpdate()
        {
            // Move the camera position the be the position of the local cameraManager
            Camera.main.transform.position = gameObject.transform.position;
        }

        /// <summary>
        /// Handles the inputs from the user, moving the camera around the screen accordingly
        /// </summary>
        void ProcessInputs()
        {
            // If it is not your camera, exit
            
            if (!photonView.IsMine)
            {
                return;
            }
            // Check if the mouse is within the bounds 
            Debug.Log("Processing the inputs");
            Debug.Log(Input.mousePosition.x);
            Debug.Log(screenWidth / 2 - 50);

            // Mouse is near the right side
            if (Input.mousePosition.x > screenWidth / 2 - screenBounds)
            {
                Debug.Log("Mouse is near the right side of the screen");
                gameObject.transform.position = new Vector3(panSpeed*Time.deltaTime, 0, 0);
            }
        }
    }

}
