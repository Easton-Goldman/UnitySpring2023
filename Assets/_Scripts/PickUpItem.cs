using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    CoinHUD coinDisplay;

    private void Awake()
    {
        coinDisplay = GameObject.Find("Coin Display").GetComponent<CoinHUD>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        transform.Rotate(0, 0, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            coinDisplay.CoinCollected();
            Destroy(gameObject);
        }
    }
}
