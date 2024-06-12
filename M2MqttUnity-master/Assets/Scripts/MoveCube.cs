using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class MoveCube : MonoBehaviour
{
    [SerializeField] Transform startingPos;
    [SerializeField] Transform endingPos;
    [SerializeField] GameObject _slider;
    float per;
    float time;
    [SerializeField] float duration = 1.0f; // Duration of the movement in seconds
    float elapsedTime = 0f; // Elapsed time since the movement started
    bool isAnimationActive;
    void Start()
    {
        _slider.gameObject.GetComponent<Slider>().onValueChanged.AddListener(AnimationSlider);
    }

    // Update is called once per frame
    void Update()
    {
        per = elapsedTime / duration;
        elapsedTime += Time.deltaTime;
        if (isAnimationActive)
        {
            gameObject.transform.position = Vector3.Lerp(startingPos.position, endingPos.position, per);
        }
           // Increment the elapsed time

        // Reset the elapsed time and repeat the movement if needed
        if (per >= 1.0f)
        {
            elapsedTime = 0f;
        }
    }
    public void StartAnimation()
    {
        isAnimationActive = !isAnimationActive; 
    }
    public void AnimationSlider(float curerrepos)
    {
        per = curerrepos / 1;
        gameObject.transform.position = Vector3.Lerp(startingPos.position, endingPos.position, per);
    }
}
