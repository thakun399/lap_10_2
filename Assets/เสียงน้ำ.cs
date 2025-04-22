using UnityEngine;

public class เสียงน้ำ : MonoBehaviour
{
    
    // ตัวแปรสำหรับเก็บเสียงน้ำ
    public AudioClip waterSound;
    private AudioSource audioSource;

    void Start()
    {
        // เพิ่ม AudioSource ให้กับตัวนี้
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = waterSound; // กำหนดเสียงที่ใช้
        audioSource.playOnAwake = false; // ไม่ให้เล่นเสียงอัตโนมัติเมื่อเริ่มเกม
    }

    // เมื่อมีการเข้าไปใน Trigger Area
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เล่นเสียงน้ำเมื่อผู้เล่นเดินเข้าไปในพื้นที่
            if (!audioSource.isPlaying)  // เช็คว่าเสียงยังไม่เล่นอยู่
            {
                audioSource.Play();
            }
        }
    }

    // เมื่อผู้เล่นออกจาก Trigger Area
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ถ้าต้องการหยุดเสียงเมื่อผู้เล่นออกจากพื้นที่
            audioSource.Stop();
        }
    }
}
