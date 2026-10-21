using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform player;
	public LayerMask whatIsGround, whatIsPlayer;
	public GameObject projectile;
	public GameObject playerObject;

	public float health = 100;

	//patrolling
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	//Attacking
	public float timeBetweenAttacks;
	bool alreadyAttacked;

	//States
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;

	private void Awake()
{
	if (agent == null) agent = GetComponentInParent<NavMeshAgent>();

	if (player == null && playerObject != null)
		player = playerObject.transform;

	if (agent == null || player == null)
	{
		Debug.LogError("EnemyAI on " + name + " is missing: " +
			(agent == null ? "NavMeshAgent " : "") +
			(player == null ? "Player" : ""), this);
		enabled = false;
	}
}

private void Update()
{
	playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
	playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

	if (!playerInSightRange && !playerInAttackRange) Patroling();
	if (playerInSightRange && !playerInAttackRange) ChasePlayer();
	if (playerInAttackRange && playerInSightRange) AttackPlayer();
}

	private void Patroling()
	{
		if(!walkPointSet) SearchWalkPoint();

		if(walkPointSet) 
			agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if(distanceToWalkPoint.magnitude < 1f)
			walkPointSet = false;
	}

	private void SearchWalkPoint()
	{
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);

		Vector3 randomPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    	if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, walkPointRange, NavMesh.AllAreas))
		{
        	walkPoint = hit.position;
        	walkPointSet = true;
    	}
	}

	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}

	private void AttackPlayer()
	{
		//Enemy not moving
		agent.SetDestination(transform.position);
		
		transform.LookAt(player);

		if(!alreadyAttacked)
		{
			//Attack Code
			Rigidbody rigid = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rigid.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rigid.AddForce(transform.up * 8f, ForceMode.Impulse);

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if(health <= 0) Invoke(nameof(DestroyEntity), .5f);
	}

	private void ResetAttack()
	{
		alreadyAttacked = false;
	}

	public void DestroyEntity()
	{
		Destroy(gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
}