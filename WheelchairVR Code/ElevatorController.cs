using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public float moveSpeed;
    public float FIRST_FLOOR_Y;
    public float SECOND_FLOOR_Y;

    public ElevatorDoorController elevatorDoorController;

    private ElevatorState state;

    private Vector3 initialPosition;

    private enum ElevatorState
    {
        MovingUp,
        MovingDown,
        StoppedOnFirst,
        StoppedOnSecond,
    }

    void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        state = ElevatorState.StoppedOnFirst;
    }

    // Update is called once per frame
    void Update()
    {
        // temporary
        SetStateFromKeyboard();

        switch (state)
        {
            case ElevatorState.MovingUp:
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                if (TooHigh())
                {
                    print("Arrived on second floor");
                    state = ElevatorState.StoppedOnSecond;
                    transform.position = initialPosition + Vector3.up * SECOND_FLOOR_Y;
                }
                break;
            case ElevatorState.MovingDown:
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
                if (TooLow())
                {
                    print("Arrived on first floor");
                    state = ElevatorState.StoppedOnFirst;
                    transform.position = initialPosition;
                }
                break;
            case ElevatorState.StoppedOnFirst:
                break;
            case ElevatorState.StoppedOnSecond:
                break;
            default:
                break;
        }
    }

    void SetStateFromKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Key U down, moving up");
            state = ElevatorState.MovingUp;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            print("Key D down, moving down");
            state = ElevatorState.MovingDown;
        }
    }

    bool TooHigh()
    {
        return transform.position.y > SECOND_FLOOR_Y;
    }

    bool TooLow()
    {
        return transform.position.y < FIRST_FLOOR_Y;
    }

    public void MoveToFirst()
    {
        state = ElevatorState.MovingDown;
    }

    public void MoveToSecond()
    {
        state = ElevatorState.MovingUp;
    }

}
