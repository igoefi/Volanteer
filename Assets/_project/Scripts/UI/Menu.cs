using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject panel;

    public void EnterMenu()
    {
        panel.SetActive(true);
    }
}
