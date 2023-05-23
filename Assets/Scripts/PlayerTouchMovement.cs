using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField]
    public FloatingJoystick Joystick;
    [SerializeField]
    private Rigidbody rb;

    private Finger MovementFinger;
    private Vector2 MovementAmount;

    public float speed = 3f;
    private Animator animator;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    // handles the knob movement of joystick
    private void HandleFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    Joystick.RectTransform.anchoredPosition
                ) > maxMovement)
            {
                knobPosition = (
                    currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition
                    ).normalized
                    * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }

            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
            animator.SetBool("Moving", true);
        }
    }


    // when player releases joystick
    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
            animator.SetBool("Moving", false);
        }
    }

    // When player touches screen
    private void HandleFingerDown(Finger TouchedFinger)
    {
        // check if already created and the finger is on left half of screen
        if (MovementFinger == null && TouchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }

    // prevent joystick from being on edge of screen
    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }

    private void Update()
    {
        // original movement
        //Vector3 scaledMovement = new Vector3(
        //    MovementAmount.x,
        //    0,
        //    MovementAmount.y
        //);

        // tried rotation, doesn't work
        // rb.rotation = new Quaternion(rb.rotation.x, Camera.main.transform.rotation.y, rb.rotation.z, rb.rotation.w);

        Transform cam = Camera.main.transform;

        // Gets camera positions and normalize
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        // Gets the movement relative to camera position
        Vector3 forwardRelative = MovementAmount.y * camForward * speed;
        Vector3 rightRelative = MovementAmount.x * camRight * speed;
        Vector3 camRelativeMovement = forwardRelative + rightRelative;

        // originally tried to rotate to camera, was wonky
        //var lookRotation = Quaternion.LookRotation(trackingPosition - rb.transform.position);
        //rb.transform.rotation =
        //    Quaternion.Lerp(rb.transform.rotation, lookRotation, Time.deltaTime * 10f);

        // original movement
        // rb.velocity = new Vector3(MovementAmount.x * speed, rb.velocity.y, MovementAmount.y * speed);

        rb.velocity = new Vector3(camRelativeMovement.x, rb.velocity.y, camRelativeMovement.z);

        rb.transform.LookAt(rb.transform.position + (camRelativeMovement * Time.deltaTime), Vector3.up);

        // original LookAt
        // rb.transform.LookAt(moveDir + scaledMovement, Vector3.up);
    }

    private void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle()
        {
            fontSize = 24,
            normal = new GUIStyleState()
            {
                textColor = Color.white
            }
        };
        if (MovementFinger != null)
        {
            GUI.Label(new Rect(10, 35, 500, 20), $"Finger Start Position: {MovementFinger.currentTouch.startScreenPosition}", labelStyle);
            GUI.Label(new Rect(10, 65, 500, 20), $"Finger Current Position: {MovementFinger.currentTouch.screenPosition}", labelStyle);
        }
        else
        {
            GUI.Label(new Rect(10, 35, 500, 20), "No Current Movement Touch", labelStyle);
        }

        GUI.Label(new Rect(10, 10, 500, 20), $"Screen Size ({Screen.width}, {Screen.height})", labelStyle);
    }
}
