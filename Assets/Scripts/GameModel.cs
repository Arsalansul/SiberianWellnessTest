using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameModel :GameElement
    {
        public PlayingObject[] objects;
        public float objectsScale;

        public float cameraSpeed;
        public float distance_bw_objects;

        public GameObject buttonForSelectObjectPrefab;

        public Color[] colors;
        public GameObject colorButtonPrefab;
    }
}
