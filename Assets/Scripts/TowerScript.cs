using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TowerScript : TargetableObject
{
    public bool b_HealthBarIsFacing = false;
    public GameObject go_Camera;
    public Slider slider_HealthBar;

    

    void Update()
    {
        if (slider_HealthBar != null)
        {
            slider_HealthBar.value = i_Health / 100;

            if (b_HealthBarIsFacing)
            {
                slider_HealthBar.transform.LookAt(go_Camera.transform);
            }
        }
    }
	
}
