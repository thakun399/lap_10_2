using UnityEngine;

public class คาเมล่าฟอลโล่ : MonoBehaviour
{
    public Transform target;         // ตัวละครที่กล้องจะตาม
    public Vector3 offset;           // ระยะห่างระหว่างกล้องกับตัวละคร
    public float smoothSpeed = 0.125f; // ความนุ่มนวลในการตาม

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // ล็อค z ไว้
        }
    }
}
