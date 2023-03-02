using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int curHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        curHp = curHp - damage;
    }
}
