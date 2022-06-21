using UnityEngine;

namespace Core.Figure
{
    public class RendererFigure : MonoBehaviour
    {
        [SerializeField] private Material _selectedMaterial;
        [SerializeField] private Material _unselectedMaterial;

        [SerializeField] private MeshRenderer _meshRenderer;

        public void Select()
        {
            _meshRenderer.material = _selectedMaterial;
        }
        public void Unselect()
        {
            _meshRenderer.material = _unselectedMaterial;
        }
    }
}