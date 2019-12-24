using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameController : GameElement
    {
        public CameraController cameraController;

        private PlayingObject selectedObject;

        void Start()
        {
            for (int i = 0; i < game.view.canvas_B.colorButtons.Length; i++)
            {
                var button = game.view.canvas_B.colorButtons[i];
                var j = i;

                button.onClick.AddListener(() => ChangeColor(button.targetGraphic.color));
                button.onClick.AddListener(() => SetButtonSelectedColor(j));
                button.onClick.AddListener(delegate{PlayerPrefs.SetInt(selectedObject.Name, j); });
            }

            game.view.canvas_B.backButton.onClick.AddListener(Back);

            for (int i = 0; i < game.view.canvas_A.objectsButtons.Length; i++)
            {
                var j = i;
                game.view.canvas_A.objectsButtons[i].onClick.AddListener(() => FocusToObject(j));
            }
        }

        void ChangeColor(Color color)
        {
            selectedObject.material.color = color;
        }

        void SetButtonSelectedColor(int buttonIndex)
        {
            for (int i = 0; i < game.view.canvas_B.colorButtons.Length; i++)
            {
                if (i == buttonIndex)
                {
                    game.view.canvas_B.colorButtons[i].SelectedImage.enabled = true;
                    continue;
                }

                game.view.canvas_B.colorButtons[i].SelectedImage.enabled = false;
            }
        }

        void Back()
        {
            game.view.canvas_B.gameObject.SetActive(false);
            game.view.canvas_A.gameObject.SetActive(true);
            cameraController.NotFocused();
        }

        void FocusToObject(int selectedObjectIndex)
        {
            game.view.canvas_B.gameObject.SetActive(true);
            game.view.canvas_A.gameObject.SetActive(false);

            selectedObject = game.model.objects[selectedObjectIndex];

            foreach (var playingObject in game.model.objects)
            {
                if (playingObject == selectedObject)
                {
                    playingObject.selected = true;
                    continue;
                }

                playingObject.selected = false;
            }
            
            SetButtonSelectedColor(PlayerPrefs.GetInt(selectedObject.Name, -1));
            cameraController.FocusOnObject(selectedObjectIndex);
        }
    }
}
