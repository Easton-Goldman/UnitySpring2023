using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float yVelcocity;
    public bool doorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            float newPos = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelcocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
        }
    }
}
