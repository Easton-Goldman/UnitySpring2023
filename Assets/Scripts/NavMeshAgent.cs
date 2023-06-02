using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Direction", agent.velocity.magnitude);
        agent.destination = target.transform.position;
     }
}
