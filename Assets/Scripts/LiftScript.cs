using UnityEngine;
using System.Collections.Generic;

public class LiftScript : MonoBehaviour
{
    public bool isLiftEnabled = false;
    [SerializeField] private List<Transform> liftPositions;
    [SerializeField] private float liftSpeed = 5f;
    private int liftIndex = 0;
    private Transform playerTransform;

    private void Update()
    {
        if (isLiftEnabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, liftPositions[liftIndex].position, liftSpeed * Time.deltaTime);
            if (transform.position == liftPositions[liftIndex].position)
            {
                liftIndex++;
                if (liftIndex == liftPositions.Count)
                {
                    liftIndex = 0;
                }
                DisableLift();
                Invoke("EnableLift", 1f);
            }
        }
    }

    public void EnableLift()
    {
        isLiftEnabled = true;
    }

    public void DisableLift()
    {
        isLiftEnabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered lift");
            playerTransform = other.transform;
            playerTransform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited lift");
            playerTransform.parent = null;
            playerTransform = null;
        }
    }
}
