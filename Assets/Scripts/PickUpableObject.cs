using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpableObject : TargetableObject
{

    public GameObject go_TempPosition;
    public int i_WeaponDamage = 1;
    public float f_WeaponCooldown = 3f;
    public float f_currentCoolDown = 0f;

    public bool b_PickedUp = false;

    public NavMeshAgent agent;

    public GameObject go_TargetLocation;

    public bool b_CanExpire = true;
    public float f_TimerEnd = 15f;
    public float f_CurrentTimer = 0f;

    public List<TargetableObject> l_Targets;

    public bool b_GameOverState = false;

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

    public void TargetObject(List<TargetableObject> l_TowerTargets)
    {
        l_Targets = l_TowerTargets;

        go_TargetLocation = l_Targets[l_Targets.Count - 1].gameObject;
    }

    public void UpdateCurrentTarget()
    {
        
        if(l_Targets[l_Targets.Count - 1] == null)
        {
            Debug.Log("Remove item in list");
            l_Targets.RemoveAt(l_Targets.Count - 1);
        }

        float tempTargetRadius = -l_Targets[l_Targets.Count - 1].transform.lossyScale.x * 0.5f;

        Vector3 tempDistanceVector = l_Targets[l_Targets.Count - 1].transform.position - transform.position;
        tempDistanceVector /= Vector3.Distance(transform.position, l_Targets[l_Targets.Count - 1].transform.position);

        tempDistanceVector *= tempTargetRadius;

        agent.SetDestination(l_Targets[l_Targets.Count - 1].transform.position + tempDistanceVector);
        go_TargetLocation = l_Targets[l_Targets.Count - 1].gameObject;
    }

    // Update is called once per frame
    void Update ()
    {
        if (b_GameOverState)
        {

            if (b_PickedUp)
            {
                agent.Stop();
            }
            else
            {
                agent.Resume();
            }


            //Debug.Log(Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance);

            if (Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
            {

                f_currentCoolDown += Time.deltaTime;

                if (f_currentCoolDown > f_WeaponCooldown)
                {
                    f_currentCoolDown = 0f;

                    // Debug.Log(go_TargetLocation);

                    if (l_Targets[l_Targets.Count - 1] == null)
                    {
                        l_Targets.RemoveAt(l_Targets.Count - 1);
                        go_TargetLocation = l_Targets[l_Targets.Count - 1].gameObject;
                        UpdateCurrentTarget();
                    }

                    if (go_TargetLocation != null)
                    {
                        Attack(go_TargetLocation.GetComponent<TargetableObject>());
                    }
                    else // If we dont have a target what do we do?
                    {
                        UpdateCurrentTarget();
                        Debug.Log("Yo your target is not there dude");
                    }
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

            if (!go_TargetLocation)
            {
                UpdateCurrentTarget();
            }
        }
    }
}
