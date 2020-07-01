using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2 Speed = new Vector2(0.05f, 0.05f);

    // Update is called once per frame
    private void Update()
    {
        //移動
        Move();
    }

    //移動関数
    void Move()
    {

        // 現在位置をPositionに代入

        Vector2 Position = transform.position;

        // 左キーを押し続けていたら

        if (Input.GetKey("left"))
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= Speed.x;

        }
        else if (Input.GetKey("right"))  //右キーを押し続けていたら
        { 
            Position.x += Speed.x;
        }
        else if (Input.GetKey("up"))  //上キーを押し続けていたら
        { 
            Position.y += Speed.y;
        }
        else if (Input.GetKey("down"))  //下キーを押し続けていたら
        { 
            Position.y -= Speed.y;
        }

        // 現在の位置にPositionを代入する
        transform.position = Position;

    }
}
