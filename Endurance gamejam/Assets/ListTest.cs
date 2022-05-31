using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListTest : MonoBehaviour
{

    public List<int> List = new List<int>();

    int[] Array = new int[10];

    public int Score = 0;

    public int HighScore = 0;

    [SerializeField] private ScoreController scoreControl;
    [SerializeField] private TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
       

        Score = 0;

        HighScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Score = scoreControl.score;
            scoreText.text = Score.ToString();
        }
        catch
        {
            Debug.Log("No score");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (Score >= HighScore)
            {


                    HighScore = Score;


                
                
            }

                    List.Add(Score);

                    List.Sort();

                    List.Reverse();

                    Array = List.ToArray();

                    Debug.Log("New Highest value is : " + Array[0]);

                    HighScore = Array[0];


            if (List.Count >= 10)
            {

                List.RemoveAt(10);

            }

            Score = 0;

        }


    }
}
