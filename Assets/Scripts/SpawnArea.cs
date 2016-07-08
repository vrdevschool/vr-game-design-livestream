using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnArea : MonoBehaviour
{

    public List<TargetableObject> l_TargetTowers;


    private PickUpableObject tempPickUpObject;
    void OnTriggerStay(Collider col)
    {
        tempPickUpObject = col.GetComponent<PickUpableObject>();

        if (tempPickUpObject)
        {
            tempPickUpObject.TargetObject(l_TargetTowers);
            tempPickUpObject.UpdateCurrentTarget();
        }
    }
}
