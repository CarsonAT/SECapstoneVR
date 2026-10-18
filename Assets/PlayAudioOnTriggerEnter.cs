using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    public string targetTag;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. Prints whenever ANY collider enters the trigger
        // Debug.Log("Collision detected with: " + other.gameObject.name + " | Tag: " + other.tag);

        if(other.CompareTag(targetTag))
        {
            // 2. Prints only if the tag perfectly matches
            // Debug.Log("Tag matched! Attempting to play audio...");
            source.PlayOneShot(clip);
        }
        else
        {
            // 3. Prints if the tag was wrong
            // Debug.Log("Tag did NOT match. Expected: " + targetTag + " | Found: " + other.tag);
        }
    }
}