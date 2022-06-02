using UnityEngine;

public class playerController : MonoBehaviour
{
    private playermovement playermovement;
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }




    private void Awake()
    {
        playermovement = GetComponent < playermovement>();  
    }
    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playermovement.Move(x);
          
        ///damage


        if (Input.GetKeyDown(KeyCode.Space))
        {
                playermovement.Jump();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playermovement.isLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            playermovement.isLongJump = false; 
        }
    }



}
