using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;

    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();


        //give time for think() so cpu doesnt collapse
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2 (nextMove, rigid.velocity.y);
    }


    //recursion method
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 5);
    }
}

