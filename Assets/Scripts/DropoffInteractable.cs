using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class DropoffInteractable : MonoBehaviour, IInteractable
{
    private int stateIndex = 0;
    
    [Header("Development state 0-1")]
    [SerializeField] private Material[] stateMaterials;

    [Header("Development state 2")]
    [SerializeField] private GameObject[] gears;
    [SerializeField] private Animator animator;

    [Header("Development state 3")]
    [SerializeField] private GameObject activationEffects;
    [SerializeField] private UnityEvent onFixed;
    [SerializeField] private UnityEvent onSuccess;
    [SerializeField] private UnityEvent onFail;
    [SerializeField] private VisualEffect visualEffect;

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
            visualEffect.transform.position = gears[stateIndex].transform.position;
            visualEffect.Play();
            onSuccess.Invoke();
            if(stateOfDevelopment < 2) {
                GetComponent<Renderer>().material = stateMaterials[stateIndex];
            } else {
                gears[stateIndex].SetActive(true);
            }
            if(stateIndex == 3)
            {
                animator.SetTrigger("Fixed");
                liftScript.EnableLift();
                activationEffects.SetActive(true);
                onFixed.Invoke();
            }
            stateIndex++;
        } else {
            DisplayMessageScript.Instance.DisplayMessage(interactionDescriptions[4]);
            onFail.Invoke();
        }
    }
}
