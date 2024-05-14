using System.Collections;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    public float rotationSpeed = 720f; // Adjust this to control how fast the rotation happens
    private bool conditionMet = false;

    void Update()
    {
        // Trigger rotation if condition is met
        if (conditionMet)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void TriggerRotation()
    {
        conditionMet = true;
    }

}
