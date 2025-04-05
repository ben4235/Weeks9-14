using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSPD = 10f;
    private Vector3 bulletDir;

    public void bulletDirection(Vector3 direction)
    {
        bulletDir = direction.normalized;
    }

    private void Update()
    {
        transform.position += bulletDir * bulletSPD * Time.deltaTime;
    }
}
