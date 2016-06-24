using UnityEngine;
using System.Collections;

public class SpawnArea : MonoBehaviour
{

    public GameObject go_TargetTower;


    private PickUpableObject tempPickUpObject;
    void OnTriggerStay(Collider col)
    {
        tempPickUpObject = col.GetComponent<PickUpableObject>();

        if (tempPickUpObject)
        {
            tempPickUpObject.agent.destination = go_TargetTower.transform.position;
        }
    }
}
