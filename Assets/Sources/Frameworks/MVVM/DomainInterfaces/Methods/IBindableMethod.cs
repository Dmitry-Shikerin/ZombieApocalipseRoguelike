namespace Sources.MVVMFrameworks.DomainInterfaces.Methods
{
    public interface IBindableMethod<T>
    {
        void Invoke(params object[] args);        
    }
}