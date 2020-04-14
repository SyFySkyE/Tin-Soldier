/// <summary>
/// Interface for interactive objects. Objects inheriting this make the player able to interact with.
/// </summary>
public interface IInteractable
{
    string DisplayText { get; }
    void Interact();
}