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
        private GameObject cameraPanner;

        #endregion


        #region Private Methods


        void Start()    
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            screenBoundWidth = screenWidth*(screenBounds / 100);
            screenBoundHeight = screenHeight*(screenBounds / 100);
            cameraPanner = transform.root.gameObject;
        }

        private void Update()
        {
            ProcessInputs();
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

            // For other creatures, create their own vector so as to be able to apply percentage slows
            if (Input.mousePosition.x < screenBoundWidth)
            {
                cameraPanner.transform.position += new Vector3(-panSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.mousePosition.x > screenWidth - screenBoundWidth)
            {
                cameraPanner.transform.position += new Vector3(panSpeed * Time.deltaTime, 0, 0);
            }
            // Check the vertical margins
            if (Input.mousePosition.y > screenHeight - screenBoundHeight)
            {
                Debug.Log("Mouse is at the top");
                cameraPanner.transform.position += new Vector3(0, 0, panSpeed * Time.deltaTime);
            }
            else if (Input.mousePosition.y < screenBoundHeight)
            {
                Debug.Log("Mouse is at the bottom");
                cameraPanner.transform.position += new Vector3(0, 0, -panSpeed * Time.deltaTime);
            }
        }

        #endregion
    }

}
