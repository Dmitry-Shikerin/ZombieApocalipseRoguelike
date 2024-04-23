namespace Sources.MVVMFrameworks.DomainIntefraces.Methods
{
    public interface IBindableViewMethod
    {
        void OnBind(object callback);
        void Unbind();
    }
}