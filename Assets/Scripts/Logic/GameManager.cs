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
            CharactersController.SetCharacterDetected(CharacterDetected);
        }

        private void StartSearchForFoxMarker()
        {
            UserInterface.ShowMessage("Find fox Marker");
            UserInterface.SetOutline(FoxMarker.Image,0.5f);
            FoxMarker.MarkerDetectedAction = MarkerDetected;
        }

        public void CharacterDetected(ArCharacter character)
        {
            ArCharacter currentCharacter = CharactersController.GetCurrent();
            if (character == currentCharacter)
            {
                UserInterface.HideOutlineImage();
                currentCharacter.StartAnimation(() => { BackToMarker(); });
            }
            else
            {
              //What we do if we find wrong character 
            }
        }

        private void BackToMarker()
        {

            CharactersController.GetCurrent().DisableAnim();
            UserInterface.ShowMessage("Now go back to fox marker");
            UserInterface.SetOutline(FoxMarker.Image, 0.5f);
            CharactersController.MoveNext();
            FoxMarker.MarkerDetectedAction = MarkerDetected;
        }

        public void MarkerDetected()
        {
            FoxMarker.MarkerDetectedAction = null;
            UserInterface.ShowMessage("Great. You found Fox Marker");
            UserInterface.HideOutlineImage();
            Invoke("StartCharacterSearch", 2.0f);
        }

        private ArCharacter _currentArCharacter;
        private void StartCharacterSearch()
        {
            if (CharactersController.GetCurrent() != null)
            {
                _currentArCharacter = CharactersController.GetCurrent(); 
                UserInterface.ShowMessage(string.Format("Find {0}", _currentArCharacter.CharacterName));
                UserInterface.SetOutline(_currentArCharacter.OutlineSprite, 0.75f);
            }
        }

    }
}
