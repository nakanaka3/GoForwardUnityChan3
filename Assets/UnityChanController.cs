using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;
    //Unity�������ړ�������R���|�[�l���g������i�ǉ��j
    Rigidbody2D rigid2D;
    // �n�ʂ̈ʒu
    private float groundLevel = -3.0f;
    // �W�����v�̑��x�̌����i�ǉ��j
    private float dump = 0.8f;

    // �W�����v�̑��x�i�ǉ��j
    float jumpVelocity = 20;

    // �Q�[���I�[�o�[�ɂȂ�ʒu�i�ǉ��j
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();
        // Rigidbody2D�̃R���|�[�l���g���擾����i�ǉ��j
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame�����E�����ɑ���A�j���[�V�������Đ����邽�߁AHorizontal�����1�A���j�e�B����񂪒��n���Ă���ꍇ��isGround��true�ɐݒ肵�܂�
    void Update()
    {
        // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߁����E�����ɑ��邽�߁AAnimator�^�u�ɂ���Parameters�̒���Horizontal�����1�ɂ��Ă�
        this.animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ遜�����j�e�B����񂪒��n���Ă���ꍇ��Animator�^�u�ɂ���Parameters�̒���isGround��true�ɐݒ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���i�ǉ��j
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // ���n��ԂŃN���b�N���ꂽ�ꍇ�i�ǉ��j����(0)�͍��N���b�N�̂��ƁA
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // ������̗͂�������i�ǉ��j
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������i�ǉ��j
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���i�ǉ��j
        if (transform.position.x < this.deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������i�ǉ��j
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ���j�e�B������j������i�ǉ��j
            Destroy(gameObject);
        }
    }
}