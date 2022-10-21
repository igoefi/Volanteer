using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    private void Event()
    {
        Debug.Log("EVENT!!!!!!!!!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput player = collision.GetComponent<PlayerInput>();
        if (player != null)
            player.LeftSwipeEvent.AddListener(Event);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInput player = collision.GetComponent<PlayerInput>();
        if (player != null)
            player.LeftSwipeEvent.RemoveListener(Event);
    }
}
