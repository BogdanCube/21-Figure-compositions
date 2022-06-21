using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class DetectorLose : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Figure.Figure figure))
            {
                _text.text = "Game Over";
            }
        }
    }
}