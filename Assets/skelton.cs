using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public float reachWeight = 1.0f; // Adjust how intensely it reaches

    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (player == null)
        {
            GameObject playerObj = GameObject.Find("PlayerObj");
            if (playerObj != null) player = playerObj.transform;
        }
    }

    // LateUpdate is ideal for bone manipulation so it overrides movement updates
    void LateUpdate()
    {
        if (player == null || animator == null) return;

        // If it's set up as a Humanoid, we can grab the shoulder/arm bones directly
        Transform rightArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
        Transform leftArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);

        if (rightArm != null)
        {
            // Rotate the arm to point toward the player
            Vector3 directionToPlayer = (player.position - rightArm.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            
            // Blend between its normal T-pose and pointing at the player
            rightArm.rotation = Quaternion.Slerp(rightArm.rotation, targetRotation, reachWeight * Time.deltaTime);
        }

        if (leftArm != null)
        {
            Vector3 directionToPlayer = (player.position - leftArm.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            leftArm.rotation = Quaternion.Slerp(leftArm.rotation, targetRotation, reachWeight * Time.deltaTime);
        }
    }
}