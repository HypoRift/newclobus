using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleGrab : MonoBehaviour
{
    public float maxGrabDistance = 1.5f; // Maximum distance from which the object can be grabbed

    private Rigidbody rb;
    private bool isGrabbed = false;
    private Transform originalParent;

    private XRController xrController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;

        // Find the XRController in the scene (assuming only one hand)
        xrController = FindObjectOfType<XRController>();
    }

    void Update()
    {
        // Check if the object is not currently grabbed and the controller is valid
        if (!isGrabbed && xrController)
        {
            // Calculate the distance between the controller and the object
            float distance = Vector3.Distance(transform.position, xrController.transform.position);
            if (distance <= maxGrabDistance) // Check if the distance is within the maximum grab distance
            {
                // Check if the grip button is pressed
                if (xrController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripValue) && gripValue)
                {
                    GrabObject();
                }
            }
        }
        // Check if the object is grabbed and the grip button is released
        else if (isGrabbed && xrController && xrController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripValue) && !gripValue)
        {
            ReleaseObject();
        }
    }

    void GrabObject()
    {
        // Disable gravity while the object is grabbed
        rb.useGravity = false;
        // Disable physics while the object is grabbed
        rb.isKinematic = true;
        // Attach the object to the controller
        transform.SetParent(xrController.transform);
        // Set the object as grabbed
        isGrabbed = true;
    }

    void ReleaseObject()
    {
        // Enable gravity when the object is released
        rb.useGravity = true;
        // Enable physics when the object is released
        rb.isKinematic = false;
        // Reset the object's parent
        transform.SetParent(originalParent);
        // Set the object as released
        isGrabbed = false;
    }
}
