using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListTest : MonoBehaviour
{

    public static  List<int> List = new List<int>();

    public static int[] Array = new int[10];

    public int Score = 0;

    static public int HighScore = 0;

    [SerializeField] private ScoreController scoreControl;
    [SerializeField] private TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
       

        Score = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        Score = scoreControl.score;
        scoreText.text = Score.ToString();

    }


    public void CalculateOrder()
    {


        HighScore = Score;
        
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
