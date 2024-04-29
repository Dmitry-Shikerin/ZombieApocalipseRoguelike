using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Domain.Models.Localizations;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.Animations;
using Sources.Frameworks.UiFramework.Presentation.AudioSources;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.Texts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiCollector : View
    {
        [FormerlySerializedAs("_lebelText")]
        [DisplayAsString(false)] [HideLabel]
        [SerializeField] private string _lebel = UiConstant.UiCollectorLabel;
        [TabGroup("Tab1", "Texts", true, 1)] [EnumToggleButtons]
        [SerializeField] private Localization _localization;
        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeTexts = Enable.Enable;
        [TabGroup("Tab1", "Containers", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive" , SdfIconType.Search)]
        [SerializeField] private Enable _includeContainers = Enable.Enable;
        [TabGroup("Tab1", "Buttons", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeButtons = Enable.Enable;
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeAudioSources = Enable.Enable;
        [TabGroup("Tab1", "Animators", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeAnimators = Enable.Enable;
        
        private List<UiButton> _uiFormButtons;
        private List<UiContainer> _uiContainers;
        private List<UiText> _uiTexts;
        private List<UiAudioSource> _uiAudioSources;
        private List<UiAnimator> _uiAnimators;
        
        private bool IncludeTexts => _includeTexts == Enable.Enable;
        private bool IncludeContainers => _includeContainers == Enable.Enable;
        private bool IncludeButtons => _includeButtons == Enable.Enable;
        private bool IncludeAudioSources => _includeAudioSources == Enable.Enable;
        private bool IncludeAnimators => _includeAnimators == Enable.Enable;

        public Localization Localization => _localization;
        public IReadOnlyList<UiButton> UiFormButtons => _uiFormButtons;
        public IReadOnlyList<UiContainer> UiContainers => _uiContainers;
        public IReadOnlyList<IUiText> UiTexts => _uiTexts;
        public IReadOnlyList<UiAudioSource> UiAudioSources => _uiAudioSources;
        public IReadOnlyList<UiAnimator> UiAnimators => _uiAnimators;

        private void Awake()
        {
            _uiFormButtons = GetComponentsInChildren<UiButton>(IncludeButtons).ToList();
            _uiContainers = GetComponentsInChildren<UiContainer>(IncludeContainers).ToList();
            _uiTexts = GetComponentsInChildren<UiText>(IncludeTexts).ToList();
            _uiAudioSources = GetComponentsInChildren<UiAudioSource>(IncludeAudioSources).ToList();
            _uiAnimators = GetComponentsInChildren<UiAnimator>(IncludeAnimators).ToList();
        }
    }
}