using UnityEngine;

namespace Core.Figure
{
    public class DraggerFigure : MonoBehaviour
    {
        [SerializeField] private Figure _figure;
        
        private float _offsetY = 1;
        private float _offsetZ = 0;
        private float _startedOffsetZ;

        private bool _isDraged = false;
        private void Start()
        {
            _startedOffsetZ = transform.position.z;
            
            _figure.Renderer.Unselect();
        }
            
        public void Drag(Vector3 directionVector)
        {
            if (_isDraged)
            {
                return;
            }
            
            directionVector.z = transform.position.y > _offsetY ? _offsetZ : _startedOffsetZ;
            transform.position = Vector3.Lerp(transform.position, directionVector, 1f);
            
            _figure.Renderer.Select();   
            _figure.Physics.Enable();

        }
            
        public void NoDrag()
        {
            _figure.Renderer.Unselect();        
            _figure.Physics.Disable();

            _isDraged = true;
        }
    }
}