using UnityEngine;

public interface IInteractable
{
    string InteractionDescription {
        get;
        set;
    }
    void Interact();
}