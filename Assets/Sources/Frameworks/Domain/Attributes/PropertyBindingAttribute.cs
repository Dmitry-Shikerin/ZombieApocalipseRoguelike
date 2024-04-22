using System;

namespace Sources.MVVMFrameworks.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
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