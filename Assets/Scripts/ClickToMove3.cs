using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove3 : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;
    private UnityEngine.AI.NavMeshObstacle obstacle;
    private bool selected;
    private bool move;
    private Vector3 MoveTo;
    public Transform goal;
    public Transform agent1;
    public Transform agent2;
    public Transform agent3;
    public Transform agent4;
    public Transform agent5;
    public Transform agent6;
    public Transform agent7;
    public Transform agent8;
    public Transform agent9;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        selected = false;
        move = true;
        agent.destination = goal.position;

        obstacle.enabled = false;
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Pow(agent.stoppingDistance, 2);

        if (selected && move)
        {
            obstacle.enabled = false;
            agent.enabled = true;
            agent.destination = MoveTo;
            agent.isStopped = false;
        }

        else if (((agent1.position - transform.position).sqrMagnitude < dist) ||
            ((agent2.position - transform.position).sqrMagnitude < dist) ||
            ((agent3.position - transform.position).sqrMagnitude < dist) ||
            ((agent4.position - transform.position).sqrMagnitude < dist) ||
            ((agent5.position - transform.position).sqrMagnitude < dist) ||
            ((agent6.position - transform.position).sqrMagnitude < dist) ||
            ((agent7.position - transform.position).sqrMagnitude < dist) ||
            ((agent8.position - transform.position).sqrMagnitude < dist) ||
            ((agent9.position - transform.position).sqrMagnitude < dist))
        {
            agent.enabled = false;
            obstacle.enabled = true;
        }
        else
        {
            obstacle.enabled = false;
            agent.enabled = true;
        }

    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }

    public void Destination(Vector3 d)
    {
        MoveTo = d;
        move = true;
    }
}
