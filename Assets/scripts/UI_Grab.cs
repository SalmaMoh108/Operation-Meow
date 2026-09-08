using UnityEngine;

public class UI_Grab : MonoBehaviour
{
    public GameObject ui;
    public GameObject prefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ui != null)
            {
                ui.SetActive(false);
                prefab.SetActive(true);
                Destroy(gameObject);
            }
            
        }
    }

    
}
