using Sources.MVVMFrameworks.DomainIntefraces.Methods;

namespace Sources.MVVMFrameworks.DomainInterfaces.Methods.Generic
{
    public interface IBindableViewMethod<T> : IBindableViewMethod
    {
        void BindCallBack(IBindableMethod<T> callback);

        void IBindableViewMethod.OnBind(object callback) =>
            BindCallBack((IBindableMethod<T>)callback);
    }
}