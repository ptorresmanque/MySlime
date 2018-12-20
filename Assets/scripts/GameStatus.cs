using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI pajarosText;
    [SerializeField] TextMeshProUGUI scoreTextF;
    [SerializeField] TextMeshProUGUI pajarosTextF;
    [SerializeField] Move ninja;
    [SerializeField] int currentScore = 100;
    [SerializeField] int pointsPerPajarraco;
    [SerializeField] int pointsPerDamege;
    [SerializeField] GameObject finishUI;
    [SerializeField] GameObject normalUI;

    private float timeBtwReduce;
    public float startTimeBtwReduceLife;
    private int pajarracos = 0;
    private bool ciclo = true;
    


    // Use this for initialization
    void Start () {
        scoreText.text = currentScore.ToString();
        pajarosText.text = pajarracos.ToString();
        ninja = FindObjectOfType<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentScore <= 0 && ciclo)
        {
            ninja.dying();
            normalUI.SetActive(false);
            scoreTextF.text = currentScore.ToString();
            pajarosTextF.text = pajarracos.ToString();
            finishUI.SetActive(true);
            ciclo = false;
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

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
