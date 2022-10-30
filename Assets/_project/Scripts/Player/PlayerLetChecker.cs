using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLetChecker : MonoBehaviour
{
    [SerializeField] GameStateController _gameController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameStateController.IsPlaying) return;

        DeadLet let = collision.gameObject.GetComponent<DeadLet>();
        if (let != null)
        {
            Debug.Log("dead");
            _gameController.EndGame();
        }
    }
}
