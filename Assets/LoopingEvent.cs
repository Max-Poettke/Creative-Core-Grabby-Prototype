using UnityEngine;
using UnityEngine.Events;

public class LoopingEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onLoop;
    [SerializeField] private float loopInterval = 1f;
    private float timer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onLoop.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= loopInterval)
        {
            timer = 0f;
            onLoop.Invoke();
        }
    }
}
