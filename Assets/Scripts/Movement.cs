using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterAttributes))]
public class Movement : MonoBehaviour
{

    Rigidbody2D _rigidbody;
    CharacterAttributes _attributes;
    
    float _movementSpeed;

    private void Start() 
    {
        GetComponents();
        ConfigureRigidbody();
        CalculateFromAttributes();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);
    }

    public void Move(Vector2 vector) 
    {
        _rigidbody.AddForce(vector, ForceMode2D.Force);
        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _movementSpeed);
    }

    private void ConfigureRigidbody()
    {
        _rigidbody.gravityScale = 0f;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void CalculateFromAttributes() 
    {
        _movementSpeed = 3 + _attributes.Dex / 2;
    }

    private void GetComponents() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _attributes = GetComponent<CharacterAttributes>();
    }
}
