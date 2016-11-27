using Characters;
using UnityEngine;

namespace Logic
{
    public class GameManager : MonoBehaviour
    {

        public UserInterfaceManager UserInterface;
        public ArCharactersController CharactersController;
        public FoxMarkerController FoxMarker;

        // Use this for initialization
        public void Start ()
        {
            StartSearchForFoxMarker();
        }

        private void StartSearchForFoxMarker()
        {
            UserInterface.ShowMessage("Find fox Marker");
            UserInterface.SetOutline(FoxMarker.Image,0.5f);
            FoxMarker.MarkerDetectedAction = MarkerDetected;
        }

        public void MarkerDetected()
        {

            FoxMarker.MarkerDetectedAction = null;
            UserInterface.ShowMessage("Great");
            UserInterface.HideOutlineImage();
        }

        // Update is called once per frame
        public void Update () {
	
        }
    }
}
