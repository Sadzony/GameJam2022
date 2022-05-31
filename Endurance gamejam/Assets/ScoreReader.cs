using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreReader : MonoBehaviour
{

    public TMP_Text Reader;
    public int Listindex;
    public bool[] Index = new bool[10];  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Index[0] == true)
        {


            Reader.SetText(ListTest.Array[0].ToString("0"));
        }

        if (Index[1] == true)
        {


            Reader.SetText(ListTest.Array[1].ToString("0"));
        }

        if (Index[2] == true)
        {


            Reader.SetText(ListTest.Array[2].ToString("0"));
        }

        if (Index[3] == true)
        {


            Reader.SetText(ListTest.Array[3].ToString("0"));
        }

        if (Index[4] == true)
        {


            Reader.SetText(ListTest.Array[4].ToString("0"));
        }

        if (Index[5] == true)
        {


            Reader.SetText(ListTest.Array[5].ToString("0"));
        }

        if (Index[6] == true)
        {


            Reader.SetText(ListTest.Array[6].ToString("0"));
        }

        if (Index[7] == true)
        {


            Reader.SetText(ListTest.Array[7].ToString("0"));
        }

        if (Index[8] == true)
        {


            Reader.SetText(ListTest.Array[8].ToString("0"));
        }

        if (Index[9] == true)
        {


            Reader.SetText(ListTest.Array[9].ToString("0"));
        }
    }
}
