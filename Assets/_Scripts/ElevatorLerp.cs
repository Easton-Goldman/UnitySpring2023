using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLerp : MonoBehaviour
{
    public GameObject obj;
    public Transform startPos;
    public Transform endPos;

    [SerializeField]
    float lerpTime = 1f;
    public bool isActive;
    float crntLerpTime;

    // Start is called before the first frame update
    void Start()
    {
        crntLerpTime = lerpTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            crntLerpTime += Time.deltaTime;

            float percent = crntLerpTime / lerpTime;

            obj.transform.position = Vector3.Lerp(startPos.position, endPos.position, percent);
        }

        if (!isActive)
        {
            crntLerpTime += Time.deltaTime;

            float percent = crntLerpTime / lerpTime;

            obj.transform.position = Vector3.Lerp(endPos.position, startPos.position, percent);
        }
    }

    public void ActivateElivator()
    {
        isActive = !isActive;
        crntLerpTime = 0;
    }
}
