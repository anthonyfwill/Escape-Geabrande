using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameScene : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public IEnumerator ToGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameScene");
    }
}
