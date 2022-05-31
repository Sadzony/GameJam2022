using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{

    public List<int> List = new List<int>();

    int[] Array = new int[10];

    public int Score = 0;

    public int HighScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        Score = 0;

        HighScore = 0;
    }

    // Update is called once per frame
    void Update()
    {


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
