using Characters;
using UnityEngine;

namespace Logic
{
    public class ArCharacterIcon:MonoBehaviour
    {
        public Sprite ActiveSprite;
        public ArCharacter Character;
        private SpriteRenderer _renderer;
        private bool _isActivated;

        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _isActivated = false;
        }

        private void Update()
        {
            if (Character.IsActive && !_isActivated)
            {
                _renderer.sprite = ActiveSprite;
                _renderer.color = Color.white;
                _isActivated = true;
            }
        }
    }
}