using UnityEngine;
using System.Collections;

public class TargetableObject : MonoBehaviour
{
    public Main main;

    public bool b_PlayerTower = false;

    public int i_MaxHealth = 100;
    public int i_Health = 100;

    public bool b_WinConditionTower = false;
    public bool b_isDead = false;

    public void TakeDamage(int damageAmount)
    {
        i_Health -= damageAmount;

        if (i_Health <= 0)
        {
            b_isDead = true;

            if(b_WinConditionTower) // is this tower a win condition tower?
            {
                if(b_PlayerTower) // is the win condition tower player controlled 
                {
                    main.PlayerWins();
                }
                else // or enemy controlled
                {
                    main.EnemyWins();
                }
            }
        }
    }
}
