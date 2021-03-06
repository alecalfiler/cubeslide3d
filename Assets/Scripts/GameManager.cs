﻿
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Animator animator;
    bool gameHasEnded = false; //tracker to know if game has been failed or completed.
    public GameObject completeGameUI; //upon winning, this will be enabled.
    public GameObject titleScreen; 

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //advance to game scene from title screen.
    }

    public void EndGame() 
    {
        if (gameHasEnded == false) //prevents constant restarting after reaching a certain circumstance (loss/win)
        {
            gameHasEnded = true;
            Invoke("Restart" , 1f);
        }
        else { //added an if statement since game would be at false for "Play Again" button.
            Restart();

        }
    }

    public void winGame()
    {
        if (gameHasEnded == false)
        {
            animator.SetTrigger("CompleteGame"); //triggers the animation which fades the credits in.
            gameHasEnded = true;
            completeGameUI.SetActive(true);
        }
    }

    void Restart()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    
}
