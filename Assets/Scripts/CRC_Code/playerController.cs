using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerSPD = 5.0f;
    public GameObject bulletPrefab;
    public Vector3 playerPosition;
    //Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position;

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(horizontalMovement, verticalMovement);


        playerPosition += (playerMovement * playerSPD * Time.deltaTime);
        transform.position = playerPosition;


        if (Input.GetMouseButtonDown(0))
        {
            fireBullet();
        }

    }

    public void fireBullet()
    {

        Vector3 playerPosition = transform.position;

        //this will convert the mouses position on the screen to a position within the world of the game
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        //this will instantiate the bullet on the position of the player
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        //this will be used to calculate the direction from PLAYER <---> MOUSE LOCATION when the mouse gets clicked
        Vector3 direction = (mousePos - playerPosition).normalized;

        Debug.Log(playerPosition);

        //finally, this will be used to send the information of the direction to the bullet script / direction class. 
        newBullet.GetComponent<bullet>().bulletDirection(direction);
    }    

}
