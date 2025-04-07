using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject enemy;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 bulletPosition = bullet.transform.position;
        Vector3 enemyPosition = enemy.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void bulletEnemyCollision()
    {

    }
}
