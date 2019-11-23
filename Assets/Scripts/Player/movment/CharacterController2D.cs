using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public static LayerMask nullMask;
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround = nullMask;							// A mask determining what is ground to the character
	[SerializeField] private RectTransform m_GroundCheck = null;                            // A position marking where to check if the player is grounded.
	[SerializeField] private float downwardsAcceleration = 0f;
    [SerializeField] private Animator animator;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
    private bool ableToDoubleJump;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Vector2 pointA = new Vector2(m_GroundCheck.position.x, m_GroundCheck.position.y) - m_GroundCheck.rect.size * transform.localScale / 2;
		Vector2 pointB = new Vector2(m_GroundCheck.position.x, m_GroundCheck.position.y) + m_GroundCheck.rect.size * transform.localScale / 2;
		Collider2D collider = Physics2D.OverlapArea(pointA, pointB, m_WhatIsGround);
		if (collider != null) {
			if (collider.gameObject != gameObject)
			{
				m_Grounded = true;
                ableToDoubleJump = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

		if (m_Rigidbody2D.velocity.y < 0)
		{
			m_Rigidbody2D.AddForce(Vector2.down * downwardsAcceleration);
		}
	}


	public void Move(float move, bool jump)
	{

		if (m_Grounded || m_AirControl)
		{
            

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (ableToDoubleJump && jump)
		{
			if(m_Grounded)
            {
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector3(m_Rigidbody2D.velocity.x, 0, 0);   
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                ableToDoubleJump = false;
            }
			FindObjectOfType<AudioManager>().Play("Jump");
		}
        if (!m_Grounded) animator.SetBool("Airborne", true);
        else animator.SetBool("Airborne", false);

        if (m_Rigidbody2D.velocity.x != 0) animator.SetBool("IsMoving", true);
        else animator.SetBool("IsMoving", false);
    }


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
	}
}
