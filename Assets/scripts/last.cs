using UnityEngine;

public class last : MonoBehaviour
{
   public GameObject win;

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        win.SetActive(true);
        Time.timeScale=0f; //pause the game
   }
}}
