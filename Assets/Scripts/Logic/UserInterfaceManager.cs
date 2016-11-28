using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class UserInterfaceManager : MonoBehaviour
    {
        public Image OutLineImage;
        public Text MessageText;

        public void ShowMessage( string text, float time=1.0f)
        {
            MessageText.text = text;
        }

        public void HideOutlineImage()
        {
            OutLineImage.color = new Color(0,0,0,0);
        }
        public void SetOutline(Sprite image , float alpha = 1.0f)
        {
            float imageHeighToWidth = image.rect.height/image.rect.width;
            OutLineImage.sprite = image;
            OutLineImage.color = new Color(1,1,1,alpha);
            OutLineImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, OutLineImage.rectTransform.rect.height /imageHeighToWidth);
            OutLineImage.rectTransform.anchoredPosition = new Vector2(0,0);

        }

    }
}