using UnityEngine;
using System.Collections;

public class ScaleObject : MonoBehaviour
{

    public Collider col_1;
    public Collider col_2;
    public GameObject go_Cube;


    // Use this for initialization
    void Start ()
    {
	     
	}
	
	// Update is called once per frame
	void Update ()
    {
        // We want the cube to position is self between the two colliders
        Vector3 position = (col_1.transform.position - col_2.transform.position) * 0.5f;

        go_Cube.transform.position = position + col_2.transform.position;
        go_Cube.transform.localScale = new Vector3(Vector3.Distance(col_1.transform.position, col_2.transform.position), go_Cube.transform.localScale.y, go_Cube.transform.localScale.z);

    }
}
