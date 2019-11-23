using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace WickedStudios
{
    public class Boundaries : MonoBehaviour
    {
        public Camera MainCamera;
        private Vector2 screenBounds;

        void Update()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}

