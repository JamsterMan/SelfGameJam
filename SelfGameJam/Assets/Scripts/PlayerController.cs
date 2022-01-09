using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool hasKey;
    public int numberOfLives;

    public static Text numLivesText;
    public static Image hasKeyIcon;

    /*private*/public Vector3 startPosition;
    private KeyControl keyObject;

    // Start is called before the first frame update
    void Start()
    {
        numLivesText = GameObject.Find("NumberOfLives").GetComponent<Text>();
        hasKeyIcon = GameObject.Find("HasKeyIcon").GetComponent<Image>();

        hasKey = false;
        hasKeyIcon.enabled = false;

        startPosition = transform.position;
        keyObject = null;
    }

    public bool UsePlayerKey()
    {
        if (hasKey)
        {
            SetKeyValues(false, null);
            return true;
        }
        return hasKey;
    }

    public void PickUpKey(KeyControl key)
    {
        if (!hasKey)
        {
            SetKeyValues(true, key);
        }
    }

    public void PlayerDeath()
    {
        if (hasKey)
        {
            if (keyObject != null)
                keyObject.SetKeyVisable();
            SetKeyValues(false, null);
        }

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

    private void SetKeyValues(bool val, KeyControl key)
    {
        hasKey = val;
        hasKeyIcon.enabled = val;
        keyObject = key;
    }

    private void ResetPlayerPosition()
    {
        Debug.Log("position reset");
        transform.position = startPosition;
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        numberOfLives = 5;
        numLivesText.text = "" + numberOfLives;
        SceneManager.LoadScene(0);
    }
}
