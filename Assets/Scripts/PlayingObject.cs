using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayingObject : GameElement
    {
        public bool selected;
        public Mesh mesh;
        public Material material;
        public Color color;
        public string Name;
    }
}
