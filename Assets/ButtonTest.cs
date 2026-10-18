using UnityEngine;


public class ButtonTest : MonoBehaviour
{
    public Shoot shootScript;
    public GameObject switch_color;

    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable bookGrab;

    public void TestHover()
    {
        Debug.Log("BUTTON HOVERED");
    }

    public string spellName;

    public void TestPress()
    {
        if (bookGrab == null || !bookGrab.isSelected)
        {
            Debug.Log("Pick up the book first!");
            return;
        }

        if (shootScript == null)
        {
            Debug.LogError("Shoot Script is not assigned!");
            return;
        }

        if (switch_color == null)
        {
            Debug.LogError("Switch Color prefab is not assigned!");
            return;
        }

        Debug.Log(spellName + " button pressed!");
        
        shootScript.SetBulletPrefab(switch_color);
        
    }
}   