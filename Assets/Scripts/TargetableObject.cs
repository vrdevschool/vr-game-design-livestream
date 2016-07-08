using UnityEngine;
using System.Collections;

public class TargetableObject : MonoBehaviour
{

    public int i_Health = 100;

    public bool b_isDead = false;

    public void TakeDamage(int damageAmount)
    {
        i_Health -= damageAmount;

        if (i_Health <= 0)
        {
            b_isDead = true;
        }
    }
}
