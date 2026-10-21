using UnityEngine;
using System.Collections.Generic;

public class SpellSequenceManager : MonoBehaviour
{
    private List<string> sequence = new List<string>();

    public SocketSpawner socketSpawner;

    public void AddSpell(string spellName)
    {
        sequence.Add(spellName);

        Debug.Log("Sequence: " + string.Join(", ", sequence));

        if (sequence.Count >= 4 &&
            sequence[sequence.Count - 4] == "EARTH" &&
            sequence[sequence.Count - 3] == "AIR" &&
            sequence[sequence.Count - 2] == "FIRE" &&
            sequence[sequence.Count - 1] == "WATER")
        {
            Debug.Log("SPELL MATCHED - TRYING TO SPAWN");

            if (socketSpawner != null)
                socketSpawner.SpawnObject();
            else
                Debug.LogError("SocketSpawner is not assigned!");

            sequence.Clear();
        }
    }
}
