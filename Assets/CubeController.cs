using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    // �������L���[�u�Փ˃{�����[���t���O
    private bool ColliderVolumeFlg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 
        GetComponent<AudioSource>().volume = this.ColliderVolumeFlg ? 1 : 0;

        if (ColliderVolumeFlg)
        {
            this.ColliderVolumeFlg = false;
        }

        // �L���[�u���ړ������遜��Transform�N���X��Translate�֐��́A�����ɗ^�����l�������݂̈ʒu����ړ��i�w�肵���l�̍��W�Ɉړ�����킯�ł͂Ȃ��j���������珇��X�������AY�������AZ�������̈ړ��������w��ł���
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.ColliderVolumeFlg = true;
        Debug.Log(this.ColliderVolumeFlg);
    }
}