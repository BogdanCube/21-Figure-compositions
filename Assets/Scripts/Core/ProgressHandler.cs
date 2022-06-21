using DG.Tweening;
using UI;
using UnityEngine;

namespace Core
{
    public class ProgressHandler : MonoBehaviour
    {
        [SerializeField] private ProgressBar _progressBar;

        public ProgressBar Bar => _progressBar;

        public void StartBar(ParticleSystem particle)
        {
            _progressBar.FilledBar().OnKill(() =>
            {
                particle.gameObject.SetActive(true);
            });
        }

        public void StopBar()
        {
            _progressBar.Stop();
        }
    }
}