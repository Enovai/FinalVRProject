
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ClickToMovePancake : MonoBehaviour
{
    private bool isMoving = false;
    private float movementDuration = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            MovePancakeToClickPosition();
        }
    }

    private void MovePancakeToClickPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                StartCoroutine(MovePancake(hit.point));
            }
        }
    }

    private IEnumerator MovePancake(Vector3 targetPosition)
    {
        isMoving = true;

        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < movementDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / movementDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
