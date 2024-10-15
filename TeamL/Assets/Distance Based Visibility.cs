using UnityEngine;
using System.Collections.Generic;

public class DistanceBasedVisibility : MonoBehaviour
{
    public Transform Player;              // プレイヤーのTransform
    public GameObject chiyodaCity;        // 親オブジェクト
    public float activationDistance = 10f; // オブジェクトが再表示される距離

    private Dictionary<Transform, bool> objectVisibility; // オブジェクトごとの表示フラグ

    void Start()
    {
        // オブジェクトごとの表示状態を管理するための辞書を初期化
        objectVisibility = new Dictionary<Transform, bool>();

        // スタート時にすべての子オブジェクトを非表示にし、辞書に登録
        foreach (Transform child in chiyodaCity.transform)
        {
            child.gameObject.SetActive(false);
            objectVisibility[child] = false; // 最初は全て非表示
        }

        Debug.Log("All child objects set inactive at start.");
    }

    void Update()
    {
        // 親オブジェクトの子を全てループで確認
        foreach (Transform child in chiyodaCity.transform)
        {
            // プレイヤーと各子オブジェクトとの距離を計算
            float distance = Vector3.Distance(Player.position, child.position);

            // デバッグログで距離を出力
            Debug.Log("Distance between Player and " + child.name + ": " + distance);

            // 距離が指定した値以下かつ、まだオブジェクトが表示されていない場合
            if (distance <= activationDistance && !objectVisibility[child])
            {
                // 子オブジェクトを表示
                child.gameObject.SetActive(true);

                // 再表示されたことをログで確認
                Debug.Log(child.name + " activated!");

                // オブジェクトごとのフラグをtrueにして、再度非表示にならないようにする
                objectVisibility[child] = true;
            }
        }
    }
}
