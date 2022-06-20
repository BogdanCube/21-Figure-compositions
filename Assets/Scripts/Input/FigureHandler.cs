using UnityEngine;

namespace InputFigure
{
    public class FigureHandler : MonoBehaviour
    {
        public class DragPin : MonoBehaviour
        {
            [SerializeField] private Camera _camera;
            private Figure _currentFigure;

            private void Update()
            {
                if (Input.GetMouseButton(0))
                {
                    SelectPin();
                }
                else if (Input.GetMouseButtonUp(0) && _currentFigure)
                {
                    UnSelectPin();
                }
            }

            private void SelectPin()
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
                {
                    if (raycastHit.collider.gameObject.TryGetComponent(out Figure pin))
                    {
                        _currentFigure = pin;
                        Vector3 moveVector = new Vector3(raycastHit.point.x, 0.5f, raycastHit.point.z);
                        _currentFigure.Drag(moveVector);
                    }
                }
            }

            private void UnSelectPin()
            {
                _currentFigure.NoDrag();
                _currentFigure = null;
            }
        }
    }
}