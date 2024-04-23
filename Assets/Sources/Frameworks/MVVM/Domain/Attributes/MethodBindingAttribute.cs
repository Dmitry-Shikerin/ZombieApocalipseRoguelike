using System;

namespace Sources.MVVMFrameworks.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodBindingAttribute : Attribute
    {
        public MethodBindingAttribute(Type componentType, string componentName = null)
        {
            ComponentType = componentType;
            ComponentName = componentName;
        }

        public Type ComponentType { get; }
        public string ComponentName { get; }
    }
}