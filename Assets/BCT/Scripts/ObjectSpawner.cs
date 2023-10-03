using System.Collections.Generic;
using UnityEngine;
using TS.GazeInteraction;
using TS.GazeInteraction.Demo;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public float spawnRadius = 3.0f;
    //public GameObject childPrefab;  // The child GameObject assigned from the Inspector
    //public Material targetMaterial;
     
    //public GameObject targetPrefab;
    private TargetHandler targetHandler;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private GameObject currentTarget;

    void Start()
    {
        targetHandler = GetComponent<TargetHandler>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            spawnedObjects.Clear();
            for (int i = 0; i < 25; i++)
            {
                Vector3 randomPos = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
                if (randomPos.y < 0) { randomPos.y = 0; }
                GameObject objectToSpawn = UnityEngine.Random.Range(0, 2) == 0 ? spherePrefab : cubePrefab;
                GameObject spawned = Instantiate(objectToSpawn, randomPos, Quaternion.identity);
                spawnedObjects.Add(spawned);
            }
          //  MarkRandomTarget();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            MarkRandomTarget();
        }
    }

    void MarkRandomTarget()
    {
        if (currentTarget != null)
        {
            Destroy(currentTarget);
            spawnedObjects.Remove(currentTarget);
        }

        if (spawnedObjects.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnedObjects.Count);
            currentTarget = spawnedObjects[randomIndex];
            currentTarget.tag = "Target";

            // Call SetupTarget from the TargetHandler script
            if (targetHandler != null)
            {
                targetHandler.SetupTarget(currentTarget);
            }
        }
    }


    //public void EnableGazeInteractableDemo()
    //{
    //    GazeInteractableDemo gazeDemo = currentTarget.GetComponent<GazeInteractableDemo>();
    //    if (gazeDemo != null)
    //    {
    //        gazeDemo.Enable();
    //    }
    //}

    //public void ResetGazeInteractableDemo()
    //{
    //    GazeInteractableDemo gazeDemo = currentTarget.GetComponent<GazeInteractableDemo>();
    //    if (gazeDemo != null)
    //    {
    //        gazeDemo.Reset();
    //    }
    //}


    //void ReplaceWithPrefab()
    //{
    //    if (currentTarget != null)
    //    {
    //        // Save the position and rotation of the current target
    //        Vector3 position = currentTarget.transform.position;
    //        Quaternion rotation = currentTarget.transform.rotation;

    //        // Remove the current target from the list and destroy it
    //        spawnedObjects.Remove(currentTarget);
    //        Destroy(currentTarget);

    //        // Instantiate the new target from the prefab
    //        GameObject newTarget = Instantiate(targetPrefab, position, rotation);

    //        // Add the new target to the list and set it as the current target
    //        spawnedObjects.Add(newTarget);
    //        currentTarget = newTarget;
    //    }
    //}

}
