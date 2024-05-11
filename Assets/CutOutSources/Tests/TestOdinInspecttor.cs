using Sirenix.OdinInspector;
using UnityEngine;

namespace CutOutSources.Tests
{
    public class TestOdinInspecttor : MonoBehaviour
    {
        [TitleGroup("Tabs")]
        [HorizontalGroup("Tabs/Split", Width = 0.5f)]
        [TabGroup("Tabs/Split/Parameters", "A")]
        public string NameA;
        [HorizontalGroup("Tabs/Split", Width = 0.5f)]
        [TabGroup("Tabs/Split/Parameters", "A")]
        public string NameB;
        [HorizontalGroup("Tabs/Split", Width = 0.5f)]
        [TabGroup("Tabs/Split/Parameters", "A")]
        public string NameC;
    
        [TabGroup("Tabs/Split/Parameters", "B")]
        public int ValueA;
        [TabGroup("Tabs/Split/Parameters", "B")]
        public int ValueB;
        [TabGroup("Tabs/Split/Parameters", "B")]
        public int ValueC;
    
        [TabGroup("Tabs/Split/Buttons", "Responsive")]
        [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
        public void Hello() { }
    
        [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
        public void World() { }
    
        [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
        public void And() { }
    
        [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
        public void Such() { }
    
        [Button]
        [TabGroup("Tabs/Split/Buttons", "More Tabs")]
        [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "A")]
        public void SubButtonA() { }
    
        [Button]
        [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "A")]
        public void SubButtonB() { }
    
        [Button(ButtonSizes.Gigantic)]
        [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "B")]
        public void SubButtonC() { }
    }
}

