using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBG : MonoBehaviour
{
    [Min(0)]
    [SerializeField] float _speed;

    private void Update()
    {
        transform.position -= new Vector3(_speed * Time.deltaTime, 0);
    }
}
