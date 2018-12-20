using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI pajarosText;
    [SerializeField] Move ninja;
    [SerializeField] int currentScore = 100;
    [SerializeField] int pointsPerPajarraco;
    [SerializeField] int pointsPerDamege;

    private float timeBtwReduce;
    public float startTimeBtwReduceLife;
    private int pajarracos = 0;
    


    // Use this for initialization
    void Start () {
        scoreText.text = currentScore.ToString();
        pajarosText.text = pajarracos.ToString();
        ninja = FindObjectOfType<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentScore <= 0)
        {
            ninja.dying();
        }else if (timeBtwReduce <= 0)
        {
            timeBtwReduce = startTimeBtwReduceLife;
            currentScore -= 1;
            scoreText.text = currentScore.ToString();
        }
        else
        {
            timeBtwReduce -= Time.deltaTime;
        }
	}

    public void AddScore()
    {
        currentScore += pointsPerPajarraco;
        scoreText.text = currentScore.ToString();
        pajarracos++;
        pajarosText.text = pajarracos.ToString();
    }

    public void DecreaseScore()
    {
        currentScore -= pointsPerDamege;
        scoreText.text = currentScore.ToString();
    }
}
