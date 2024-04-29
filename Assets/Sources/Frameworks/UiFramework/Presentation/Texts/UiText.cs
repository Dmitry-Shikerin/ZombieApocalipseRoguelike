using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Domain.Models.TextViewTypes;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.Texts;
using TMPro;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Presentation.Texts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UiText : View, IUiText
    {
        [DisplayAsString(false)] [HideLabel] 
        [SerializeField] private string _label = UiConstant.UiTextLabel;
        [SerializeField] private TextMeshProUGUI _tmpText;
        [TabGroup("Settings")] [SerializeField]
        private TextViewType _textViewType;
        [TabGroup("Ids")] 
        [SerializeField] private string _textId;

        public TextViewType TextViewType => _textViewType;
        public bool IsHide { get; private set; }
        public string Id => _textId;
        
        public void SetText(string text) =>
            _tmpText.text = text;

        public void SetTextColor(Color color) =>
            _tmpText.color = color;

        public void SetIsHide(bool isHide) =>
            IsHide = isHide;

        public async void SetClearColorAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (_tmpText.color.a > 0)
                {
                    _tmpText.color = Vector4.MoveTowards(
                        _tmpText.color, Vector4.zero, 0.01f);

                    await UniTask.Yield(cancellationToken);
                }

                IsHide = true;
            }
            catch (OperationCanceledException)
            {
                IsHide = true;
            }
        }

        public void Enable() =>
            _tmpText.enabled = true;

        public void Disable() =>
            _tmpText.enabled = false;

        [Button(ButtonSizes.Large)] [ButtonGroup("Settings")]
        public void AddTmpText() =>
            gameObject.AddComponent<TextMeshProUGUI>();

        [Button(ButtonSizes.Large)] [ButtonGroup("Settings")]
        public void SetTmpText() =>
            _tmpText = GetComponent<TextMeshProUGUI>();
    }
}