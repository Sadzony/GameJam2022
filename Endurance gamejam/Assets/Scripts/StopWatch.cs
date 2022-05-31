using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{

    public float sec;

    public float min;

    public float startsec = 0;

    public float startmin = 0;

    public TMP_Text MinuteReader;

    public TMP_Text SecondReader;

    public TMP_Text scoreText;

    public int score;

    public bool running;

    public float Distance;

    [SerializeField] private ScoreController scoreMan;

    // Start is called before the first frame update
    void Start()
    {
        sec = startsec;
        min = startmin;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreMan.score;
        scoreText.text = score.ToString();

        MinuteReader.SetText(min.ToString("0"));

        SecondReader.SetText(sec.ToString("0"));

        if(running)
        {
            sec += Time.deltaTime;
        }

        if(sec >= 60)
        {
            AddMin();
            sec = 0;

        }

        
    }

    public void AddMin()
    {
        min += 1;
    }



}

