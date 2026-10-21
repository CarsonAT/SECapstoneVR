using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonTest : MonoBehaviour
{
    public Shoot shootScript;
    public GameObject switch_color;
    public XRGrabInteractable bookGrab;
    public SocketSpawner socketSpawner;
    public SpellSequenceManager sequenceManager;

    public string spellName;

    private List<string> sequence = new List<string>();

    public void TestHover()
    {
        Debug.Log("BUTTON HOVERED");
    }

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

        sequence.Add(spellName);

        shootScript.SetBulletPrefab(switch_color);

        if (sequenceManager != null)
        {
            sequenceManager.AddSpell(spellName);
        }
        else
        {
            Debug.LogError("SpellSequenceManager is not assigned!");
        }
    }
}