using UnityEngine;

namespace Entity
{
    public abstract class Movable : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float jumpForce = 8f;
        
        
        [Header("Ground Check")]
        [SerializeField] Transform groundCheck;      // empty child at the feet
        [SerializeField] float groundCheckRadius = 0.55f;
        [SerializeField] LayerMask groundMask;
        
        
        protected Rigidbody2D rb2d;
        
        ContactFilter2D groundFilter;
        readonly Collider2D[] groundHits = new Collider2D[8];

        protected virtual void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            
            groundFilter = new ContactFilter2D();
            groundFilter.useTriggers = false;        // ignore trigger colliders
            groundFilter.SetLayerMask(groundMask);
        }
        
        public bool IsGrounded()
        {
            int count = Physics2D.OverlapCircle(
                groundCheck.position, groundCheckRadius, groundFilter, groundHits);

            for (int i = 0; i < count; i++)
            {
                // Skip the player's own collider(s), including child colliders
                if (groundHits[i].attachedRigidbody == rb2d) continue;
                return true;
            }
            return false;
        }
        
        public void Move(Vector2 direction)
        {
            rb2d.linearVelocity = new Vector2(direction.x * moveSpeed, rb2d.linearVelocity.y);
        }

        public void Jump()
        {
            if (!IsGrounded()) return;

            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0f);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}