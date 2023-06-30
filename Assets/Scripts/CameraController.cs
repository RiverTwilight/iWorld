using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 0.5f;
    public float zoomSpeed = 0.5f;
    public float rotationSpeed = 0.5f;

    private Vector2 previousTouchDelta;
    private Vector2 lastTouchPosition;
    private float totalScaleFactor;
    
void Update()
{
    if (Application.isEditor)
    {
        // Handle input in Unity editor
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 deltaPosition = lastTouchPosition - (Vector2)Input.mousePosition;
            transform.Translate(deltaPosition.x * panSpeed, deltaPosition.y * panSpeed, 0);
            lastTouchPosition = Input.mousePosition;
        // Handle scroll wheel for zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * zoomSpeed);
    }
    else
    {
        // Existing touch controls for when running on a device
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = lastTouchPosition - touch.position;
                transform.Translate(deltaPosition.x * panSpeed, deltaPosition.y * panSpeed, 0);
                lastTouchPosition = touch.position;
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDelta = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDelta = (touchZero.position - touchOne.position).magnitude;

            float zoomDelta = prevTouchDelta - touchDelta;
            transform.Translate(0, 0, zoomDelta * zoomSpeed);
            
            Vector2 currentTouchDelta = touchZero.position - touchOne.position;
            if (previousTouchDelta != Vector2.zero)
            {
                float deltaAngle = Vector2.SignedAngle(previousTouchDelta, currentTouchDelta);
                transform.Rotate(0, -deltaAngle * rotationSpeed, 0, Space.World);
            }
            previousTouchDelta = currentTouchDelta;
        }
    }
    }
}
}
