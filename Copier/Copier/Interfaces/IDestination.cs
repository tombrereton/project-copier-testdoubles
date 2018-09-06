namespace CopierProject.Interfaces
{
    public interface IDestination
    {
        // This returns void so we cannot test the state
        void SetChar(char character);
    }
}
