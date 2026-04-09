using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeanGuy : MonoBehaviour
{
    enum State { Patrol, Chase, Return }
    State state = State.Patrol;
    bool waiting = false;

    public bool stationary; 
    Quaternion originalRotation;    
    public float turnSpeed = 360f;
    private NavMeshAgent agent;
    private Vector3 startPosition;
    Vector3[] waypoints;
    int waypointIndex = 0;
    public float waitTime = .3f;
    public Transform pathHolder;
    

    Movement playerScript;

    //this is vision stuff
    public float viewDistance;
    public LayerMask viewMask;
    float viewAngle;

    private VisionCone visionCone;


    Color originalConeColor;

    Transform player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerScript = player.GetComponent<Movement>();
        
        
        originalRotation = transform.rotation;
        agent.updateRotation = true;


        visionCone = GetComponentInChildren<VisionCone>();

        viewAngle = visionCone.viewAngle;
        viewDistance = visionCone.viewDistance;
        originalConeColor = visionCone.GetComponent<MeshRenderer>().material.color;


        waypoints = new Vector3[pathHolder.childCount];

        
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        startPosition = transform.position;
        agent.SetDestination(waypoints[0]);
        
    }
    bool canSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > viewDistance)
            return false;

            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, dirToPlayer);
                if (angle > viewAngle / 2f)
                    return false;

                  if (Physics.Linecast(transform.position, player.position, out RaycastHit hit, viewMask))
                {
                    return hit.collider.CompareTag("Player");
                }  
                
        
        return false;
    }
    void Update()
    {
        switch (state)
    {
        case State.Patrol:
            PatrolUpdate();
            break;

        case State.Chase:
            ChaseUpdate();
            break;

        case State.Return:
            ReturnUpdate();
            break;
    }
        

    }
    void PatrolUpdate()
{
    visionCone.GetComponent<MeshRenderer>().material.color = originalConeColor;

    if (canSeePlayer())
    {
        state = State.Chase;
        waiting = false;
        return;
    }

    if (!waiting &&!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f)

    {
        StartCoroutine(GoToNextWaypoint());
    }
}
void ReturnUpdate()
{
    visionCone.GetComponent<MeshRenderer>().material.color = originalConeColor;

    if (canSeePlayer())
    {
        state = State.Chase;
        return;
    }

    if (!waiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f)
    {
        state = State.Patrol;
        agent.SetDestination(waypoints[waypointIndex]);
        if (stationary)
        StartCoroutine(ReturnToOriginalRotation());

    }
}

    
    void ChaseUpdate()
    {
        visionCone.GetComponent<MeshRenderer>().material.color = Color.red;

        if (!canSeePlayer())
        {
            state = State.Return;
            agent.SetDestination(startPosition);
            return;
        }
    float dist = Vector3.Distance(transform.position, player.position);
    if (dist < 1.0f) 
    {
         playerScript.Respawn();

        state = State.Return;
        agent.SetDestination(startPosition);
    return;
    }
        agent.SetDestination(player.position);
    }
IEnumerator GoToNextWaypoint()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);

        waypointIndex = (waypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[waypointIndex]);
        waiting = false;
    }    

    IEnumerator ReturnToOriginalRotation()
{
    while (Quaternion.Angle(transform.rotation, originalRotation) > 0.1f)
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            originalRotation,
            turnSpeed * Time.deltaTime
        );

        yield return null;
    }
}


    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach(Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }
    public void TurnAround()
{
    transform.Rotate(0f, 180f, 0f);
}
}

        


