using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorController : MonoBehaviour
{
    public int doorOpenTimeInterval;
    public float doorSpeed;
    public float OPEN_X_OFFSET_DOOR;

    public GameObject leftDoor;
    public GameObject rightDoor;
    private int closingCounter;
    private DoorState state;

    private Vector3 leftDoorInitialPosition;
    private Vector3 rightDoorInitialPosition;


    private enum DoorState
    {
        Open,
        Closed,
        Opening,
        Closing
    }

    void Start()
    {
        InvokeRepeating("Tick", 1f, 1f);
        leftDoorInitialPosition = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y, leftDoor.transform.position.z);
        rightDoorInitialPosition = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y, rightDoor.transform.position.z);
        state = DoorState.Closed;
        closingCounter = doorOpenTimeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // temporary
        SetStateFromKeyboard();

        switch (state)
        {
            case DoorState.Closing:
                leftDoor.transform.position += Vector3.right * doorSpeed * Time.deltaTime;
                rightDoor.transform.position += Vector3.left * doorSpeed * Time.deltaTime;
                if (TooClosed())
                {
                    print("Door closed");
                    state = DoorState.Closed;
                    leftDoor.transform.position = leftDoorInitialPosition;
                    rightDoor.transform.position = rightDoorInitialPosition;
                }
                break;
            case DoorState.Opening:
                leftDoor.transform.position += Vector3.left * doorSpeed * Time.deltaTime;
                rightDoor.transform.position += Vector3.right * doorSpeed * Time.deltaTime;
                if (TooOpen())
                {
                    print("Door opened, starting count down");
                    state = DoorState.Open;
                    ResetCountDown();
                    leftDoor.transform.position = leftDoorInitialPosition - new Vector3(OPEN_X_OFFSET_DOOR, 0, 0);
                    rightDoor.transform.position = rightDoorInitialPosition + new Vector3(OPEN_X_OFFSET_DOOR, 0, 0);
                }
                break;
            case DoorState.Closed:
                break;
            case DoorState.Open:
                break;
            default:
                break;
        }
    }

    void SetStateFromKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("Key O down, Opening");
            state = DoorState.Opening;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            print("Key C down, Closing");
            state = DoorState.Closing;
        }
    }

    bool TooClosed()
    {
        return leftDoor.transform.position.x > leftDoorInitialPosition.x || rightDoor.transform.position.x < rightDoorInitialPosition.x;
    }

    bool TooOpen()
    {
        return leftDoor.transform.position.x < leftDoorInitialPosition.x - OPEN_X_OFFSET_DOOR || rightDoor.transform.position.x > rightDoorInitialPosition.x + OPEN_X_OFFSET_DOOR;
    }

    void ResetCountDown()
    {
        closingCounter = doorOpenTimeInterval;
    }

    void Tick()
    {
        if (state == DoorState.Open)
        {
            closingCounter -= 1;
            print("Countdown " + closingCounter);
            if (closingCounter == 0)
            {
                state = DoorState.Closing;
            }
        }
    }

    public void ButtonOpen()
    {
        print("ButtonOpen called");
        state = DoorState.Opening;
    }

}
