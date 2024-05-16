using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubesound : MonoBehaviour
{
    // キューブプレハブを指定
    public GameObject cubePrefab;

    void Start()
    {
        // キューブプレハブからインスタンスを生成
        GameObject cubeInstance = Instantiate(cubePrefab);

        // インスタンスにスクリプトをアタッチ
        cubeInstance.AddComponent<Cubesound>();
    }
}