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
    public GameObject attack2;
    public GameObject attack3;


    private bool isDelay;

    //보스의 상태를 나타내주는 구조체
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
        //각 상태에 알맞은 함수 호출
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

    //보스 기본 상태 관련 함수
    private void UpdateIdle()
    {
        //플레이어가 감지될 때에만 공격 모션을 취하도록 함
        if(player != null)
        {
            state = State.Attack;
        }
        else
        {
            state = State.Idle;
        }
    }

    //보스 공격 상태 관련 함수
    private void UpdateAttack()
    {
        StartCoroutine(Think());

        if(player == null)
        {
            state = State.Idle;
        }
    }

    //보스 사망 상태 관련 함수
    private void UpdateDeath()
    {

    }


    //랜덤 위치를 생성해 주는 함수
    Vector3 Attack_RandomPosition()
    {
        //콜라이더로 설정해둔 공격 범위의 기본 위치를 받아옴
        Vector3 originPosition = attack1Range.transform.position;

        //콜라이더의 사이즈를 저장
        float rangeX = attack1Range.bounds.size.x;
        float rangeY = attack1Range.bounds.size.y;

        //사이즈 내의 x,y 좌표를 랜덤 생성
        rangeX = Random.Range((rangeX/2)*-1, rangeX / 2);
        rangeY = Random.Range((rangeY/2)*-1, rangeY / 2);

        //랜덤 좌표 받아옴
        Vector3 randomPosition = new (rangeX, rangeY, 0);

        //랜덤 좌표를 기본 위치의 좌표에 더함
        Vector3 spawnPosition = originPosition + randomPosition;

        return spawnPosition;
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(3f);

        //랜덤 숫자 생성
        int ranAction = Random.Range(0, 5);

        //생성된 난수에 따라 패턴 결정
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
        yield return new WaitForSeconds(0.5f);

        anim.ResetTrigger("Attack1");
        for (int i = 0; i < 30; i++)
        {
            Instantiate(attack1, Attack_RandomPosition(), Quaternion.identity);
        }

        Debug.Log("Pattern1");

        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern2()
    {
        anim.SetTrigger("Attack2");
        yield return new WaitForSeconds(0.2f);
        anim.ResetTrigger("Attack2");

        for(int i = 0; i < 15; i++)
        {
            GameObject clone = Instantiate(attack3, Attack_RandomPosition(), Quaternion.identity);
        }
       
        Debug.Log("Pattern2");




        isDelay = false;
        StartCoroutine(Think());
    }

    IEnumerator Pattern3()
    {
        anim.SetTrigger("Attack3");

        yield return new WaitForSeconds(1f);

        anim.ResetTrigger("Attack3");

        int count = 30;

        float intervalAngle = 360 / count;

        float weightAngle = 0;

        int randomNum = Random.Range(0, 3);

        if (randomNum == 0)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(attack2, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }
        }
        else if (randomNum == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject clone = Instantiate(attack2, transform.position, Quaternion.identity);

                Vector3 direction = (player.transform.position - clone.transform.position).normalized;

                clone.GetComponent<Movement2D>().MoveTo(direction);
            }

        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(attack2, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 90.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 90.0f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x,y));
            }
        }


            //weightAngle += 1;


            //Debug.Log("Pattern3");


            isDelay = false;
        
        StartCoroutine(Think());
    }

}
