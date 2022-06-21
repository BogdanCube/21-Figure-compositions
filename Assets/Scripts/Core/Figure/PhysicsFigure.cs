using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Figure
{
    public class PhysicsFigure : MonoBehaviour
    {
        [SerializeField] private ProgressHandler _progressHandler;
        [SerializeField] private ParticleSystem _particle;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        private bool _isColission = false;
        
       
        public void Enable()
        {
            _collider.isTrigger = true;
        }
        public void Disable()
        {
            _collider.isTrigger = false;
            _rigidbody.useGravity = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Separators separators) 
                || collision.gameObject.TryGetComponent(out Figure figure) && _isColission == false)
            {
                _progressHandler.StartBar(_particle);
                _isColission = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Separators separators) 
                || collision.gameObject.TryGetComponent(out Figure figure))
            {
                _progressHandler.StopBar();
            }
        }
    }
}