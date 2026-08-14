using UnityEngine;
using UnityEngine.AI;

// Requires: AI Navigation package installed + NavMesh baked on the floor.
// Add to an NPC (capsule or character model) together with a NavMeshAgent.
// Drag Point1–Point5 into the waypoints array.
public class NPCWalker : MonoBehaviour
{
    public Transform[] waypoints;
    public float waitTime = 2f;

    private NavMeshAgent agent;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1.2f, 2.0f); // each NPC walks differently
        GoToNextPoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                GoToNextPoint();
            }
        }
    }

    void GoToNextPoint()
    {
        if (waypoints.Length == 0) return;
        int i = Random.Range(0, waypoints.Length);
        agent.SetDestination(waypoints[i].position);
    }
}
