namespace Rover.Interface
{
    public interface IRoverState
    {
        string Output();

        bool Equals(IRoverState state);

        IRoverState Clone();
    }
}