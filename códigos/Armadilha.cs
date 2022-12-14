using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    [SerializeField] float speed = -2f; //velocidade das armadilhas para esquerda
    [SerializeField] float leftBord;
    void Start()
    {
        leftBord = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f; //pegando posição da camera para destroir as armadilhas que saem
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);//pegando o eixo para a movimentação das armadilhas

        if(transform.position.x <= leftBord)
        {
            Destroy(gameObject); //destroir as armadilhas que saem da cena
        }
    }
}
