using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameStates
    {
        NormalTrail,
        DownhillTrail
    }

    [Header("GameProperties")]
    public GameStates GS;
    public BikeAcceleration Playerspeed;
    private bool[] DoOnce = new bool [7];

    [Header("GameScores")]
    public int Score;
    public int PScore;
    public int HighScore;
    List<int> Scoreboard = new List<int>(); 
   

    [Header("UIProperties")]
    public GameObject DownhillUIText;
    public float TextDuration;
    public float TextDurationE;

    [Header("Downhill Properties")]
    public float DownhillTimer;
    public float DownhillTimerE;
    public float SpeedMultiplier;
    public bool DownhillTextUp;

    [Header("NormalTrail Properties")]
    public float MinDownhillWait;
    public float MaxDownhillWait;
    public float RandomNumber;
    public float DownhillWait;
    public float DownhillWaitE;
    public bool RandomNumChosen = false;
    public bool NormalTrailM = true;

    bool Downhill = false;

    void Start()
    {
        GS = GameStates.NormalTrail;
        RandomNumChosen = false;

        Score = 0;
        PScore = 0;
        HighScore = 0;
        
    }


    void Update()
    {

        #region TrailEnum Rules

        if(GS == GameStates.NormalTrail)
        {
            NormalTrail();
        }

        else if (GS == GameStates.DownhillTrail)
        {
            DownHill();
        }

        #endregion


        if(DownhillWait >= DownhillWaitE)
        {

            Debug.Log("End");
            GS = GameStates.DownhillTrail;

            DoOnce[0] = true;

        }

        if (DownhillTimer >= DownhillTimerE)
        {

            RandomNumber = 0;
            DownhillWaitE = 0;
            NormalTrailM = true;
            DownhillWait = 0;
            RandomNumChosen = false;

            GS = GameStates.NormalTrail;
        }

        ScoreSystem();


    }

    public void NormalTrail()
    {

            Debug.Log("NormalTrial");
        
            if (RandomNumChosen == false)
            {
                RandomNumber = Random.Range(MinDownhillWait, MaxDownhillWait);

                DownhillWaitE = RandomNumber;

                RandomNumChosen = true;
            }

            DownhillWait += Time.deltaTime;

        


    }

    public void DownHill()
    {
        if (GS == GameStates.DownhillTrail)
        {

            NormalTrailM = false;

            // Everything you want to do only once each time the function is called by the Update
            if (DoOnce[0] == true)
            {
                DownhillTextUp = true;

                if(DownhillTextUp)
                {
                    //timer counts up
                    TextDuration += Time.deltaTime; 
                    DownhillUIText.SetActive(true);
                }

                //if the timer ends
                if (TextDuration >= TextDurationE)
                {

                        DownhillUIText.SetActive(false);
                        DownhillTextUp = false;

                        

                }
            }

            DoOnce[0] = false;

            //decrease the speed by the same value

            DownhillTimer += Time.deltaTime;

        }

        
    }

    public void ScoreSystem()
    {
       


        //if the current score is bigger than the highest score
        if(Score >= HighScore)
        {

            Score = HighScore;
            
        
        }
    
        // when the game is done 
        //if(GameEnd == true)
        //{
        //    // the previous score will become the current score 
        //    PScore = Score;

        //    AddScoreBoard(); 
        //}

       
    }

    public void AddScoreBoard()
    {

        Scoreboard.Add(PScore);

        Scoreboard.Sort();

        
    }

}
