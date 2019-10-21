using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.75f;

    NavMeshAgent myNavMeshAgent;
    Animator myAnimator;
    List<AnimatorControllerParameter> myAnimtorParameters = new List<AnimatorControllerParameter>();     
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        SetAnimator();
    }

    void SetAnimator()
    {
        myAnimator = GetComponent<Animator>();
        for (int index = 0; index < myAnimator.parameterCount; index++)
        {
            myAnimtorParameters.Add(myAnimator.GetParameter(index));
        }        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected       
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void EngageTarget()
    {
        if (distanceToTarget >= myNavMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        
        if (distanceToTarget <= myNavMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        SetAttackAnimation(false);
        myAnimator.SetTrigger(myAnimtorParameters[1].name);//Move
        myNavMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        SetAttackAnimation(true);
        //Debug.Log(name + " has seeked and is destroying " + target.name);
    }

    void SetAttackAnimation(bool setTo)
    {
        myAnimator.SetBool(myAnimtorParameters[2].name, setTo);
    }
}
