using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 8.75f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent myNavMeshAgent;
    Animator myAnimator;
    List<AnimatorControllerParameter> myAnimtorParameters = new List<AnimatorControllerParameter>();     
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        SetAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: fine what more performance effective.
        if (isDead) { return; /*OR this.enabled = false;*/ }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        //for next time make it more readable. it cool to use BroadcastMessage, but use it smart.
        else if (distanceToTarget <= chaseRange)//OR OnDamageTaken
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

    #region Animator Methods

    void SetAnimator()
    {
        myAnimator = GetComponent<Animator>();
        for (int index = 0; index < myAnimator.parameterCount; index++)
        {
            myAnimtorParameters.Add(myAnimator.GetParameter(index));
        }        
    }

    void SetAttackAnimation(bool setTo)
    {
        myAnimator.SetBool(myAnimtorParameters[2].name, setTo);
    }

    void PlayDeathAnimation()
    {
        myAnimator.SetTrigger(myAnimtorParameters[3].name);
    }

    #endregion

    #region Evens

    void OnDamageTaken()
    {
        isProvoked = true;
    }

    void OnDeath()
    {
        if (isDead) return;
        isDead = true;
        PlayDeathAnimation();
        myNavMeshAgent.enabled = false;
    }

    #endregion

    #region Engage Target Methods

    void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= myNavMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        
        if (distanceToTarget <= myNavMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
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

    #endregion

}
