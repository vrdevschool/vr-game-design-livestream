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
        if(b_isDead)
        {
            Destroy(slider_HealthBar.gameObject);
            Destroy(gameObject);
        }

        if (slider_HealthBar != null)
        {
            Debug.Log((float)i_Health / 100f);

            slider_HealthBar.value = (float)i_Health / 100f;

            if (b_HealthBarIsFacing)
            {
                slider_HealthBar.transform.LookAt(go_Camera.transform.position);
            }
        }
    }
}
