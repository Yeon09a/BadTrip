using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;

    // �÷��̾� Move
    [SerializeField] private Rigidbody2D pRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSP;
    private Vector2 moveVec2;
    
    // ��ȣ�ۿ�
    private RaycastHit2D hit;
    private Vector2 interPos; // ��ȣ�ۿ� ��ġ
    [SerializeField] private float rayLength = 10f;
    private GameObject scanObj;
    [SerializeField] private QuestManager questManager;

    // �߼Ҹ�
    [SerializeField] private AudioSource footstepAS;
    public AudioClip footstepClip;

    // �÷��̾� Move Control
    public bool canMove = false;

    public bool IsMoving
    {
        get
        {
            return moveVec2.x != 0 || moveVec2.y != 0;
        }
    }

    [Header("Property")]
    public float speed = 1.5f;

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveVec2.x = Input.GetAxis("Horizontal");
        moveVec2.y = Input.GetAxis("Vertical");
        if(moveVec2.y>0) interPos = Vector2.up;
        else if(moveVec2.y<0) interPos = Vector2.down;

        DrawRay();

        if (IsMoving)
        {
            playerAnimator.SetBool("IsWalking", true);
            //footstepAS.enabled = true;
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
            //footstepAS.enabled = false;
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, interPos * rayLength, Color.blue); // �ӽ� ���� ǥ��

        hit = Physics2D.Raycast(transform.position, interPos, rayLength, 1 << 9);
        if(hit.collider != null)
        {
            scanObj = hit.collider.gameObject;
            if(scanObj.CompareTag("Border"))
            {
                //moveVec2 = Vector2.zero; // ��� ray ���� ������ �÷��̾ �ȿ������� ��� �ּ�ó��
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(hit.collider.gameObject.CompareTag("Door"))
                {
                    MapInteractionObject mapInteractionObject = hit.collider.gameObject.GetComponent<MapInteractionObject>();
                    mapInteractionObject?.OnInteraction();
                    questManager.UpdateQuestState(mapInteractionObject?.interactionId);
                    gameObject.transform.position = hit.collider.gameObject.GetComponent<MoveToPos>().moveToPos.transform.position;

                } else if (hit.collider.gameObject.CompareTag("Interaction"))
                {
                    MapInteractionObject mapInteractionObject = hit.collider.gameObject.GetComponent<MapInteractionObject>();
                    mapInteractionObject?.OnInteraction();
                    questManager.UpdateQuestState(mapInteractionObject?.interactionId);
                }
            }
        }
        else
            scanObj = null;
    }
    // �̵�
    public void Move()
    {
        pRigidbody.velocity = moveVec2.normalized * speed * Time.deltaTime;
        if (moveVec2.x > 0) // ������
        {
            playerSP.flipX = true;
            interPos = Vector2.right;
        } else if (moveVec2.x < 0)// ����
        {
            playerSP.flipX = false;
            interPos = Vector2.left;
        }
    }

    // �ִϸ��̼�
    /*public void SetIsStudent()
    {
        isStudent = FungusManager.Instance.GlobalVariables.GetVariable("isStudent");
    }*/

    #region Animation
    public void SetAnimLayer(int num)
    {
        if (num == 0)
        {
            ActivateLayer(0);
        } else if (num == 1)
        {
            ActivateLayer(1);
        } else if (num == 2)
        {
            ActivateLayer(2);
        }
    }

    public void ActivateLayer(int layerIndex)
    {
        for (int i = 0; i < 3; i++)
        {
            playerAnimator.SetLayerWeight(i, 0);
        }

        playerAnimator.SetLayerWeight(layerIndex, 1);
        playerDataSO.animLayer = layerIndex;
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        playerAnimator.SetBool(boolName, b);
    }

    #endregion

    #region PlayerMoveControl
    public void SetCanMove(bool b)
    {
        canMove = b;
    }

    public void SetCanMoveInt(int i)
    {
        canMove = Convert.ToBoolean(i);
    }
    #endregion

    #region PlayerFootstepAudio

    public void SetFootstepVolume(float v)
    {
        footstepAS.volume = v;
    }

    public void PlayFootstepAudio()
    {
        footstepAS?.PlayOneShot(footstepClip);
    }
    #endregion

    public void SetPlayerPos(Vector2 pos)
    {
        gameObject.transform.position = pos;    
    }
}
