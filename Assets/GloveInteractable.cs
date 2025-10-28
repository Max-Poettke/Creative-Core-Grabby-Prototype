using UnityEngine;
using UnityEngine.Events;

public class GloveInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    public UnityEvent onInteract;

    public void Interact()
    {
        DisplayMessageScript.Instance.delay = 3f;
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
        onInteract?.Invoke();
        Destroy(this.gameObject);
    }
}
