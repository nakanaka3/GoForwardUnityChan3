using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubesound : MonoBehaviour
{
    // �L���[�u�v���n�u���w��
    public GameObject cubePrefab;

    void Start()
    {
        // �L���[�u�v���n�u����C���X�^���X�𐶐�
        GameObject cubeInstance = Instantiate(cubePrefab);

        // �C���X�^���X�ɃX�N���v�g���A�^�b�`
        cubeInstance.AddComponent<Cubesound>();
    }
}