using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoaImageRotate : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject character;
    float speed = 5f;
    Vector3 rot;
    Quaternion origin;

    private void Start()
    {
        rot = character.transform.localEulerAngles;
        origin = Quaternion.Euler(rot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rot.y += Input.GetAxis("Mouse X") * speed;
        character.transform.localEulerAngles = -rot;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(RotateBack());
        rot.y = 180;
    }

    IEnumerator RotateBack()
    {
        float elapsedTime = 0f;
        float duration = 1f; // ȸ���� �Ϸ�Ǵ� �� �ɸ��� �ð�
        
        Quaternion startRotation = character.transform.rotation;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(startRotation, origin, elapsedTime / duration);
            yield return null;
        }

        character.transform.rotation = origin; // ȸ���� �Ϸ�� �� ��Ȯ�� ���� ȸ�������� ����
    }
}
