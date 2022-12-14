using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
//acessar cada objeto criado no canvas: botão, texto...

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText; //manipular as variaveis de texto
    [SerializeField] int score; //pontuação
    [SerializeField] private GameObject gameOverObj;// acessar o GameOver
    [SerializeField] private GameObject startObj;// acessar o startObj
    

    void Start()
    {
        Time.timeScale = 0; //inicia o jogo paralizado(primeiro acesso)
        startObj.SetActive(true);// ativar a imagem start
    }
    public void StartButton()//iniciar o jogo
    {
        Time.timeScale = 1;//ao pressionar o botão o Time.timeScale se torna 1 e o jogo roda
        gameOverObj.SetActive(false);//desativa o painel GameOver
        startObj.SetActive(false);//desativa o objeto startObj
    }

    void Update()
    {
        scoreText.text = score.ToString();//transformar a variavel em texto
    }
    public void GameOver()//ativar o GameOver
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0;//parar o jogo
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);//recarregar a cena após apertar o botão Restar
    }
    public void Scoring()//pontuação
    {
        score++;
        scoreText.text = score.ToString();
    }
}
