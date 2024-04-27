using System;

namespace Sources.Frameworks.MVVM.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PropertyBindingAttribute : Attribute
    {
        public PropertyBindingAttribute(Type componentType, string componentName = null)
        {
            ComponentType = componentType;
            ComponentName = componentName;
        }

        public Type ComponentType { get; }
        public string ComponentName { get; }
    }
}