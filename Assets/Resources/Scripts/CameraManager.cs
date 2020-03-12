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

            // Checks the horizontal margins for panning
            if (Input.mousePosition.x < screenBoundWidth)
            {
                if (Input.mousePosition.y > screenHeight - screenBoundHeight)
                {
                    Debug.Log("Mouse is near the left and top");
                }
                else if (Input.mousePosition.y < screenBoundHeight)
                {
                    Debug.Log("Mouse is near the left and bottom");
                }
                else
                {
                    Debug.Log("Mouse is near the left");
                    gameObject.transform.position = new Vector3(panSpeed * Time.deltaTime, 0, 0);
                }

            }
            else if (Input.mousePosition.x > screenWidth - screenBoundWidth)
            {
                if (Input.mousePosition.y > screenHeight - screenBoundHeight)
                {
                    Debug.Log("Mouse is near the right and top");
                }
                else if (Input.mousePosition.y < screenBoundHeight)
                {
                    Debug.Log("Mouse is near the right and bottom");
                }
                else
                {
                    Debug.Log("Mouse is near the right");
                    gameObject.transform.position = new Vector3(panSpeed * Time.deltaTime, 0, 0);
                }
            }

            // Check the vertical margins
            if (Input.mousePosition.y > screenHeight - screenBoundHeight)
            {
                Debug.Log("Mouse is at the top");
            }
            else if (Input.mousePosition.y < screenBoundHeight)
            {
                Debug.Log("Mouse is at the bottom");
            }
        }

        #endregion
    }

}
