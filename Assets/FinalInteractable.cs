using UnityEngine;
using UnityEngine.Events;

public class FinalInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    public UnityEvent onInteract;

    public void Interact()
    {
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
        onInteract?.Invoke();
    }
}
