using UnityEngine;

namespace Entity
{
    public abstract class Movable : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float jumpForce = 8f;
        
        
        [Header("Ground Check")]
        [SerializeField] Collider2D groundCheck;
        [SerializeField] Collider2D selfCollider;
        
        
        protected Rigidbody2D rb2d;
        
        ContactFilter2D groundFilter;
        readonly Collider2D[] groundHits = new Collider2D[8];

        protected virtual void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        
        public bool IsGrounded()
        {
            return groundCheck.IsTouching(FindAnyObjectByType<Collider2D>()) && !groundCheck.IsTouching(selfCollider);
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