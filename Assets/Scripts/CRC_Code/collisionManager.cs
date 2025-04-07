using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    private playerController playerController;
    public enemyManager enemy;

    public GameObject player;
    //public GameObject bullet;
    //public GameObject enemy;

    public float distanceSQR;
    float radius = 0.5f;
    Vector3 distance;

    public void Initialize(enemyManager enemyManagerReference)
    {
        enemy = enemyManagerReference;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.newBullet != null && bulletEnemyCollision(playerController.newBullet))
        {
            Destroy(playerController.newBullet);
            Destroy(enemy.enemyInstance);
            Debug.Log("Collision");
        }
    }

    public bool bulletEnemyCollision(GameObject bulletInstance)
    {
        Vector3 bulletPos = bulletInstance.transform.position;
        Vector3 enemyPos = enemy.enemyInstance.transform.position;

        float xDistance = bulletPos.x - enemyPos.x;
        float yDistance = bulletPos.y - enemyPos.y;

        float distanceSQR = (xDistance * xDistance) + (yDistance * yDistance);
        Debug.Log(distanceSQR);
        float addedRadius = radius + radius;

        return distanceSQR <= addedRadius * addedRadius;
    }
}
