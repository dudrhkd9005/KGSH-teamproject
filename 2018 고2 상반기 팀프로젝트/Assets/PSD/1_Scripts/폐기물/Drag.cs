using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public RectTransform rect;
    private Vector2 delta;

    void Update()
    {
        //if (EventSystem.current.IsPointerOverGameObject() == true)
        //    return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            float x = rect.localPosition.x + touchDeltaPosition.x * 3f;
            float y = rect.localPosition.y + touchDeltaPosition.y * 3f;

            x = Mathf.Clamp(x, -1050f, 900f);
            y = Mathf.Clamp(y, -1400, 1900f);

            //rect.localPosition = new Vector3(x, y, 0);
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(x, y, 0), Time.deltaTime * 10);
        }

        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float localScale = rect.localScale.x - deltaMagnitudeDiff * Time.deltaTime * 0.1f;

            localScale = Mathf.Clamp(localScale, 1.46f, 3f);

            //rect.localScale = new Vector3(localScale, localScale, rect.localScale.z);
            rect.localScale = Vector3.Lerp(rect.localScale, new Vector3(localScale, localScale, localScale), Time.deltaTime * 10);
        }
    }
}
