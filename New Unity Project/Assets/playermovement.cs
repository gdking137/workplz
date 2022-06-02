using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Rigidbody2D rigid2D;
    [SerializeField]
    private float jumpForce = 8.0f;
    [HideInInspector]
    public bool isLongJump = false;

    Animator anim;

    [SerializeField]
    private LayerMask groundLayer;
    private CapsuleCollider2D capsuleCollider2D;
    private bool isGrounded;
    private Vector3 footPosition;

    [SerializeField]
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    SpriteRenderer spriteRenderer;



    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //�ݶ��̴� �µθ� ����
        Bounds bounds = capsuleCollider2D.bounds;
        //�� ��ġ = �µθ� ��       
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        //isGrounded�� Ʈ���� 
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);




        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }


        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }

        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    ///������
    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }



    /// ���� + ���� �������� ���� + ��������
    public void Jump()
    {
        if (isGrounded == true)
        {
            rigid2D.velocity = Vector2.up * jumpForce;

        }

        if (currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }


    }



        /////�ɸ��� �ø�
    private void Update()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}

