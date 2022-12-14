using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script para a criação das armadinhas
public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject armadilhaPrefab;
    [SerializeField] float time = 2f;//tempo

    [SerializeField] float minY = -2f, maxY = 2f;//movimentação aleatória no eixo Y

    void Start()
    {
        InvokeRepeating(nameof(Spawn), time, time);
    }

    void Update()
    {
        
    }
    void Spawn()
    {
        GameObject newArmadilhas = Instantiate(armadilhaPrefab, transform.position, Quaternion.identity); //criar/clonar as armadilhas
        newArmadilhas.transform.position += new Vector3(0, Random.Range(minY, maxY)); //criando posição radomica presevando o eixo X

    }
}
