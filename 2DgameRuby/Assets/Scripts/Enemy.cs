using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�i���ʱ��� 1/3�j
    public int speed = 5;
    private Rigidbody2D rb; //�]�w�� private�A�קK�L�H�b�ݦ��M�׮ɡA���������󬰦�
    public bool isVertical;
    public int direction = 1; //�Ψӱ����V�ΡA�t�M�i����V�j

    //�i����V 1/4�j�ϥήɶ�����F����
    public float walkTime = 3;
    private float timer; //�]�p�@�ӭ˼ƭp�ɾ�

    //�i�ʵe�V�X�� 1/4�j
    public Animator enemyAnimator;

    //�i�ĤH�I��l�u�欰 1/3�j
    public bool broken = true; //��l�]�w���G�١A�ҥH��M�I�ʡA�|�è�(�ݭn����)

    //�i���������S�� 1/2�j�G�ϥ������S�ľ���
    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        //�i���ʱ��� 2/3�j�ϥέ��鲾�ʡA�C���Ұʪ�l���o����æs�� rb �����ܼƤ�
        rb = GetComponent<Rigidbody2D>();

        //�i����V 2/4�j�C���ҰʡAtimer ��o walkTime ���ɶ�
        timer = walkTime;

        //�i�ʵe�V�X�� 2/4�j
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�i�ĤH�I��l�u�欰 2/3�j
        if (!broken) //��ܨS���l�a�A�N�׵۳Q�צn�A�N��a���R�A���A����
        {
            return; // �w�צn�A���A���ʡC//������ return �ɡA�|���X�ثe���ҳB��k�A
                    // �p Update()�Areutrn �H�U���{���N���A����
        }

        //�i����V 3/4�j�˼ƭp��
        timer = timer - Time.deltaTime;

        //�i����V 4/4�j��p�ɾ��k�s�ɡA��V���ਫ
        if (timer <= 0)
        {
            direction = -direction;
            timer = walkTime; //�p�ɾ��A�ר��o�쥻�]�w���˼Ʈɶ��]�樫�ɶ��^
        }

        //�i���ʱ��� 3/3�j
        Vector2 enemyPosition = transform.position; //�N�ثe����Ҧb��m�ǵ� enemyPositon

        if (isVertical)
        {
            enemyPosition.y = enemyPosition.y + speed * Time.deltaTime * direction;
        }
        else
        {
            enemyPosition.x = enemyPosition.x + speed * Time.deltaTime * direction;
        }

        rb.MovePosition(enemyPosition);

        //�i�ʵe�V�X�� 4/4�j
        PlayMoveAnimation();

    }

    //�i�ʵe�V�X�� 3/4�j
    //�]�����s�ؤ�k�A�u���b�o�̨ϥΡA�ҥH�ϥ� private �Y�i
    private void PlayMoveAnimation()
    {
        if (isVertical) //�����b�V�ʵe�]�m
        {
            enemyAnimator.SetFloat("MoveX", 0);
            enemyAnimator.SetFloat("MoveY", direction);
        }
        else //�����b�V�ʵe�]�m
        {
            enemyAnimator.SetFloat("MoveX", direction);
            enemyAnimator.SetFloat("MoveY", 0);
        }
    }

    //�i�I�����a 1/1�j
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //RubyMove5 rubyMove5 = collision.gameObject.GetComponent<RubyMove5>();
        Ruby1123 gogogo_13 = collision.gameObject.GetComponent<Ruby1123>();
        if (gogogo_13 != null) //�ˬd�I�� Ruby
        {
            print("�I��ĤH�F�A����(-1)");
            gogogo_13.ChangeHealth(-1);
        }
    }

    //�i�ĤH�I��l�u�欰 3/3�j�G�����H�Q�״_����k
    public void Fix() //�@�w�o�� public �]���n���l�u���{���X�եγo�Ӥ�k
    {
        broken = false; //�����H�u�D�v�l�a
        rb.simulated = false; //���骺.simulated ��k�Y����(false)
                              //��ܤ��A�P���󪫥�i��I�������˴�

        //�i�ĤH�I��l�u�欰�j�ʵe����
        enemyAnimator.SetTrigger("Fixed");

        //�i���������S�� 2/2�j
        smokeEffect.Stop();
        //Destroy(smokeEffect); //���覡�]�i�H�A���ɤl�|���������A�S�� fu
    }
}

