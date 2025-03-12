using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class codeGymPartOne : MonoBehaviour
{
    public RectTransform image;
    public GameObject prefabSpawn;
    public UnityEvent mouseClicked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            // Get mouse position in screen space
            Vector3 mouseScreenPos = Input.mousePosition;

            // Convert screen position to world position
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f)); // Adjust Z depth

            // Instantiate prefab at the calculated world position
            Instantiate(prefabSpawn, worldPos, Quaternion.identity);
        }
    }

    public void mouseJustEntered()
    {
        image.localScale = Vector3.one * 1.2f;
    }

    public void mouseJustLeft()
    {
        image.localScale = Vector3.one;
    }



}
