using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Canvas_B_View : GameElement
    {
        [HideInInspector]
        public ColorButton[] colorButtons;
        public Button backButton;

        public void CreateColorButtons(int count)
        {
            colorButtons = new ColorButton[count];

            var position = new Vector2(Screen.width/2 - 100 *(count-1), 30);
            for (int i = 0; i < colorButtons.Length; i++)
            {
                var buttonGO = Instantiate(game.model.colorButtonPrefab, transform);
                colorButtons[i] = buttonGO.GetComponent<ColorButton>();
                colorButtons[i].targetGraphic.color = game.model.colors[i];

                buttonGO.GetComponent<RectTransform>().position = position;

                position.x += 200;
            }
        }
    }
}
