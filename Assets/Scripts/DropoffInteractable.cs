using UnityEngine;

public class DropoffInteractable : MonoBehaviour, IInteractable
{
    private int stateIndex = 0;
    
    [Header("Development state 0-1")]
    [SerializeField] private Material[] stateMaterials;

    [Header("Development state 2")]
    [SerializeField] private GameObject[] gears;
    [SerializeField] private Animator animator;

    [Header("Always used")]
    [SerializeField] private int stateOfDevelopment = 0;
    [SerializeField] private string[] interactionDescriptions;
    public string InteractionDescription { get { return ""; } set { } }
    [SerializeField] private LiftScript liftScript;
    
    public void Interact()
    {
        if(InventoryScript.Instance.RemoveItem())
        {
            DisplayMessageScript.Instance.DisplayMessage(interactionDescriptions[stateIndex]);
            if(stateOfDevelopment < 2) {
                GetComponent<Renderer>().material = stateMaterials[stateIndex];
            } else {
                gears[stateIndex].SetActive(true);
            }
            if(stateIndex == 3)
            {
                animator.SetTrigger("Fixed");
                liftScript.EnableLift();
            }
            stateIndex++;
        } else {
            DisplayMessageScript.Instance.DisplayMessage(interactionDescriptions[4]);
        }
    }
}
