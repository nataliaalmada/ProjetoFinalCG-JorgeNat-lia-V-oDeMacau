using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arara : MonoBehaviour
{
    [SerializeField] Vector3 axis; // três eixos da arara
    [SerializeField] float gravity = -8f; //gravidade da arara
    [SerializeField] float force = 4f; //força de ir para cima
    private SpriteRenderer spriteRenderer; // acessar o sprite
    [SerializeField] Sprite[] sprites; // matriz para guardar os sprites
    [SerializeField] int spriteIndex; //acessar o indice de um sprite

    [SerializeField] float timeChange = 0.15f; //tempo de mudança do sprite
    [SerializeField] GameManager gameManager;// para poder ativar os objetos GameManager em arara
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();//inicia o script GameManager
        spriteRenderer = GetComponent<SpriteRenderer>(); //obter o componente do sprite dentro da Unity
        InvokeRepeating(nameof(AnimationSprites), timeChange, timeChange); //iniciar o metodo de repetição
    }

    void Update()
    {
        axis.y += gravity * Time.deltaTime; //movimentar a arara pra cima e pra baixo
        transform.position += axis * Time.deltaTime; //posição atual da arara
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//função que se pressionar o espaço ou touchpad irá para cima 
        {
            axis = Vector2.up * force;
        }
    }
    void AnimationSprites() // executa as animações do sprites
    {
        spriteIndex++; //transição dos sprites

        if (spriteIndex >= sprites.Length)//tratamento para evitar erro quando chegar no último sprite
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex]; //componente responsavel por mudar os sprites
    }
    private void OnTriggerEnter2D(Collider2D collision)//metodo para a arara detectar as colisões
    {
        if(collision.CompareTag("Obstacles"))//colisão com armadilhas e chão
        {
            gameManager.GameOver();
        }
        if(collision.CompareTag("Scoring"))//colisão entre os canos(pontuação)
        {
            gameManager.Scoring();
        }
    }
}
