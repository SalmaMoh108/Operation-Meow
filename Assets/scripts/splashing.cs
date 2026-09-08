using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class splashing : MonoBehaviour
{
    
    public CanvasGroup jesters;

    public float fadeDuration = 2f; // Duration of the fade effect in seconds
    public float fadeSpeed=1.5f;
    public string mainScene="Tutorial";
    private void Start() {
        
        jesters.alpha=0f;
        StartCoroutine(Splash());
    }
    private IEnumerator Splash()
    {
        yield return new WaitForSeconds(1f); //wait for 1 second before starting the fade

        //fade in
        
        while(jesters.alpha<1f)
        {
            jesters.alpha+=fadeSpeed*Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(fadeDuration);
        while(jesters.alpha>0f)
        {
            jesters.alpha-=fadeSpeed*Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f); //wait for 1 second before starting the fade
        SceneManager.LoadScene(mainScene);

    }
}
