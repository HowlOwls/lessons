using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        Destroy(gameObject,2f);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
