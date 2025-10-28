using UnityEngine;

public class DropoffInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private LiftScript liftScript;
    public string InteractionDescription { get { return ""; } set { } }
    private int stateIndex = 0;
    [SerializeField] private Material[] stateMaterials;
    [SerializeField] private string[] interactionDescriptions;
    
    public void Interact()
    {
        if(InventoryScript.Instance.RemoveItem())
        {
            DisplayMessageScript.Instance.DisplayMessage(interactionDescriptions[stateIndex]);
            GetComponent<Renderer>().material = stateMaterials[stateIndex];
            if(stateIndex == 3)
            {
                liftScript.EnableLift();
            }
            stateIndex++;
        } else {
            DisplayMessageScript.Instance.DisplayMessage(interactionDescriptions[4]);
        }
    }
}
