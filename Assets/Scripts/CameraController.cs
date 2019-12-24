using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : GameElement
    {
        private float speed;

        private Vector3 startPosition;
        private Vector3[] focusedOnObjectPosition;

        private Vector3 DesirePosition;

        private Camera mainCamera;
        void Start()
        {
            mainCamera = game.view.mainCamera;
            speed = game.model.cameraSpeed;

            CalcStartPos();
            CalcFocusedPositions();

            DesirePosition = startPosition;
            mainCamera.transform.position = startPosition;
        }
        void Update()
        {
            if (mainCamera.transform.position != DesirePosition)
            {
                mainCamera.transform.position =
                    Vector3.MoveTowards(mainCamera.transform.position, DesirePosition, Time.deltaTime * speed);
            }
        }

        public void FocusOnObject(int objectIndex)
        {
            DesirePosition = focusedOnObjectPosition[objectIndex];
        }

        public void NotFocused()
        {
            DesirePosition = startPosition;
        }

        void CalcStartPos()
        {
            var temp = game.model.distance_bw_objects * (game.model.objects.Length - 1)/2;

            startPosition = new Vector3(temp,0,-Mathf.Tan((90- getHorizontalAngle()/ 2)*Mathf.Deg2Rad)*(temp + game.model.objectsScale*1.5f));
        }

        private float getHorizontalAngle()
        {
            float vFOVrad = mainCamera.fieldOfView * Mathf.Deg2Rad;
            float cameraHeightAt1 = Mathf.Tan(vFOVrad * .5f);
            return Mathf.Atan(cameraHeightAt1 * mainCamera.aspect) * 2f * Mathf.Rad2Deg;
        }

        void CalcFocusedPositions()
        {
            focusedOnObjectPosition = new Vector3[game.model.objects.Length];

            for (int i = 0; i < focusedOnObjectPosition.Length; i++)
            {
                var temp = game.model.distance_bw_objects * i;
                focusedOnObjectPosition[i] = new Vector3(temp, 0, -Mathf.Tan((90 - getHorizontalAngle() / 2) * Mathf.Deg2Rad) * (game.model.distance_bw_objects / 2));
            }
        }
    }
}
