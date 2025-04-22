using UnityEngine;

public class Boos : MonoBehaviour
{
    public float boostForce = 500f; // กำลังแรงที่พุ่ง
    public Vector2 boostDirection = Vector2.right; // ทิศทางพุ่ง (ค่าเริ่มต้นไปขวา)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // ก่อนพุ่ง เซต velocity เป็นศูนย์ก่อน เพื่อไม่ให้มีความเร็วเก่าค้าง
                rb.velocity = Vector2.zero;

                // เช็กว่า boostDirection ถูกต้องไหม (ไม่ใช่ (0,0))
                if (boostDirection != Vector2.zero)
                {
                    // ใส่แรงพุ่ง
                    rb.AddForce(boostDirection.normalized * boostForce, ForceMode2D.Impulse);
                }
                else
                {
                    Debug.LogWarning("BoostZone: boostDirection เป็น (0,0) เลยไม่สามารถพุ่งได้!");
                }
            }
        }
    }
}
