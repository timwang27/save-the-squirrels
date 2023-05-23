using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class NewMovement : MonoBehaviour
{
    [SerializeField] private float radius = 20;
    [SerializeField] private bool debug;
    NavMeshAgent agent;
    Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(nextPosition, transform.position) <= 1.5f)
        {
            nextPosition = getNewPoint(transform.position, radius);
            agent.SetDestination(nextPosition);
        }
    }

    private Vector3 getNewPoint(Vector3 startPoint, float pointRadius)
    {
        Vector3 Dir = Random.insideUnitSphere * pointRadius;
        Dir += startPoint;
        NavMeshHit Hit_;
        Vector3 Final_Pos = Vector3.zero;
        if (NavMesh.SamplePosition(Dir, out Hit_, pointRadius, 1))
        {
            Final_Pos = Hit_.position;
        }
        return Final_Pos;
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nextPosition);
        }
    }
}