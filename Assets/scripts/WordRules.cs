using UnityEngine;

public class WordRules : MonoBehaviour
{
    public GameObject greenText;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")&& gameObject.CompareTag("No"))
        {
            GameManager.instance.UnlockDoubleJump();
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Red") && other.gameObject.CompareTag("Paint"))
        {
            GameManager.instance.LaserHack();
            Destroy(gameObject);
            greenText.SetActive(true);
            
           
        }
    }
    
}
