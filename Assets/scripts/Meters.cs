using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Meters : MonoBehaviour
{
    public Slider needs;
    public GameObject gameOver;
    public TextMeshProUGUI deathText;
    public Slider suspicion;
    private bool dead=false;
    [Header("Human Needs")]
    public float maxNeeds=100f;
    public float crawlPenalty=5f;
    public float scratchPenalty=20f;
    public float foodHeal=35f;
    public float standHeal=10f;

    [Header("Suspicion")]
    public float maxSuspicion=100f;
    public float foodPenalty=40f;
    public float standPenalty=40f;
    public float scratchHeal=30f;
    public float crawlHeal=10f;

    private float currentNeeds;
    private float currentSuspicion;
    public bool danger=false;
    private PlayerMovement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        player=GetComponent<PlayerMovement>();
        currentNeeds=maxNeeds;
        currentSuspicion=0f;
    }

    // Update is called once per frame
    void Update()
    {  
        if(dead) return;
         //human needs
        if (player.isStanding)
        {
            currentNeeds+=standHeal*Time.deltaTime;
        }  
        else
        {
            currentNeeds-=crawlPenalty*Time.deltaTime;
        }
        //suspicion meter
        if (player.isStanding && danger)
        {
            currentSuspicion+=standPenalty*Time.deltaTime;
        }
        else if(!player.isStanding)
        {
            currentSuspicion-=crawlHeal*Time.deltaTime;
        }

        //clamp the values so they don't go below 0 or above their max
        currentNeeds=Mathf.Clamp(currentNeeds,0f,maxNeeds);
        currentSuspicion=Mathf.Clamp(currentSuspicion,0f,maxSuspicion);

        //update the UI sliders
        needs.value=currentNeeds/maxNeeds;
        suspicion.value=currentSuspicion/maxSuspicion;

        //check death
        if (currentNeeds <= 0f)
        {
            dead=true;
            GameOver("You couldn't handle the cat life");
        }
        else if (currentSuspicion >= maxSuspicion)
        {
            dead=true;
            GameOver("You got caught by the cats");
        }
    }
    public void EatFood()
    {
        currentNeeds+=foodHeal;
        if (danger)
        {
            currentSuspicion+=foodPenalty;
        }
        needs.value=currentNeeds/maxNeeds;
        suspicion.value=currentSuspicion/maxSuspicion;
    }
    public void Scratch()
    {
        currentNeeds-=scratchPenalty;
        currentSuspicion-=scratchHeal;
        needs.value=currentNeeds/maxNeeds;
        suspicion.value=currentSuspicion/maxSuspicion;

        //smth was scratched
        Instinct instinct=GetComponent<Instinct>();
        if(instinct!=null)
        {
            instinct.ConfirmScratch();
        }
    }
    public void SetDanger(bool state)
    {
        danger=state;
    }
    public void GameOver(string death)
   {
        gameOver.SetActive(true);
        deathText.text=death;
        Time.timeScale=0f; //freeze the game
    }
    public void MaxSus()
    {
        currentSuspicion=maxSuspicion;
        suspicion.value=currentSuspicion/maxSuspicion;
    }
}
