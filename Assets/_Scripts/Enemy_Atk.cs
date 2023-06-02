using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Atk : MonoBehaviour
{
    public Transform atkTransform;
    [Range(0,2)]
    public float radius = 0f;

    public void AtkPlayer()
    {
        Collider[] hitCollider = Physics.OverlapSphere(atkTransform.position, radius);

        foreach(var player in hitCollider)
        {
            if(player.CompareTag("Player"))
            {
                player.gameObject.GetComponent<Player_Health>().TakeDMG(10.0f);
            }
        }
    }

    //visualize attack sphere
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkTransform.position, radius);
    }
}
