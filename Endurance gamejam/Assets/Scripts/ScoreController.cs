using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private Vector3 startPosition;
    private GameObject player;

    public int deliveryScore;

    public int distanceScalar;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateScore();
    }

    private void CalculateScore()
    {
        Vector3 dist = player.transform.position - startPosition;
        score = (int)(dist.magnitude * distanceScalar);
    }

    public void NewspaperDelivered()
    {
        score += deliveryScore;
    }
}
