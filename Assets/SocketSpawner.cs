using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketSpawner : MonoBehaviour
{
    public XRSocketInteractor socket;
    public GameObject objectToSpawn;
    public Vector3 spawnOffset = new Vector3(0f, 0f, 0f);

    public void SpawnObject()
    {
        if (socket == null || objectToSpawn == null)
        {
            Debug.LogError("Socket or Object To Spawn is not assigned!");
            return;
        }

        // Only spawn if the socket is empty
        if (socket.hasSelection)
            return;

        // Spawn the object at the socket's position
        GameObject spawnedObject = Instantiate(
            objectToSpawn,
            socket.transform.position + socket.transform.rotation * spawnOffset,
            socket.transform.rotation
        );

        // Get the interactable component from the spawned object
        XRBaseInteractable interactable =
            spawnedObject.GetComponent<XRBaseInteractable>();

        if (interactable == null)
        {
            Debug.LogError(
                "Spawned prefab needs an XRBaseInteractable component!"
            );
            Destroy(spawnedObject);
            return;
        }

        // Ask the socket to select the spawned object
        //socket.StartManualInteraction((IXRSelectInteractable)interactable);
    }
}