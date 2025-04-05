using System.Collections;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private IEnumerator coroutine;
    bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameActive = true;
        StartCoroutine(spawnEnemies(5));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnEnemies(float spawnTime)
    {
        while (gameActive == true)
        {
            Vector3 spawnPosition = spawnSpace();
            GameObject enemySpawn = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
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
}
