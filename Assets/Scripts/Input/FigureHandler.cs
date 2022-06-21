using Core;
using Core.Figure;
using UI;
using UnityEngine;

namespace InputFigure
{
    public class FigureHandler : MonoBehaviour
    {
        [SerializeField] private ProgressHandler _progressHandler;
        [SerializeField] private Camera _camera;
        private Figure _currentFigure;

        private void Update()
        {
            if (Input.GetMouseButton(0) && _progressHandler.Bar.IsFilled == false)
            {
                SelectFigure();
            }
            else if (Input.GetMouseButtonUp(0) && _currentFigure)
            {
                UnselectFigure();
            }
        }

        private void SelectFigure()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
            {
                if (raycastHit.collider.gameObject.TryGetComponent(out Figure figure))
                {
                    _currentFigure = figure;
                    _currentFigure.Dragger.Drag(raycastHit.point);
                }
            }
        }

        private void UnselectFigure()
        {
            _currentFigure.Dragger.NoDrag();
            _currentFigure = null;
        }
    }
}