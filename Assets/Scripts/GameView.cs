using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameView: GameElement
    {
        public Canvas_A_View canvas_A;
        public Canvas_B_View canvas_B;
        public Camera mainCamera;

        void Start()
        {
            canvas_A.CreateObjectButtons(game.model.objects.Length);
            canvas_B.CreateColorButtons(game.model.colors.Length);

            var position = Vector3.zero;
            for (int i = 0; i < game.model.objects.Length; i++)
            {
                var go = new GameObject("playingObject_"+i);

                go.transform.position = position;
                go.transform.localScale = new Vector3(game.model.objectsScale, game.model.objectsScale, game.model.objectsScale);

                go.transform.SetParent(transform);
                go.AddComponent<MeshFilter>().mesh = game.model.objects[i].mesh;
                go.AddComponent<MeshRenderer>().material = game.model.objects[i].material;

                var colorIndex = PlayerPrefs.GetInt(game.model.objects[i].Name, -1);

                if (colorIndex < 0 || colorIndex >= game.model.colors.Length)
                    game.model.objects[i].material.color = game.model.objects[i].color;
                else
                {
                    game.model.objects[i].material.color = game.model.colors[colorIndex];
                }

                position +=new Vector3(game.model.distance_bw_objects,0,0);

                canvas_A.objectsButtons[i].GetComponentInChildren<Text>().text = game.model.objects[i].Name;
            }

            canvas_B.gameObject.SetActive(false);
            canvas_A.gameObject.SetActive(true);
        }
    }
}
