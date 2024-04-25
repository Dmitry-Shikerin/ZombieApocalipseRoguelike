using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sources.Controllers.ModelViews;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.Frameworks.MVVM.Presentation.Exceptions;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.MVVMFrameworks.DomainIntefraces.Methods;
using Sources.MVVMFrameworks.DomainInterfaces.Properties;
using Sources.MVVMFrameworks.DomainInterfaces.Services.Factories;
using Sources.MVVMFrameworks.DomainServices.Factories;
using UnityEngine;

namespace Sources.Frameworks.Presentations.Binders
{
    public class Binder : IBinder
    {
        private static readonly BindingFlags s_fieldBindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic;

        private static readonly string s_viewModelPartsFieldName = "_components";

        private readonly List<Type> _notFoundTypes = new List<Type>();
        private readonly IBindablePropertyFactory _propertyFactory = new BindablePropertyFactory();
        private readonly IBindableMethodFactory _methodFactory = new BindableMethodFactory();
        
        
        public void Bind(IBindableView view, IViewModel viewModel)
        {
            _notFoundTypes.Clear();

            ApplyToFields(view, viewModel, BindField);
            ApplyToPartFields(view, viewModel, BindField);
            ApplyToMethods(view, viewModel, BindMethod);
            ApplyToPartMethods(view, viewModel, BindMethod);

            viewModel.Destroyed += view.Unbind;

            if (_notFoundTypes.Count > 0)
                throw new NotFoundBindableViewException(view.GetType(), _notFoundTypes);
        }

        public void Unbind(IBindableView view, IViewModel viewModel)
        {
            viewModel.Destroyed -= view.Unbind;
            viewModel.Disable();
            
            _notFoundTypes.Clear();
            
            ApplyToFields(view, viewModel, UnbindField);
            ApplyToPartFields(view, viewModel, UnbindField);
            ApplyToMethods(view, viewModel, UnbindMethod);
            ApplyToPartMethods(view, viewModel, UnbindMethod);

            if (_notFoundTypes.Count > 0)
                throw new NotFoundBindableViewException(view.GetType(), _notFoundTypes);
        }

        private void ApplyToPartMethods(IBindableView view, IViewModel viewModel,
            Action<object, MethodInfo, IBindableViewMethod> bindMethod)
        {
            object[] parts = GetParts(viewModel);

            foreach (object part in parts) 
                ApplyToMethods(view, part, bindMethod);
        }
        
        private void ApplyToPartFields(IBindableView view, IViewModel viewModel,
            Action<object, FieldInfo, IBindableViewProperty> bindField)
        {
            object[] parts = GetParts(viewModel);

            foreach (object part in parts) 
                ApplyToFields(view, part, bindField);

            //TODO можно ли так?
            // GetParts(viewModel).ForEach(part => ApplyToFields(view, part, bindField));
        }

        private void ApplyToFields(IBindableView view, object viewModel,
            Action<object, FieldInfo, IBindableViewProperty> action)
        {
            foreach (FieldInfo fieldInfo in viewModel.GetType().GetFields(s_fieldBindingFlags))
            {
                foreach (object attribute in fieldInfo.GetCustomAttributes(true))
                {
                    if (attribute is PropertyBindingAttribute bindingAttribute)
                    {
                        IBindableViewProperty bindableViewProperty = GetBindableProperty(view, bindingAttribute);

                        if (bindableViewProperty == null)
                        {
                            _notFoundTypes.Add(bindingAttribute.ComponentType);
                            
                            continue;
                        }
                        
                        action.Invoke(viewModel, fieldInfo, bindableViewProperty);
                    }
                }
            }
        }
        
        private object[] GetParts(IViewModel viewModel)
        {
            FieldInfo fieldInfo = typeof(ViewModelBase).GetField(s_viewModelPartsFieldName, s_fieldBindingFlags);

            return (object[])fieldInfo?.GetValue(viewModel) ?? new object[] { };
        }

        private void ApplyToMethods(IBindableView view, object viewModel,
            Action<object, MethodInfo, IBindableViewMethod> action)
        {
            foreach (MethodInfo methodInfo in viewModel.GetType().GetMethods(s_fieldBindingFlags))
            {
                foreach (object attribute in methodInfo.GetCustomAttributes(true))
                {
                    if (attribute is MethodBindingAttribute bindingAttribute)
                    {
                        IBindableViewMethod bindableViewMethod = GetBindableMethod(view, bindingAttribute);

                        if (bindableViewMethod == null)
                        {
                            _notFoundTypes.Add(bindingAttribute.ComponentType);
                            
                            continue;
                        }
                        
                        action.Invoke(viewModel, methodInfo, bindableViewMethod);
                    }
                }
            }
        }
        
        private void BindField(object viewModel,
            FieldInfo fieldInfo, IBindableViewProperty bindableViewProperty)
        {
            fieldInfo.SetValue(viewModel, bindableViewProperty.OnBind(_propertyFactory));
        }
        
        private void UnbindField(object viewModel,
            FieldInfo fieldInfo, IBindableViewProperty bindableViewProperty)
        {
            (fieldInfo.GetValue(viewModel) as IDisposable)?.Dispose();
            fieldInfo.SetValue(viewModel, null);
        }
        
        private void BindMethod(object viewModel,
            MethodInfo methodInfo, IBindableViewMethod bindableViewMethod)
        {
            bindableViewMethod.OnBind(_methodFactory.Create(viewModel, methodInfo));
        }
        
        private void UnbindMethod(object viewModel,
            MethodInfo methodInfo, IBindableViewMethod bindableViewMethod)
        {
            bindableViewMethod.Unbind();
        }

        private IBindableViewMethod GetBindableMethod(
            IBindableView view, MethodBindingAttribute bindingAttribute)
        {
            return (view as MonoBehaviour)?
                   .GetComponents(bindingAttribute.ComponentType)
                   .FirstOrDefault(childComponent => childComponent.name ==
                                                     (bindingAttribute.ComponentName ?? childComponent.name))
                   as IBindableViewMethod
                   ?? (view as MonoBehaviour)?
                   .GetComponentsInChildren(bindingAttribute.ComponentType, true)
                   .FirstOrDefault(childComponent => childComponent.name ==
                                                     (bindingAttribute.ComponentName ?? childComponent.name))
                   as IBindableViewMethod;
        }

        private IBindableViewProperty GetBindableProperty(
            IBindableView view, PropertyBindingAttribute bindingAttribute)
        {
            return (view as MonoBehaviour)?
                   .GetComponents(bindingAttribute.ComponentType)
                   .FirstOrDefault(childComponent => childComponent.name ==
                                                     (bindingAttribute.ComponentName ?? childComponent.name))
                   as IBindableViewProperty
                   ?? (view as MonoBehaviour)?
                   .GetComponentsInChildren(bindingAttribute.ComponentType, true)
                   .FirstOrDefault(childComponent => childComponent.name ==
                                                     (bindingAttribute.ComponentName ?? childComponent.name))
                   as IBindableViewProperty;
        } 
    }
}