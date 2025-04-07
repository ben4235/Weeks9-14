using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySPD = 1.5f;
    public GameObject playerObject;  // Instead of a public Transform

    void Update()
    {

            Vector3 direction = (playerObject.transform.position - transform.position).normalized;
            transform.position += direction * enemySPD * Time.deltaTime;
        
    }
}