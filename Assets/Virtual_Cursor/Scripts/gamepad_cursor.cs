// Tutorial Video: https://www.youtube.com/watch?v=Y3WNwl1ObC8
using UnityEngine;
using UnityEngine.InputSystem;
using uEInputSystem = UnityEngine.InputSystem;// An alias for scope resolution
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class gamepad_cursor : MonoBehaviour
{
    [SerializeField]
    private uEInputSystem::PlayerInput playerInput;// Scope resolution because PlayerInput assets
    [SerializeField]
    private RectTransform cursorTransform;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform canvasRectTransform;
    [SerializeField]
    private float cursorSpeed = 1000f;
    [SerializeField]
    private float padding = 20f;

    private Vector2 startPosition;
    private bool cursorStart;
    private bool previousMouseState;
    private Mouse virtualMouse;
    private Camera mainCamera;

    private bool gamepadConnected;
    [SerializeField]
    private GameObject cursorInstructions;

    private void OnEnable()
    {
        mainCamera = Camera.main; // set to main player camera so that it can hit the controls of the main player (the camera is a child of player along with controls)

        if (virtualMouse == null)
        {
            Debug.Log("virtual mouse is null");
            virtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
            Debug.Log("Input System" + playerInput);

        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice("VirtualMouse");
            Debug.Log("Input System" + playerInput);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if (cursorTransform != null)
        {
            startPosition = new Vector2(cursorTransform.position.x, cursorTransform.position.y);
            InputState.Change(virtualMouse.position, startPosition);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
    }


    private void OnDisable()
    {
        InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    void Start()
    {
        cursorStart = true;
        gamepadConnected = false;
    }

    private void Update()
    {
        GameObject cursor = GameObject.FindGameObjectWithTag("Cursor");
        bool cursorIsPressed;

        if (Gamepad.current == null)
        {
            gamepadConnected = false;
            cursor.transform.position = new Vector3(20000, 0, 0);
        }
        else if (Gamepad.current != null)
        {
            // if a Gamepad was most recently not connected
            if (gamepadConnected == false)
            {
                // Receiving gamepad input means a gamepad has just been connected
                gamepadConnected = true;

                // Show instructions for Gamepad cursor controls
                if (cursorInstructions != null)
                {
                    cursorInstructions.SetActive(true);
                }
            }
            
            cursorIsPressed = (Gamepad.current.rightStickButton.IsPressed() || Gamepad.current.buttonWest.IsPressed());
            if (previousMouseState != cursorIsPressed)
            {
                virtualMouse.CopyState<MouseState>(out var mouseState);
                mouseState.WithButton(MouseButton.Left, cursorIsPressed);
                Debug.Log(MouseButton.Left + " virtual mouse click");
                InputState.Change(virtualMouse, mouseState);
                previousMouseState = cursorIsPressed;
            }
        }
        
    }

    private void UpdateMotion()
    {
        bool cursorIsPressed;
        Vector2 deltaValue;
        Vector2 currentPosition;
        Vector2 newPosition;

        if (virtualMouse != null && Gamepad.current != null)
        {
            deltaValue = Gamepad.current.dpad.ReadValue();// Use input from the  D-Pad to control  the cursor/virtual mouse
            deltaValue *= cursorSpeed/2 * Time.deltaTime;

            currentPosition = virtualMouse.position.ReadValue();

            if (cursorStart)
            {
                currentPosition = startPosition;
                cursorStart = false;
            }

            newPosition = currentPosition + deltaValue;

            newPosition.x = Mathf.Clamp(newPosition.x, padding, Screen.width - padding);
            newPosition.y = Mathf.Clamp(newPosition.y, padding, Screen.height - padding);

            InputState.Change(virtualMouse.position, newPosition);
            InputState.Change(virtualMouse.delta, deltaValue);

            cursorIsPressed = (Gamepad.current.rightStickButton.IsPressed() || Gamepad.current.buttonWest.IsPressed());

            if (previousMouseState != cursorIsPressed)
            {
                virtualMouse.CopyState<MouseState>(out var mouseState);
                mouseState.WithButton(MouseButton.Left, cursorIsPressed);
                Debug.Log(MouseButton.Left + " virtual mouse click");
                InputState.Change(virtualMouse, mouseState);
                previousMouseState = cursorIsPressed;
            }

            AnchorCursor(newPosition);
        }
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, canvas.renderMode
        == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchoredPosition);
        cursorTransform.anchoredPosition = anchoredPosition;
    }
}