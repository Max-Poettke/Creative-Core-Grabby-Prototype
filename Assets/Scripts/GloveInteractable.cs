using UnityEngine;
using UnityEngine.Events;

public class GloveInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    public UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }

    public void DisplayMessage(){
        DisplayMessageScript.Instance.delay = 3f;
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
        Destroy(this.gameObject);
    }
}
