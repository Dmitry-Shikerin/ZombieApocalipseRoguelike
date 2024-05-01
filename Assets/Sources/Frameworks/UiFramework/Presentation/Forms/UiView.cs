using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Frameworks.UiFramework.Controllers.Forms;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Domain.Constants;
using Sources.Frameworks.UiFramework.Presentation.CommonTypes;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Frameworks.UiFramework.Presentation.Forms
{
    public class UiView : PresentableView<UiViewPresenter>, IUiView
    {
        [DisplayAsString(false)] [HideLabel] [Indent(8)] [SerializeField]
        private string _label = UiConstant.UiContainerLabel;

        [TabGroup("Showed Settings")] [EnumToggleButtons] [HideLabel] [LabelText("Enabled GameObject")] 
        [SerializeField] private Enable _enabledGameObject;

        [TabGroup("Showed Settings")]
        [EnumToggleButtons] [HideLabel] [LabelText("Enabled CanvasGroup")] 
        [SerializeField] private Enable _EnabledCanvasGroup;

        [TabGroup("Type")] [EnumToggleButtons] [SerializeField]
        private ContainerType _containerType = ContainerType.Form;

        [TabGroup("Type")] [EnableIf(nameof(_customFormId), CustomFormId.Default)] [SerializeField]
        private FormId _formId;

        [TabGroup("Type")] [EnableIf(nameof(_formId), FormId.Default)] [SerializeField]
        private CustomFormId _customFormId = CustomFormId.Default;

        [TabGroup("OnEnable")] [HideLabel] [LabelText("Enabled Forms")] 
        [SerializeField] private List<FormId> _onEnableEnabledForms;

        [TabGroup("OnEnable")] [HideLabel] [LabelText("Disabled Forms")]
        [SerializeField] private List<FormId> _onEnableDisabledForms;

        [TabGroup("OnDisable")] [HideLabel] [LabelText("Enabled Forms")] 
        [SerializeField] private List<FormId> _onDisableEnabledForms;

        [TabGroup("OnDisable")] [HideLabel] [LabelText("Disabled Forms")]
        [SerializeField] private List<FormId> _onDisableDisabledForms;

        [TabGroup("Commands")] 
        [SerializeField] private List<FormCommandId> _enabledFormCommands;

        [TabGroup("Commands")] 
        [SerializeField] private List<FormCommandId> _disabledFormCommands;

        public Enable EnabledGameObject => _enabledGameObject;
        public Enable EnabledCanvasGroup => _EnabledCanvasGroup;
        public ContainerType ContainerType => _containerType;
        public IReadOnlyList<FormId> OnEnableEnabledForms => _onEnableEnabledForms;
        public IReadOnlyList<FormId> OnEnableDisabledForms => _onEnableDisabledForms;
        public IReadOnlyList<FormId> OnDisableEnabledForms => _onDisableEnabledForms;
        public IReadOnlyList<FormId> OnDisableDisabledForms => _onDisableDisabledForms;

        public IReadOnlyList<FormCommandId> EnabledFormCommands => _enabledFormCommands;
        public IReadOnlyList<FormCommandId> DisabledFormCommands => _disabledFormCommands;

        public FormId FormId => _formId;
        public CustomFormId CustomFormId => _customFormId;

        [TabGroup("OnEnable")]  [Button] 
        private void AddAllOnEnableEnabledForms() =>
            _onEnableEnabledForms = AddAllForms();
        
        [TabGroup("OnEnable")] [Button]
        private void AddAllOnEnableDisabledForms() =>
            _onEnableDisabledForms = AddAllForms();
        
        [TabGroup("OnDisable")] [Button]
        private void AddAllOnDisableEnabledForms() =>
            _onDisableEnabledForms = AddAllForms();
        [TabGroup("OnDisable")] [Button]
        private void AddAllOnDisableDisabledForms() =>
            _onDisableDisabledForms = AddAllForms();

        private List<FormId> AddAllForms()
        {
            return new List<FormId>()
            {
                FormId.Default,
                FormId.Hud,
                FormId.Pause,
                FormId.Settings,
                FormId.Upgrade,
                FormId.GameOver,
                FormId.LevelCompleted,
                FormId.GreetingTutorial,
                FormId.HealthBarTutorial,
                FormId.KillEnemyCounterTutorial,
                FormId.SaveTutorial,
                FormId.RewardTutorial,
                FormId.EnemySpawnPointsTutorial,
                FormId.UpgradeFormTopAbilitiesTutorial,
                FormId.UpgradeFormBottomAbilitiesTutorial,
                FormId.WarningNewGame,
                FormId.NewGame,
                FormId.Authorization,
                FormId.Leaderboard,
            };
        }
    }
}