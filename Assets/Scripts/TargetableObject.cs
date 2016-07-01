using UnityEngine;
using System.Collections;

public class TargetableObject : MonoBehaviour
{

    public int i_Health = 100;

    public void TakeDamage(int damageAmount)
    {
        i_Health -= damageAmount;

        if (i_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
