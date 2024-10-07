using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=RQ61nY2WOtA
// tutorial kozmobot games

public class keyScript : MonoBehaviour
{

    public GameObject doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorCollider.SetActive(false);
            Destroy(gameObject);

        }
    }
}
