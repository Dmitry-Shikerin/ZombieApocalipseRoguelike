using Sirenix.OdinInspector;
using Sources.Domain.TextViewTypes;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.Texts;
using TMPro;
using UnityEngine;

namespace Sources.Presentations.UI.Texts
{
    public class TextView : View, ITextView 
    {
        [Required] [SerializeField] private TextMeshProUGUI _tmpText;
        [SerializeField] private TextViewType _textViewType;
        [SerializeField] private string _textId;

        public TextViewType TextViewType => _textViewType;
        public string Id => _textId;
        
        public void SetText(string text) =>
            _tmpText.text = text;

        public void Enable() =>
            _tmpText.enabled = true;

        public void Disable() =>
            _tmpText.enabled = false;
    }
}