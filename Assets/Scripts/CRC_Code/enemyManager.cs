using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    //public GameObject playerObject;
    public GameObject enemyPrefab;
    public GameObject playerObject;
    GameObject spawnedEnemy;
    public GameObject enemyInstance;

    private Vector3 enemyDir;
    float enemySPD = 1.5f;

    bool gameActive;
    //bool enemyAlive = true;



    public List<GameObject> enemyList = new List<GameObject>();

    public void addEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameActive = true;
        StartCoroutine(spawnEnemies(5));
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemy != null)
        {
            enemyMovement();
        }



    }

    IEnumerator spawnEnemies(float spawnTime)
    {
        while (gameActive)
        {
            Vector3 spawnPosition = spawnSpace();
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyManager.addEnemy(enemy);

            // Get the EnemyMovement component from the spawned enemy
            EnemyMovement movementScript = enemyInstance.GetComponent<EnemyMovement>();

            // Set the playerObject field from your manager (which is a scene object)
            movementScript.playerObject = playerObject;

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector3 spawnSpace()
    {
        int randomX = Random.Range(-10, 10);
        int randomY = Random.Range(-5, 5);

        Vector3 spawnA = new Vector3(-12, randomY, 0);
        Vector3 spawnB = new Vector3(randomX, 7, 0);
        Vector3 spawnC = new Vector3(12, randomY, 0);
        Vector3 spawnD = new Vector3(randomX, -7, 0);

        int randomSpawn = Random.Range(0, 4);

        if (randomSpawn == 0)
        {
            return spawnA;
        }
        else if (randomSpawn == 1)
        {
            return spawnB;
        }
        else if (randomSpawn == 2)
        {
            return spawnC;
        }
        else if (randomSpawn == 3)
        {
            return spawnD;
        }

        return spawnA;
    }

    public void enemyMovement()
    {

        Vector3 playerPosition = playerObject.transform.position;
        Vector3 spawnLoc = spawnedEnemy.transform.position;

        //this will be used to calculate the direction from PLAYER <---> ENEMY LOCATION when the mouse gets clicked
        Vector3 enemyDir = (playerPosition - spawnLoc).normalized;

        Vector3 moveEnemy = enemyDir * enemySPD * Time.deltaTime;

        spawnedEnemy.transform.position += moveEnemy;

    }

}
