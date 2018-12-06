using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;

    private Animator anim;

    private bool isMoving;
    private bool rigth;
    private bool left;
    private bool top;
    private bool down;
    private bool atack;
    private bool hurt;
    private bool dead;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigth = false;
        left = false;
        top = false; 
        down = false;
        hurt = false;
        dead = false;
    }
	
	// Update is called once per frame
	void Update () {
        isMoving = false;

        if (joystick.Horizontal > 0.5f || joystick.Horizontal < -0.5f)
        {
            if(joystick.Horizontal > 0)
            {
                rigth = true;
                left = false;
                down = false;
                top = false;
                enviarAnim();
            }
            else if(joystick.Horizontal < 0)
            {
                left = true;
                rigth = false;
                down = false;
                top = false;
                enviarAnim();
            }
            transform.Translate(new Vector3(joystick.Horizontal * moveSpeed * Time.deltaTime, 0f, 0f));
            isMoving = true;
        }

        if (joystick.Vertical > 0.5f || joystick.Vertical < -0.5f)
        {
            if (joystick.Vertical > 0)
            {
                top = true;
                down = false;
                rigth = false;
                left = false;
                enviarAnim();
            }
            else
            {
                down = true;
                top = false;
                rigth = false;
                left = false;
                enviarAnim();
            }
            transform.Translate(new Vector3(0f, joystick.Vertical * moveSpeed * Time.deltaTime, 0f));
            isMoving = true;
        }

        /*if (Input.GetButtonDown("Fire1"))
        {
            hurt = true;
            atack = false;
            enviarAnim();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            dead = true;
            enviarAnim();
        }*/

        enviarAnim();

    }

    public void InitAtack()
    {
        atack = true;
        rigth = false;
        left = false;
        top = false;
        down = false;
        hurt = false;
        enviarAnim();
    }

    void finishAtack()
    {
        atack = false;
    }

    void finishHurt()
    {
        hurt = false;
    }

    void dying()
    {
        dead = true;
    }

    private void enviarAnim()
    {
        anim.SetBool("atack", atack);
        anim.SetBool("movRigth", rigth);
        anim.SetBool("movLeft", left);
        anim.SetBool("movTop", top);
        anim.SetBool("movDown", down);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("hurt", hurt);
        anim.SetBool("dead", dead);
    }
}
