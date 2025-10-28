using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    
    public void Interact()
    {
        InventoryScript.Instance.AddItem(gameObject);
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
    }
}
