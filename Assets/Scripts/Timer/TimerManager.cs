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

    private bool timerHasBegan = false;
    private float timeRemaining = 0f;
    private float timeWhenTheGameBegins = 0f;
    private Text timerText = null;
    private TimerText timerTextScript = null;
    private TimerPanel timerPanel = null;

    void Awake()
    {
        timerTextScript = FindObjectOfType<TimerText>();
        if (!timerTextScript)
        {
            Debug.Log("timerTextScript missing on " + gameObject.name);
        }
        timerPanel = FindObjectOfType<TimerPanel>();
        if (!timerPanel)
        {
            Debug.Log("timerPanel missing on " + gameObject.name);
        }
        timerText = timerTextScript.GetComponent<Text>();
        timerPanel.gameObject.SetActive(false);//hiding timer before the game starts
    }

    private void Update()
    {
        if(timerHasBegan)
        {
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

    public void AddTime(float timeToAdd)
    {
        timeModifiers += timeToAdd;
    }

    //Called by begin button on Intro text
    public void BeginTimer()
    {
        //init timer
        timeWhenTheGameBegins = Time.time;
        Debug.Log("timeWhenTheGameBegins " + timeWhenTheGameBegins);
        timerHasBegan = true;

        //display timer
        timerPanel.gameObject.SetActive(true);
    }
}
