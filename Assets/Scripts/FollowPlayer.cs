using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject mageObject;
    private Vector3 targetPosition;

    void Start()
    {
        // Find the GameObject named "Mage" in the scene
        mageObject = GameObject.Find("Mage");
        if (mageObject == null)
        {
            Debug.LogError("GameObject named 'Mage' not found!");
        }
    }

    void Update()
    {
        if (mageObject != null)
        {
            // Get the Mage's current X and Z positions
            targetPosition = new Vector3(mageObject.transform.position.x, mageObject.transform.position.y+4f, mageObject.transform.position.z-4f);

            // Update the current GameObject's position
            this.transform.position = targetPosition;
        }
    }
}
