using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveInput.x * _moveSpeed, _rb.linearVelocity.y);
        _rb.linearVelocity = movement;
        _animator.SetFloat("Speed", movement.magnitude);
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (_moveInput.x > 0.1f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_moveInput.x < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }
    }
}