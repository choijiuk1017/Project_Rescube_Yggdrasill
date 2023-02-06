using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasill : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;

    Animator anim;

    private bool isDelay;


    enum State
    {
        Idle,
        Attack,
        Death
    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;

        anim = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player");

        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Idle)
        {
            UpdateIdle();
        }
        else if(state == State.Attack)
        {
            UpdateAttack();
        }
        else if(state==State.Death)
        {
            UpdateDeath();
        }
    }

    private void UpdateIdle()
    {
        if(player != null)
        {
            state = State.Attack;
        }
        else
        {
            state = State.Idle;
        }
    }

    private void UpdateAttack()
    {
        StartCoroutine(Think());

        if(player == null)
        {
            state = State.Idle;
        }
    }

    private void UpdateDeath()
    {

    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(3f);

        int ranAction = Random.Range(0, 5);

        switch (ranAction)
        {
            case 0:
                if(isDelay == false)
                {
                    isDelay = true;
                    StartCoroutine(Pattern1());
                }
                break;


            case 1:
                break;

            case 2:
                if (isDelay == false)
                {
                    isDelay = true;
                    StartCoroutine(Pattern2());
                }
                break;

            case 3:
                break;

            case 4:
                if (isDelay == false)
                {
                    isDelay = true;
                    StartCoroutine(Pattern3());
                }
                break;
        }
    }

    IEnumerator Pattern1()
    {
        yield return new WaitForSeconds(6f);

        Debug.Log("Pattern1");

        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern2()
    {
        yield return new WaitForSeconds(5f);

        Debug.Log("Pattern2");


        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern3()
    {
        yield return new WaitForSeconds(4f);

        Debug.Log("Pattern3");


        isDelay = false;
        StartCoroutine(Think());
    }

}
