using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool hasKey;
    public int numberOfLives;

    public Text numLivesText;
    public Image hasKeyIcon;

    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        hasKeyIcon.enabled = false;

        startPosition = transform.position;
    }

    public bool UsePlayerKey()
    {
        if (hasKey)
        {
            hasKey = false;
            hasKeyIcon.enabled = false;
            return true;
        }
        return hasKey;
    }

    public void PickUpKey()
    {
        hasKey = true;
        hasKeyIcon.enabled = true;
    }

    public void PlayerDeath()
    {
        if (numberOfLives > 1)
        {
            numberOfLives--;
            numLivesText.text = "" + numberOfLives;
            ResetPlayerPosition();
        }
        else
        {
            numberOfLives--;
            numLivesText.text = "" + numberOfLives;
            GameOver();
        }
    }

    private void ResetPlayerPosition()
    {
        transform.position = startPosition;
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        //reset to menu or 1st level
    }
}
