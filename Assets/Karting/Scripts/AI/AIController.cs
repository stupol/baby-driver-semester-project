using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AIController : MonoBehaviour
{

    
    public GameObject[] targets;
    private UnityEngine.AI.NavMeshAgent agent;
    private int currentTargetIndex = 0;
    private bool waitToMove = true;
    private float waitTime = 3.0f;
    private float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(targets[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && targets[(currentTargetIndex + 1) % targets.Length] != null){
        if (waitToMove) {
            if (timer < waitTime){
                timer += Time.deltaTime;
            } else {
                waitToMove = false;
            }
        } else {
            
            SetNextDestination();
            }
        }
    }

    private void SetNextDestination()
{
    if (agent.remainingDistance <= agent.stoppingDistance && targets[0] == null)
    {
        currentTargetIndex++;

        if (currentTargetIndex >= targets.Length)
        {
            currentTargetIndex = 0;
        }

        agent.SetDestination(targets[currentTargetIndex].transform.position);
    }
}


    
}
