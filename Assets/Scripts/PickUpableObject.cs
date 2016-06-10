using UnityEngine;
using System.Collections;

public class PickUpableObject : MonoBehaviour
{
    public bool b_PickedUp = false;

    public float f_TimerEnd = 15f;
    public float f_CurrentTimer = 0f;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
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
