using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShot : MonoBehaviour
{
    public float rot_Speed;

    //총알이 발사될 위치
    public Transform pos;

    //발사될 총알 오브젝트
    public GameObject bullet;

    float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.Rotate(Vector3.forward * rot_Speed * 100 * Time.deltaTime);

        GameObject temp = Instantiate(bullet);

        temp.transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
        //2초후 자동 삭제

        //총알 생성 위치를 머즐 입구로 한다.
        temp.transform.position = transform.position;

        //총알의 방향을 오브젝트의 방향으로 한다.
        //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
        temp.transform.rotation = transform.rotation;

    }

    public void Spin()
    {

    }
}
