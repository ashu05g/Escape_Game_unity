using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public bool playerInSight;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer, obstacleLayer;

    // Patrol properties
    public Transform[] waypoints;
    private int waypointIndex;

    // Vision and chasing properties
    public float visionAngle = 60f;
    public float sightRange=5, attackRange=1, sightRunAwayRange=10;
    public bool isChasing = false;

    // Attacking properties
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    // Animator properties
    public Animator animator;
    public GameOver gameOver;

    // Vision Cone Visualization
    public MeshRenderer visionConeRenderer;
    public Material alertMaterial;
    private Material defaultMaterial;

    private AudioSource audioSource;
    public float hearingDistance = 10.0f;
    public float delayBetweenPlays = 3.0f; // Delay in seconds between plays

    private bool isAudioScheduled = false;
    public AudioClip partolVoice, AttackVoice, chaseVaoice;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        waypointIndex = 0; // Start at the first waypoint
        defaultMaterial = visionConeRenderer.material; // Save the default material
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        bool playerInSight = CheckPlayerVisibility();
        UpdateVisionCone(playerInSight);

        if (playerInSight && Vector3.Distance(player.position, transform.position) <= sightRunAwayRange)
        {
            GetVoice(player, chaseVaoice);
            ChasePlayer();
        }
        else if (Vector3.Distance(player.position, transform.position) > sightRunAwayRange)
        {
            isChasing = false;
        }

        if (!isChasing)
        {
            GetVoice(player, partolVoice);
            Patrol();
        }

        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            GetVoice(player, AttackVoice, 1, 2);
            AttackPlayer();
        }
    }


    private void Patrol()
    {
        if (waypoints.Length == 0) return;
        if (agent.destination != waypoints[waypointIndex].position)
        {
            agent.SetDestination(waypoints[waypointIndex].position);
            animator.SetFloat("Speed", 0.8f); // Set patrol speed
        }

        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    private void ChasePlayer()
    {
        isChasing = true;
        agent.SetDestination(player.position);
        animator.SetFloat("Speed", 1.5f); // Set chase speed
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position); // Ensure the zombie stops moving before attacking
        animator.SetBool("IsAttack", true); // Trigger attack animation
        if (!alreadyAttacked)
        {
            Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the center of the screen
            Cursor.visible = true; // Hide the cursor
            gameOver.Setup();
            alreadyAttacked = true;
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("IsAttacK", false); // End attack animation
    }

    private bool CheckPlayerVisibility()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < visionAngle / 2f)
        {
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, sightRange, playerLayer))
            {
                Debug.Log("Hit: " + hit.collider.name); // For debugging
                if (hit.collider.transform == player)
                {
                    Debug.Log("Player in sight!"); // For debugging
                    return true;
                }
            }
        }
        return false;
    }

    private void UpdateVisionCone(bool playerInSight)
    {
        if (playerInSight)
        {
            visionConeRenderer.material = alertMaterial; // Change color to alert material
        }
        else
        {
            visionConeRenderer.material = defaultMaterial; // Revert to default material
        }
    }

    private void GetVoice(Transform player, AudioClip audioClip, float delayBetweenPlays = 3, float hearingDistance=7)
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= hearingDistance)
        {
            if (!audioSource.isPlaying && !isAudioScheduled)
            {
                audioSource.Play();
                isAudioScheduled = true;
                Invoke("ResetAudioScheduled", audioSource.clip.length + delayBetweenPlays);
            }
            audioSource.volume = 1 - (distance / hearingDistance); // Increase volume as player gets closer
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            CancelInvoke("ResetAudioScheduled");
            isAudioScheduled = false;
        }
    }

    void ResetAudioScheduled()
    {
        isAudioScheduled = false;
    }
}
