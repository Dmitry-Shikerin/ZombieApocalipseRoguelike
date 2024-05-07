using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Constants;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.UI.Curtains
{
    public class CurtainView : View
    {
        [Required] [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 1f;
        
        public bool IsInProgress { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _canvasGroup.alpha = 0;
        }

        public async UniTask ShowCurtain()
        {
            IsInProgress = true;
            Show();
            await Fade(0, 1);
        }

        public async UniTask HideCurtain()
        {
            await Fade(1, 0);
            Hide();
            IsInProgress = false;
        }

        private async UniTask Fade(float start, float end)
        {
            _canvasGroup.alpha = start;
            
            while (Mathf.Abs(_canvasGroup.alpha - end) > MathConstant.Epsilon)
            {
                _canvasGroup.alpha = Mathf.MoveTowards(
                    _canvasGroup.alpha,
                    end,
                    Time.deltaTime / _duration);

                // await UniTask.Yield();
                //TODO как заигнорить TimeScale?
                await UniTask.Delay(TimeSpan.FromMilliseconds(1), ignoreTimeScale: true);
            }

            _canvasGroup.alpha = end;
        }
    }
}