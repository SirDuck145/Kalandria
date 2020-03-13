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
        private Vector3 direction;

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

            // Reset the direction vector
            direction = new Vector3(0, 0, 0);

            if (Input.mousePosition.x < screenBoundWidth)
            {
                direction += new Vector3(-1, 0, 0);
            }
            if (Input.mousePosition.x > screenWidth - screenBoundWidth)
            {
                direction += new Vector3(1, 0, 0);
            }
            // Check the vertical margins
            if (Input.mousePosition.y > screenHeight - screenBoundHeight)
            {
                Debug.Log("Mouse is at the top");
                direction += new Vector3(0, 0, 1);
            }
            if (Input.mousePosition.y < screenBoundHeight)
            {
                Debug.Log("Mouse is at the bottom");
                direction += new Vector3(0, 0, -1);
            }

            // Normalize the direction vector
            cameraPanner.transform.Translate(direction * Time.deltaTime * panSpeed);
        }

        #endregion
    }

}
