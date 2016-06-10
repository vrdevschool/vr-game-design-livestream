using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("SOMETHING IS IN THE TRIGGER");

        if ("Sphere".Equals(other.gameObject.tag))
        {
            scoreKeeper.UpdateScore(1);
        }
    }
}
