using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ColorButton : Button
    {
        public Image SelectedImage;

        protected override void Start()
        {
            base.Start();
            SelectedImage = GetComponent<Image>();
        }
    }
}
