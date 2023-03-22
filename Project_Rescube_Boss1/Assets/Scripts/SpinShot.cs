using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShot : MonoBehaviour
{
    public float rot_Speed;

    //�Ѿ��� �߻�� ��ġ
    public Transform pos;

    //�߻�� �Ѿ� ������Ʈ
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
        //2���� �ڵ� ����

        //�Ѿ� ���� ��ġ�� ���� �Ա��� �Ѵ�.
        temp.transform.position = transform.position;

        //�Ѿ��� ������ ������Ʈ�� �������� �Ѵ�.
        //->�ش� ������Ʈ�� ������Ʈ�� 360�� ȸ���ϰ� �����Ƿ�, Rotation�� ������ ��.
        temp.transform.rotation = transform.rotation;

    }

    public void Spin()
    {

    }
}
