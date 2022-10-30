using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static bool IsPlaying { get; private set; }

    [SerializeField] GameObject _UI;

    private void Start()
    {
        IsPlaying = true;    
    }

    public void EndGame()
    {
        IsPlaying = false;
        _UI.SetActive(true);
    }

    public void ContinueGame()
    {
        IsPlaying = true;
        _UI.SetActive(false);
    }
}
