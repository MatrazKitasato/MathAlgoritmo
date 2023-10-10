using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public MovimientoJugador _player;
    public TextMeshProUGUI _life;
    public TextMeshProUGUI _score;

    public TextMeshProUGUI[] HighScore;
    private float time;
    public int timeSeconds;

    public GameObject _panel;
    public GameObject botonPausa;
    public GameObject menuPausa;
    int score = 0;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        
        _life.text = "HP: " + _player.life;

        time += Time.deltaTime;
        timeSeconds = Mathf.RoundToInt(time);
        _score.text = "Score: " + timeSeconds.ToString();
    }
    public void ShowScore()
    {
        Debug.Log("Longitud: " + GameManager.instance.score.length);
        for(int i = 0; i < HighScore.Length; i++)
        {
            if(GameManager.instance.score.length >= i)
            {
                HighScore[i].text = GameManager.instance.score.GetNodeValueAtPosicion(i).ToString();
            }
            
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Vida()
    {
        ShowScore();
        _panel.SetActive(true);
        botonPausa.SetActive(false);
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        score = timeSeconds;
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
