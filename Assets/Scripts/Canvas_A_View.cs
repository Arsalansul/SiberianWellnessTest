using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Canvas_A_View : GameElement
    {
        [HideInInspector]
        public Button[] objectsButtons;

        public void CreateObjectButtons(int count)
        {
            objectsButtons = new Button[count];
            var position = new Vector2(0, Screen.height);
            for (int i = 0; i < objectsButtons.Length; i++)
            {
                var buttonGO = Instantiate(game.model.buttonForSelectObjectPrefab, transform);
                objectsButtons[i] = buttonGO.GetComponent<Button>();

                buttonGO.GetComponent<RectTransform>().position = position;

                position.y -= 50;
            }
        }
    }
}
