using UnityEngine;
using UnityEngine.Events;
using TS.GazeInteraction.Demo;
using TS.GazeInteraction;  // Import the namespace for GazeInteractable

public class TargetHandler : MonoBehaviour
{
    public Material targetMaterial;
    public float demoSpeed = 1.0f;  // Desired speed for GazeInteractableDemo
    public float demoRadius = 1.0f; // Desired radius for GazeInteractableDemo

    public void SetupTarget(GameObject target)
    {
        // Add and configure GazeInteractableDemo script
        GazeInteractableDemo gazeDemo = target.GetComponent<GazeInteractableDemo>();
        gazeDemo._speed = demoSpeed;
        gazeDemo._radius = demoRadius;

        // Optionally change the target material
        Renderer rend = target.GetComponent<Renderer>();
        if (rend != null && targetMaterial != null)
        {
            rend.material = targetMaterial;
        }

        // Enable the first child object
        if (target.transform.childCount > 0)
        {
            Transform childTransform = target.transform.GetChild(0);
            GameObject child = childTransform.gameObject;
            child.SetActive(true);

            // Enable GazeInteractable script on the child
            GazeInteractable gazeScript = child.GetComponent<GazeInteractable>();
            if (gazeScript != null)
            {
                gazeScript.enabled = true;
            }
        }
    }
}
