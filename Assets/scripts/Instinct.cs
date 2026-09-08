using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Instinct : MonoBehaviour
{
    public enum InstinctType
    {
        None,
        Zoomies,
        Scratch
    }
    public TextMeshProUGUI warning;
    [Header("Instinct Settings")]
    public float fillRate=2f;
    public float timeLimit=15f;   //set time
    private float currentInstinct=0f;
    private float threshold=25f;
    private bool activeUrge=false;
    private InstinctType currentInstinctType=InstinctType.None;
    private float urgeTimer=0f;   //stopwatch
    private float zoomiesProgress=0f;
    private Meters meters;
    private Rigidbody2D rb;
    private void Awake()
    {
        meters = GetComponent<Meters>();
        rb = GetComponent<Rigidbody2D>();

        if (warning != null)
        {
            warning.text="";
        }
    }

    // Update is called once per frame
    void Update()
    {   //meter for random cat activity building up in the bg
        if (!activeUrge)
        {
            currentInstinct += fillRate * Time.deltaTime;
            if(currentInstinct >= threshold)
            {
                RandomUrge();
                threshold+=25f;

                //restart threshold
                if (threshold > 100f)
                {
                    currentInstinct = 0f;
                    threshold = 25f;
                }
            }
        }
        else
        {
          urgeTimer-=Time.deltaTime;
            if (currentInstinctType == InstinctType.Zoomies)
            {
                if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
                {
                    zoomiesProgress+=Time.deltaTime;
                    if (zoomiesProgress >= 10f)
                    {
                        UrgeSatisfied();
                    }

                }
            }
            if (urgeTimer <= 0f)
            {
                UrgeFail();
            }  
        }
    }
    private void RandomUrge()
    {
        activeUrge=true;
        urgeTimer=timeLimit;
        int rand=Random.Range(1,3);

        if (rand == 1)
        {
            currentInstinctType=InstinctType.Zoomies;
            if (warning != null)
            {
                warning.text="Zoomies! Run around for 10 seconds!";
            }
        }
        else{
            currentInstinctType=InstinctType.Scratch;
            if (warning != null)
            {
                warning.text="Scratch! Find something to scratch!";
            }
        }
    }
    public void ConfirmScratch()
    {
        if (activeUrge && currentInstinctType == InstinctType.Scratch)
        {
            UrgeSatisfied();
        }
    }
    private void UrgeSatisfied()
    {
        activeUrge=false;
        currentInstinctType=InstinctType.None;
        if (warning != null)
        {
            warning.text="Urge Satisfied!";
        }
        Invoke("HideText", 2f);
    }
    private void UrgeFail()
    {
        activeUrge=false;
        currentInstinctType=InstinctType.None;
        if (warning != null)
        {
            warning.text="Urge Failed!";
        }
        
        if (meters != null)
        {
            meters.MaxSus();
        }
        Invoke("HideText", 2f);
    }
    private void HideText()
    {
        if (!activeUrge && warning != null)
        {
            warning.text="";
        }
    }
}
