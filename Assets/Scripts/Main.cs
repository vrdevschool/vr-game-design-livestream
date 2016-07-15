using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    public GameObject go_PlayerWins_UI;
    public GameObject go_EnemyWins_UI;

    public List<PickUpableObject> l_go_PlayerUnits;
    public List<PickUpableObject> l_go_EnemyUnits;

    public void PlayerWins()
    {
        EndGameState();

        go_PlayerWins_UI.gameObject.SetActive(true);
    }

    public void EnemyWins()
    {
        EndGameState();

        go_EnemyWins_UI.gameObject.SetActive(true);
    }

    public void EndGameState()
    {
        foreach(PickUpableObject unit in l_go_PlayerUnits)
        {
            unit.b_GameOverState = true;
        }

        foreach (PickUpableObject unit in l_go_EnemyUnits)
        {
            unit.b_GameOverState = true;
        }
    }
}
