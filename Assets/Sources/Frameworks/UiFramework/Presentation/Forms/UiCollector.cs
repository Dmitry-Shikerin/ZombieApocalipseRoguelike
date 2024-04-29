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
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [SerializeField] private List<UiText> _uiTexts;

        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeTexts = Enable.Enable;
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons]
        [SerializeField] private Enable _testLocalization = Enable.Enable; 
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [EnableIf("_testLocalization", Enable.Enable)]
        [SerializeField] private Localization _localization;
        
        [TabGroup("Tab1", "Containers", true, 1)] 
        [SerializeField] private List<UiContainer> _uiContainers;
        
        [TabGroup("Tab1", "Containers", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive" , SdfIconType.Search)]
        [SerializeField] private Enable _includeContainers = Enable.Enable;
        
        [TabGroup("Tab1", "Buttons", true, 1)] 
        [SerializeField] private List<UiButton> _uiFormButtons;
        
        [TabGroup("Tab1", "Buttons", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeButtons = Enable.Enable;
        
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [SerializeField] private List<UiAudioSource> _uiAudioSources;
        
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeAudioSources = Enable.Enable;
        
        [TabGroup("Tab1", "Animators", true, 1)]
        [SerializeField] private List<UiAnimator> _uiAnimators;
        
        [TabGroup("Tab1", "Animators", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeAnimators = Enable.Enable;
        
        
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

        [TabGroup("Tab1","Texts", true, 1)] 
        [Button(ButtonSizes.Large)] 
        private void AddTexts() =>
            _uiTexts = GetComponentsInChildren<UiText>(IncludeTexts).ToList();

        [TabGroup("Tab1","Texts", true, 1)] 
        [Button(ButtonSizes.Medium)] 
        private void ClearTexts() =>
            _uiTexts.Clear();

        [TabGroup("Tab1", "Containers", true, 1)] 
        [Button(ButtonSizes.Large)]
        private void AddContainers() =>
            _uiContainers = GetComponentsInChildren<UiContainer>(IncludeContainers).ToList();
        
        [TabGroup("Tab1", "Containers", true, 1)] 
        [Button(ButtonSizes.Medium)]
        private void ClearContainers() =>
            _uiContainers.Clear();
        
        [TabGroup("Tab1", "Buttons", true, 1)] 
        [Button(ButtonSizes.Large)] 
        private void AddButtons() =>
            _uiFormButtons = GetComponentsInChildren<UiButton>(IncludeButtons).ToList();
        
        [TabGroup("Tab1", "Buttons", true, 1)] 
        [Button(ButtonSizes.Medium)]
        private void ClearButtons() =>
            _uiFormButtons.Clear();
        
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [Button(ButtonSizes.Large)]
        private void AddAudioSources() =>
            _uiAudioSources = GetComponentsInChildren<UiAudioSource>(IncludeAudioSources).ToList();
        
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [Button(ButtonSizes.Medium)]
        private void ClearAudioSources() =>
            _uiAudioSources.Clear();
        
        [TabGroup("Tab1", "Animators", true, 1)] 
        [Button(ButtonSizes.Large)]
        private void AddAnimators() =>
            _uiAnimators = GetComponentsInChildren<UiAnimator>(IncludeAnimators).ToList();
        
        [TabGroup("Tab1", "Animators", true, 1)]
        [Button(ButtonSizes.Medium)]
        private void ClearAnimators() =>
            _uiAnimators.Clear();
    }
}