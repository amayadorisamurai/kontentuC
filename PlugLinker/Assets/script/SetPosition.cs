using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{
    GameObject player;
    GameObject SearchArea;
    // 目的地に着いたかどうか
    private bool isReachTargetPosition;
    // 目的地
    private Vector3 targetPosition;

    // x軸 下限
    public const float X_MIN_MOVE_RANGE = -4f;
    // x軸 上限
    public const float X_MAX_MOVE_RANGE = 4f;
    // y軸 下限
    public const float Y_MIN_MOVE_RANGE = -2f;
    // y軸 上限
    public const float Y_MAX_MOVE_RANGE = 2f;
    // 移動スピード
    public const float SPEED = 0.03f;

    bool Chenge = true;
    
    void Start()
    {
        this.isReachTargetPosition = false;
        decideTargetPotision();
        // playerオブジェクトを取得
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        decideTargetPotision();
            // 現在地から目的地までSPEEDの速度で移動する
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED);
            // 目的地についたらisReachTargetPositionをtrueにする
            if (transform.position == targetPosition)
            {
                isReachTargetPosition = true;
            targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
        }
    }
    void OnTriggerStay(Collider col)
    {
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            if (!isReachTargetPosition)
            {
                Vector3 playerPos = this.player.transform.position;
                float ENEMY_MOVE_SPEED = 5f;
                // プレイヤーの方向に移動させる
                targetPosition = Vector3.MoveTowards(transform.position, playerPos, ENEMY_MOVE_SPEED);
                return;
            }
        }
    }

    // 目的地を設定する
    private void decideTargetPotision()
    {
        // まだ目的地についてなかったら（移動中なら）目的地を変えない
        //if (!isReachTargetPosition)
        //{
        //    return;
        //}
        // 目的地に着いていたら目的地を再設定する
        targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
        isReachTargetPosition = false;
    }
}