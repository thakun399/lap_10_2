using UnityEngine;
using UnityEngine.UI;

public class เหรียญ : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip normalPickupSound;    // เสียงตอนเก็บเหรียญปกติ
    public AudioClip specialPickupSound;   // เสียงตอนเก็บเหรียญพิเศษ
    public GameObject pickupEffectPrefab;
    public bool isSpecialCoin = false;     // เป็นเหรียญพิเศษไหม
    public Text messageText;               // ช่องข้อความแสดงตอนชนเหรียญ
    public string specialMessage = "You got a special coin!"; // ข้อความที่จะแสดง

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.AddScore(coinValue);
            }

            // เล่นเสียงตามประเภทเหรียญ
            if (isSpecialCoin)
            {
                if (specialPickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(specialPickupSound, transform.position);
                }
            }
            else
            {
                if (normalPickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(normalPickupSound, transform.position);
                }
            }

            // สร้างเอฟเฟกต์
            if (pickupEffectPrefab != null)
            {
                Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            }

            // แสดงข้อความตอนเก็บเหรียญ
            if (messageText != null)
            {
                messageText.text = specialMessage;
                messageText.gameObject.SetActive(true);
                Invoke("HideMessage", 2f); // ซ่อนข้อความหลัง 2 วินาที
            }

            Destroy(gameObject); // ลบเหรียญ
        }
    }

    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
