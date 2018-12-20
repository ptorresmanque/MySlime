using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int stab;
    private bool inmune;
    private Animator anim;
    GameStatus gameStatus;
    [SerializeField] GameObject sangre;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        gameStatus = FindObjectOfType<GameStatus>();
    }
	
	// Update is called once per frame
	void Update () {
		if(stab == 0)
        {
            Destroy(gameObject);
            gameStatus.AddScore();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && !inmune)
        {
            stab -= 1;
            StartCoroutine(inmuneTime());
            Instantiate(sangre, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator inmuneTime()
    {
        inmune = true;
        anim.enabled = false;
        yield return new WaitForSecondsRealtime(0.3f);
        inmune = false;
        anim.enabled = true;

    }

    public bool getInmuneState()
    {
        return inmune;
    }
}
