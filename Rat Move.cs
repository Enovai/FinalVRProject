using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatButton : MonoBehaviour
{
    private bool isRatPickedUp = false;
    private Vector3 offset;

    void Update()
    {
        if (isRatPickedUp)
        {
            UpdateRatPosition();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                PickUpRat();
            }
        }

        if (Input.GetMouseButtonUp(0) && isRatPickedUp)
        {
            ReleaseRat();
        }
    }

    void UpdateRatPosition()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)) + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    void PickUpRat()
    {
        isRatPickedUp = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    void ReleaseRat()
    {
        isRatPickedUp = false;
    }
}
