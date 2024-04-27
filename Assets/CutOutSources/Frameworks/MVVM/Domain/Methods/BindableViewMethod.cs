using Sources.Frameworks.MVVM.Domain.Methods;
using Sources.MVVMFrameworks.DomainInterfaces.Methods;
using Sources.MVVMFrameworks.DomainInterfaces.Methods.Generic;
using UnityEngine;

namespace Sources.MVVMFrameworks.Domain.Methods
{
    public class BindableViewMethod<T> : MonoBehaviour, IBindableViewMethod<T>
    {
        protected IBindableMethod<T> BindingCallback { get; private set; }

        public void BindCallBack(IBindableMethod<T> callback) => 
            BindingCallback = callback;

        public void Unbind() => 
            BindingCallback = new BindableMethod<T>(null, null);
    }
}