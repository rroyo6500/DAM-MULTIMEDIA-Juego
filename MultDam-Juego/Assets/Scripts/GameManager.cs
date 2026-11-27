using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Escenas")]
    public string escenaDerrota = "Derrota"; // Pon el nombre exacto de tu escena

    [Header("Datos de partida")]
    public float tiempoSobrevivido = 0f;
    public float xpConseguida = 0f;

    private bool partidaActiva = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (partidaActiva)
        {
            tiempoSobrevivido += Time.deltaTime;
        }
    }

    public void SumarXP(float cantidad)
    {
        xpConseguida += cantidad;
    }

    public void JugadorDerrotado()
    {
        if (!partidaActiva) return;
        partidaActiva = false;

        // Desbloquea el ratón para poder pulsar botones en el Canvas
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(escenaDerrota);
    }

    // Se ejecuta automáticamente al entrar en la escena de Derrota
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == escenaDerrota)
        {
            GameObject objTiempo = GameObject.Find("TextoTiempo");
            GameObject objXP = GameObject.Find("TextoXP");

            if (objTiempo != null)
            {
                int minutos = Mathf.FloorToInt(tiempoSobrevivido / 60f);
                int segundos = Mathf.FloorToInt(tiempoSobrevivido % 60f);
                objTiempo.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}", minutos, segundos);
            }

            if (objXP != null)
            {
                objXP.GetComponent<TMP_Text>().text = Mathf.RoundToInt(xpConseguida) + " XP";
            }
        }
        else
        {
            // Si vuelves a jugar un nivel, reinicia los contadores
            tiempoSobrevivido = 0f;
            xpConseguida = 0f;
            partidaActiva = true;
        }
    }
}