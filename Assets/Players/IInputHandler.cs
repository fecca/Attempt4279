namespace Players
{
    public interface IInputHandler
    {
        void Initialize();
        void Enable();
        void Disable();
        void Update();
    }
}