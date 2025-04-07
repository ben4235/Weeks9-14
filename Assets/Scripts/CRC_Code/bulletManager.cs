using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public List<GameObject> bulletList = new List<GameObject>();

    public void addBullets(GameObject bullet)
    {
        bulletList.Add(bullet);
    }

    void Update()
    {
        for (int i = bulletList.Count - 1; i >= 0; i--)
        {
            if (bulletList[i] != null)
            {
                bulletList.RemoveAt(i);
            }
        }
    }
}
