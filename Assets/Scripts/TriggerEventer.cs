using UnityEngine;
using UnityEngine.Events;

public class TriggerEventer : MonoBehaviour
{
    public string tag = "";
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(tag == ""){
            onTriggerEnter?.Invoke();
        }
        else if(other.CompareTag(tag)){
            onTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(tag == ""){
            onTriggerStay?.Invoke();
        }
        else if(other.CompareTag(tag)){
            onTriggerStay?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(tag == ""){
            onTriggerExit?.Invoke();
        }
        else if(other.CompareTag(tag)){
            onTriggerExit?.Invoke();
        }
    }
}
