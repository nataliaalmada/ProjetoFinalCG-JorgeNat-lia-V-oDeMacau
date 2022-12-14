using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer; // acessar o MeshRenderer do background
    [SerializeField] float speedTexture; //acessar a velocidade
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speedTexture * Time.deltaTime, 0); //acessar a textura e modificar apenas no eixo x
    }
}
