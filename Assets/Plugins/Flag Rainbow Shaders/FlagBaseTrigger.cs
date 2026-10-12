using UnityEngine;

public class FlagBaseTrigger : MonoBehaviour
{
    public FlagController flagController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flagController.isPlayerTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flagController.isPlayerTouching = false;
        }
    }
}