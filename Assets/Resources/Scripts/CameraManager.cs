using UnityEngine;
using Photon.Pun;


namespace Com.LunacyIncorporation.Kalandria
{
    public class CameraManager : MonoBehaviourPun
    {

        #region Public Fields

        [Tooltip("The percent margin you want to make the camera scroll at an edge")]
        [SerializeField]
        public float screenBounds;

        [Tooltip("The speed at which the camera pans")]
        [SerializeField]
        public int panSpeed;


        #endregion

        #region Private Fields

        private int screenWidth;
        private int screenHeight;
        private float screenBoundWidth;
        private float screenBoundHeight;

        #endregion


        #region Private Methods


        void Start()    
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            screenBoundWidth = screenWidth*(screenBounds / 100);
            screenBoundHeight = screenHeight*(screenBounds / 100);
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

            // Mouse is near the left side
            if (Input.mousePosition.x < screenBoundWidth)
            {
                Debug.Log("Mouse is near the left side of the screen");
                gameObject.transform.position = new Vector3(panSpeed*Time.deltaTime, 0, 0);
            }

            // Mouse is near the right side
            if (Input.mousePosition.x > screenWidth - screenBoundWidth)
            {
                Debug.Log("Mouse is near the right side of the screen");
            }
        }

        #endregion
    }

}
