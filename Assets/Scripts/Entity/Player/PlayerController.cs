using Entity;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Movable
{
    private Vector2 inputDirection;

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Keyboard.current != null)
        {
            //TODO switch input system to input-map later
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)Jump();
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) direction.x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) direction.x = 1;
        }

        inputDirection = direction;
    }

    void FixedUpdate()
    {
        Move(inputDirection.normalized);
    }
}
