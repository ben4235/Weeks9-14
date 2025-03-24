using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeGymW10 : MonoBehaviour
{
    public GameObject sprite;
    public AnimationCurve sizeCurve;
    public float duration = 2f;
    private Vector3 startingScale;

    void Start()
    {
        startingScale = transform.localScale;
        print("Starting Coroutine");
        StartCoroutine(GrowAndShrink());

    }

    private IEnumerator grow()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float normalizedTime = elapsedTime / duration;
            float scaleMultiplier = sizeCurve.Evaluate(normalizedTime);
            transform.localScale = startingScale * scaleMultiplier;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator shrink()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {

            float normalizedTime = elapsedTime / duration;
            float scaleMultiplier = sizeCurve.Evaluate(1 - normalizedTime);
            transform.localScale = startingScale * scaleMultiplier;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator GrowAndShrink()
    {
        while (true) // Continuous loop of grow and shrink
        {
            yield return StartCoroutine(grow());
            yield return StartCoroutine(shrink());
        }
    }


}
