using UnityEngine;

public class FlagController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 0.5f;
    public float lowerLimitY = 2.5f;
    public float upperLimitY = 17.95f;

    [HideInInspector]
    public bool isPlayerTouching = false;
    private bool hasInitialized = false;

    void Start()
    {
        hasInitialized = true;
    }

    void Update()
    {
        if (!hasInitialized) return;

        Vector3 pos = transform.localPosition;

        if (isPlayerTouching)
        {
            if(pos.y < upperLimitY)
            {
                pos.y += moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(pos.y > lowerLimitY)
            {
                pos.y -= moveSpeed * Time.deltaTime;
            }
        }

        transform.localPosition = pos;
    }
}