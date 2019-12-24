using UnityEngine;

namespace Assets.Scripts
{
    public class GameElement : MonoBehaviour
    {
        // Gives access to the application and all instances.
        public Game game => GameObject.FindObjectOfType<Game>();
    }
}
