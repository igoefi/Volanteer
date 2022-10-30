using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Past : MonoBehaviour
{
    [SerializeField] Transform Begin;
    [SerializeField] Transform End;

    public Transform GetBeginPoint()
    {
        return Begin;
    }
    public Transform GetEndPoint()
    {
        return End;
    }
}
