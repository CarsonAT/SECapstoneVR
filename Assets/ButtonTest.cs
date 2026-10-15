using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public void TestHover()
    {
        Debug.Log("BUTTON HOVERED");
    }

    public string spellName;

    public void TestPress()
    {
        Debug.Log(spellName + " button pressed!");
    }
}   