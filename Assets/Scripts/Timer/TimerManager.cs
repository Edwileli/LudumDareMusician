using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timeGivenAtStart = 180f;//in seconds
    public float timeModifiers = 0f;
    public float timeThresholdForChangeColor = 60f;
    public Color normalColor = Color.black;
    public Color colorWhenThereTimeEnds = Color.red;

    private float timeRemaining = 0f;
    private float timeWhenTheGameBegins = 0f;
    private Text timerText = null;
    private TimerText timerTextScript = null;

    void Awake()
    {
        timerTextScript = FindObjectOfType<TimerText>();
        if (!timerTextScript)
        {
            Debug.Log("timerTextScript missing on " + gameObject.name);
        }
        timerText = timerTextScript.GetComponent<Text>();
        timeWhenTheGameBegins = Time.time;
        Debug.Log("timeWhenTheGameBegins " + timeWhenTheGameBegins);
    }

    public void AddTime(float timeToAdd)
    {
        timeModifiers += timeToAdd;
    }

    private void Update()
    {
        Debug.Log("Time.time " + Time.time);
        timeRemaining = timeWhenTheGameBegins + timeGivenAtStart + timeModifiers - Time.time;

        if (timeRemaining < 0)
        {
            Debug.Log("End");
            SceneManager.LoadScene("end_scene", LoadSceneMode.Single);
        }

        if (timeRemaining < timeThresholdForChangeColor)
        {
            timerText.color = colorWhenThereTimeEnds;
        }
        else
        {
            timerText.color = normalColor;
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60F);
        int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = niceTime;
    }
}
