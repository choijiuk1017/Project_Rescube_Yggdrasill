using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasill : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;

    Animator anim;



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

        }
        else if(state == State.Attack)
        {

        }
        else if(state==State.Death)
        {

        }
    }

    private void UpdateIdle()
    {

    }

    private void UpdateAttack()
    {

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
                break;
            case 1:
            case 2:
                break;
            case 3:
            case 4:
                break;
        }
    }

    IEnumerator pattern1()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator pattern2()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator pattern3()
    {
        yield return new WaitForSeconds(2f);
    }

}
