using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class Interactions : MonoBehaviour
{
    public GameObject letter;
    public enum InteractType
    {
        Food,
        Furniture,
        Paper
    }
    public InteractType item;

    [TextArea(5, 10)]
    public string text;
    public GameObject masterPanel;
    public TextMeshProUGUI masterText;
    private Meters meters;
    private Movement control;

    private void Awake()
    {
        control=new Movement();
        control.player.Interact.performed+=Interact;
    }
    private void Interact(InputAction.CallbackContext context) 
    {
        if (meters != null)
        {
            if (item == InteractType.Food)
            {
                meters.EatFood();
                Destroy(gameObject);
            }
            else if (item == InteractType.Furniture)
            {
                meters.Scratch();
            }
        }
        if (item == InteractType.Paper)
        {
            if (masterPanel != null && masterText != null)
            {
                masterPanel.SetActive(true);
                masterText.text = text;
                if (letter != null)
                {
                    letter.SetActive(false);
                }
                Time.timeScale = 0f; //pause the game
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            meters=other.GetComponent<Meters>();
            control.Enable();
            if(letter!=null)
            {
                letter.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            control.Disable();
            meters=null;
            if(letter!=null)
            {
                letter.SetActive(false);
            }
        }
    }
    private void OnDisable() 
    {
        control.Disable();
    }
    private void OnDestroy()
    {
        control.player.Interact.performed-=Interact;
    }
}
