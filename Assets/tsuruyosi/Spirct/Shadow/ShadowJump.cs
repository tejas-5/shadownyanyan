using UnityEngine;

public class ShadowJump : MonoBehaviour
{
    [SerializeField] ShadowSwitch shadowSwitch;
    [SerializeField] GameObject groundCheckPos;
    [SerializeField] float fallMultiplier; //落ちるときの速度の乗数
    [SerializeField] float jumpMultiplier; //ジャンプして上がるときの速度の乗数
    [SerializeField] float jumpForce; //ジャンプの力
    [SerializeField] float jumpTime; //ジャンプしていられる時間
    [SerializeField] float checkRadius; //地面接地の取得範囲
    public LayerMask Ground;

    Vector2 vecGavity;
    Rigidbody2D rb;

    float jumpCounter;

    bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vecGavity = new Vector2(0, -Physics2D.gravity.y);
    }

    void Update()
    {
        if (shadowSwitch.b_move == true)
        {
            JumpHandler();
        }

        //キャラクターの落ちる速度を徐々に増加させる
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity -= vecGavity * fallMultiplier * Time.deltaTime;
        }

        //ボタンを押した時間によってジャンプの高さが変わるようにする
        if (rb.linearVelocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;

            if (jumpCounter > jumpTime)
            {
                isJumping = false;
            }

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            //ジャンプの半分に達したら徐々に上がる速度を落とす
            if (t > 0.5)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            rb.linearVelocity += vecGavity * currentJumpM * Time.deltaTime;
        }

    }

    //ジャンプ関数
    private void JumpHandler()
    {
        //b_move bool文入れる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {

                isJumping = true;

                jumpCounter = 0;

                Jump();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    //地面との接地をチェック1
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.transform.position, checkRadius, Ground);
    }
}