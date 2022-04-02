using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMineEnemy : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
