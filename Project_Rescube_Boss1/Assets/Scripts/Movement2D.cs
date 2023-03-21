using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;

    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //지속적으로 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self); 
    }

    //방향 지정해주는 함수, 다른 스크립트에서 쓸 수 있게 public으로 설정
    public void MoveTo(Vector3 direction)
    {

        moveDirection = direction;
    }
}
