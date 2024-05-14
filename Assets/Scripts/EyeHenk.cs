using UnityEngine;

public class EyeHenk : MonoBehaviour
{
    public Transform target; // Reference to the target game object

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the eye to the target
            Vector3 targetDir = target.position - transform.position;
            // Calculate the angle in degrees
            float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;
            // Apply the rotation to the eye
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
