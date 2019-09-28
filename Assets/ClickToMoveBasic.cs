using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class ClickToMoveBasic : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        agent.speed = 2;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                if (Vector3.Distance(hitInfo.point, agent.destination) < .5)
                {
                    if (anim.GetBool("run"))
                    {
                        anim.SetBool("run", false);
                        agent.speed = 2;
                    }
                    else
                    {
                        anim.SetBool("run", true);
                        agent.speed = 5;
                    }
                }
                else
                {
                    anim.SetBool("run", false);
                    agent.destination = hitInfo.point;
                    agent.speed = 2;
                }
            }
        }
    }
}