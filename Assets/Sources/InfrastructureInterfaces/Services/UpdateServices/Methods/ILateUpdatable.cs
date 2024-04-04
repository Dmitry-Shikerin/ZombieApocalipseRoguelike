namespace Sources.InfrastructureInterfaces.Services.Updates
{
    public interface ILateUpdatable
    {
        void UpdateLate(float deltaTime);
    }
}