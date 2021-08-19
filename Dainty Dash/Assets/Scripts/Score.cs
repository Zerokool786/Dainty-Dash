using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int hardMode = 1;
    private int maxHardMode = 10;
    private int scoreToNextLevel = 20;
    
    
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToNextLevel)
            LevelUp();
        
        score += Time.deltaTime * hardMode;
        scoreText.text = ((int)score).ToString ();
    }

    void LevelUp()
    {
        if (hardMode == maxHardMode)
            return;
        
        scoreToNextLevel *= 2;

        hardMode++;

        GetComponent<PlayerMovement>().setPlayerSpeed(hardMode);
        Debug.Log(hardMode);
    }
}
