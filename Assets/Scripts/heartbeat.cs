using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class heartbeat : MonoBehaviour
{
    public AnimationCurve myCurve;
    public float duration = 2f;       //length of curve
    private float elapsedTime = 0f;  //how long has passed

    float leftScreen;
    float rightScreen;
    float speed = 2f;

    void Start()
    {
        leftScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        Vector3 position = transform.position;
        if (position.x > rightScreen)
        {
            StartCoroutine(WaitForWrap());
            position.x = leftScreen;
        }

        //move the object left to right
        position += Vector3.right * speed * Time.deltaTime;

        //time.time is time since the start of the game - switched from time.deltatime which checks time since last frame render
        elapsedTime = Time.time;
        position.y = myCurve.Evaluate(elapsedTime);

        //apply the position change
        transform.position = position;
    }
    IEnumerator WaitForWrap()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        trail.emitting = false;

        yield return null;

        Vector3 pos = transform.position;
        pos.x = leftScreen; // wrap to left side of screen
        transform.position = pos;


        trail.emitting = true;
        trail.Clear();
        yield return new WaitForSeconds(0.01f);
    }
}