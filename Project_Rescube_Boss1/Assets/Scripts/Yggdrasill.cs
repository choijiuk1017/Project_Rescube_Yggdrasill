using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasill : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;

    Animator anim;

    public BoxCollider2D attack1Range;

    public GameObject attack1;


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

    Vector3 Attack1_RandomPosition()
    {
        Vector3 originPosition = attack1Range.transform.position;

        float rangeX = attack1Range.bounds.size.x;
        float rangeY = attack1Range.bounds.size.y;

        rangeX = Random.Range((rangeX/2)*-1, rangeX / 2);
        rangeY = Random.Range((rangeY/2)*-1, rangeY / 2);

        Vector3 randomPosition = new (rangeX, rangeY, 0);

        Vector3 spawnPosition = originPosition + randomPosition;

        return spawnPosition;
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
        anim.SetTrigger("Attack1");
        yield return new WaitForSeconds(3f);

        anim.ResetTrigger("Attack1");
        for (int i = 0; i < 15; i++)
        {
            Instantiate(attack1, Attack1_RandomPosition(), Quaternion.identity);
        }

        Debug.Log("Pattern1");

        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern2()
    {
        anim.SetTrigger("Attack2");
        yield return new WaitForSeconds(2f);
        anim.ResetTrigger("Attack2");

        Debug.Log("Pattern2");


        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern3()
    {
        anim.SetTrigger("Attack3");
        yield return new WaitForSeconds(3f);
        anim.ResetTrigger("Attack3");

        Debug.Log("Pattern3");


        isDelay = false;
        StartCoroutine(Think());
    }

}
