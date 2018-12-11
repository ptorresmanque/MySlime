using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int stab;
    private bool inmune;
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(stab == 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && !inmune)
        {
            stab -= 1;
            StartCoroutine(inmuneTime());
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
