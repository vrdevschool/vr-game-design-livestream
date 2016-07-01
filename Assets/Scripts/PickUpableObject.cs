using UnityEngine;
using System.Collections;

public class PickUpableObject : TargetableObject
{
    public int i_WeaponDamage = 1;
    public float f_WeaponCooldown = 3f;
    public float f_currentCoolDown = 0f;

    public bool b_PickedUp = false;

    public NavMeshAgent agent;

    public GameObject go_TargetLocation;

    public bool b_CanExpire = true;
    public float f_TimerEnd = 15f;
    public float f_CurrentTimer = 0f;

    // Use this for initialization
    void Start ()
    {
        
	}   
    
    public void Attack(TargetableObject target)
    {
        if (target != null)
        {
            target.TakeDamage(i_WeaponDamage);
        }
        else
        {
            Debug.Log("Attacking a target that does not have a TargetableObject Script");
        }
    }

    public void TargetObject(GameObject go_Target)
    {
        go_TargetLocation = go_Target;
        agent.destination = go_Target.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (b_PickedUp)
        {
            agent.Stop();
        }
        else
        {
            agent.Resume();
        }


        if (Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
        {

            f_currentCoolDown += Time.deltaTime;
            
            if (f_currentCoolDown > f_WeaponCooldown)
            {
                f_currentCoolDown = 0f;

                Debug.Log(go_TargetLocation);

                Attack(go_TargetLocation.GetComponent<TargetableObject>());
            }
        }
        else
        {
            f_currentCoolDown = 3f;
        }


        if (b_CanExpire)
        {
            if (b_PickedUp)
            {
                f_CurrentTimer = 0f;
            }
            else
            {
                f_CurrentTimer = f_CurrentTimer + Time.deltaTime;

                if (f_CurrentTimer >= f_TimerEnd)
                {
                    Destroy(gameObject);
                }
            }
        }
	}
}
