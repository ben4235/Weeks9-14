using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeGymW10 : MonoBehaviour
{
    //public GameObject sprite;
    public AnimationCurve sizeCurve;
    public float duration = 2f;
    private Vector3 startingScale;
    public Button attackButton;

    void Start()
    {
        startingScale = transform.localScale;
        print("Starting Coroutine");
        attackButton.onClick.AddListener(buttonPressed);

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

    public void buttonPressed()
    {
        attackButton.interactable = false;
        StartCoroutine(GrowAndShrink());

    }

    private IEnumerator GrowAndShrink()
    {

            yield return StartCoroutine(grow());
            yield return StartCoroutine(shrink());
            yield return new WaitForSeconds(1);
            attackButton.interactable = true;
    }


}
