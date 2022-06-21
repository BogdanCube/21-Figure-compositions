using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _slider;
        [SerializeField] private float _duration;
        
        private bool _isFilled;
        public bool IsFilled => _isFilled;
        public Tween FilledBar()
        {
            _isFilled = true;
            _slider.fillAmount = 0;
            _slider.DOFade(255,0);
            _background.DOFade(255,0);
            
            return _slider.DOFillAmount(1, _duration).OnComplete(() =>
            {
                _isFilled = false;
                _slider.DOFade(0, _duration / 3);
                _background.DOFade(0, _duration / 3);
                
                transform.DOKill();
            });
        }

        public void Stop()
        {
            _slider.DOFade(0, 0);
            _background.DOFade(0, 0);
        }
    }
}