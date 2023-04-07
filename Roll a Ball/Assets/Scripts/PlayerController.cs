using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

// Criação de variáveis que armazenam a velocidade, os textos da tela, a física e o contador
    public float speed;
    public Text countText;
    public Text countSecText;
    public Text winText;

    private Rigidbody rb;
    public int count;
    private float countSec;
    private float countSecToWinScene;
    public bool win; 

    void Start ()
    {
        // RigidBody, contadores, função que armazena o contador e texto de vitória
        win = false;
        rb = GetComponent<Rigidbody>();
        count = 0;
        countSec = 45;
        countSecToWinScene = 3;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        // Captura de inputs do teclado
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        // Adição de força ao corpo
        rb.AddForce (movement * speed);
        
        // Funcionalidade nova: uma função que freia o corpo
        Break();

        /* Funcionalidade nova: temporizador. Esta função encerra o jogo 
        ao se passar 30 segundos com a função QuitGame*/
        CounterSec();
        LoadWinScene();

    }

    void CounterSec()
    {
        if(countSec > 0)
        {
            countSec = countSec-Time.deltaTime;
            countSecText.text = $"Restam {countSec.ToString("0")} segundos!";
            // Debug.Log(countSec);

            if(win == true)
            {
                countSec = 45;
            }
        } 
        else
        {
            QuitGame();
        }
    }

    // Função de freio
    void Break()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.drag = 20;
        } 
        else {
            rb.drag = 0;
        }
    }

    /* Função que captura colisão e coleta os itens, setando a visibilidade
    dos mesmos para falso e incrementando o contador que armazena os itens salvos */ 
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }

    /* Função que, com uma condicional, verifica o contador e ao retornar true, 
    atualiza o texto de vitória */
    public void SetCountText()
    {
        countText.text = "Destruídos: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "Parabéns, você venceu!!";
            win = true;
        }
    }
    public void LoadWinScene()
    {
        if(win == true)
        {
            if(countSecToWinScene > 0 )
            {
                countSecToWinScene = countSecToWinScene-Time.deltaTime;
                Debug.Log(" < 5");
                Debug.Log(countSecToWinScene);
            }
            else 
            {
                SceneManager.LoadScene("Win");
                Debug.Log(" > 5");
                Debug.Log(countSecToWinScene);
            }
        }
        
    }

    /* Função que exibe a mensagem de fim de jogo e encerra a aplicação */
    public void QuitGame()
    {
        Debug.Log("Saiu do jogo");
        countSecText.text = $"O tempo acabou, fim de jogo!";
        SceneManager.LoadScene("GameOver");
    }
    
}