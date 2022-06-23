using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        //ball = GameObject.FindGameObjectWithTag("Ball").transform;
        //ball = GameObject.FindGameObjectWithTag<Singleton>();
        ball = Singleton.Instance.ballInstance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            CanvasManager.numberOfPassedRings++;
            CanvasManager.score += 10;
            if (gameObject.tag == "Trigger")
            {
                Destroy(transform.parent.gameObject,2);
            }    
        }
    }
}
