﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム毎に等速落下
        transform.Translate(0, -0.1f, 0);

        //画面外に出たらオブジェクトを破棄
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //あたり判定
        Vector2 p1 = transform.position; //矢の中心座標
        Vector2 p2 = this.player.transform.position; //プレイヤーの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; //矢の半径
        float r2 = 1.0f; //プレイヤーの半径

        if (d < r1 + r2)
        {
            //監督スクリプトにプレイヤーと衝突したことを伝える
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();    

            // 衝突で矢を消す
            Destroy(gameObject);
        }

    }
}
