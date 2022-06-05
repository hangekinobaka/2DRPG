using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Animator anim;

    // For Face Idle Stae
    bool playerMoving = false;
    Vector2 lastMove = new Vector2(0,-1);

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horVal = Input.GetAxisRaw("Horizontal");
        float verVal = Input.GetAxisRaw("Vertical");

        playerMoving = false;

        // 大于零也可以，这里设了个0.5的缓冲
        if (Mathf.Abs(horVal) > .5f) // pressing left right
        {
            transform.Translate(
                Vector3.right * horVal * moveSpeed * Time.deltaTime
            );
            playerMoving = true;
            lastMove = new Vector2(horVal, 0);
        }
        if (Mathf.Abs(verVal) > .5f) // pressing up down
        {
            transform.Translate(
                Vector3.up * verVal * moveSpeed * Time.deltaTime
            );
            playerMoving = true;
            lastMove = new Vector2(0, verVal);
        }

        anim.SetFloat("MoveX", horVal);
        anim.SetFloat("MoveY", verVal);
        anim.SetBool("IsMoving", playerMoving);
        if (!playerMoving)
        {
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }
}