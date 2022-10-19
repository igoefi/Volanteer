using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLetChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeadLet let = collision.gameObject.GetComponent<DeadLet>();
        if (let != null)
        {
            Debug.Log("dead");
        }
    }
}
