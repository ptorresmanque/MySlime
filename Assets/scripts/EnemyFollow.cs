using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    private Transform target;
    private bool left;
    private bool rigth;
    private bool top;
    private bool down;
    private Vector3 aux;
    private Animator anim;
    private AudioSource grasnidos;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        grasnidos = GetComponent<AudioSource>();
        StartCoroutine(grito());
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<Damage>().getInmuneState())
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        changeAnimate();
        
	}

    private void changeAnimate()
    {
        aux = target.position - transform.position;
        if (aux.y < 0 && aux.x < 0)
        {
            if (aux.y < aux.x)
            {
                top = false;
                left = false;
                rigth = false;
                down = true;
            } else if (aux.y > aux.x)
            {
                top = false;
                left = true;
                rigth = false;
                down = false;
            }
        } else if (aux.y > 0 && aux.x > 0)
        {
            if (aux.y < aux.x)
            {
                top = false;
                left = false;
                rigth = true;
                down = false;
            }
            else if (aux.y > aux.x)
            {
                top = true;
                left = false;
                rigth = false;
                down = false;
            }
        }else if (aux.y > 0 && aux.x < 0)
        {
            if (aux.y * -1 < aux.x)
            {
                top = true;
                left = false;
                rigth = false;
                down = false;
            }
            else if (aux.y * -1 > aux.x)
            {
                top = false;
                left = true;
                rigth = false;
                down = false;
            }
        }else if (aux.y < 0 && aux.x > 0)
        {
            if (aux.y < aux.x * -1)
            {
                top = false;
                left = false;
                rigth = false;
                down = true;
            }
            else if (aux.y > aux.x * -1)
            {
                top = false;
                left = false;
                rigth = true;
                down = false;
            }
        }
        anim.SetBool("left", left);
        anim.SetBool("rigth", rigth);
        anim.SetBool("top", top);
        anim.SetBool("down", down);
    }

    private IEnumerator grito()
    {
        while (true)
        {
            grasnidos.Play();
            yield return new WaitForSeconds(2f);
        }
        
    }
}
