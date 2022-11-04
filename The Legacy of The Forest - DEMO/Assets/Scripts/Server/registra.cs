using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class registra : MonoBehaviour
{
   // public Response jsonObject = new Response();

    // Start is called before the first frame update
    void Start()
    {
        //string str = PlayerPrefs.GetString("triviascargadas");
        //Debug.Log(str);
        //if (str != "")
        //{
        //    SceneManager.LoadScene(1);



        //}
    }
    TMP_InputField _inputFieldnombre;
    public TextMeshProUGUI textDisplay;

    public InfoPartida infoPartida;
    public string _final;
    public float _decisiones;
    public int _dinero;
    // Update is called once per frame
    void Update()
    {
        
    }

   public void registranuevousuario()
    {
        StartCoroutine(Upload());


    }
    private IEnumerator Upload()
    {
        //var input = gameObject.GetComponent<InputField>();

        //GameObject myCube = GameObject.Find("InputField").GetComponent<GameObject>();
        //Debug.Log(myCube.GetComponent<InputField>().text);
        _inputFieldnombre = GameObject.Find("nombre").GetComponent<TMP_InputField>();
        _final = infoPartida.final;
        _decisiones = infoPartida.decisiones;
        _dinero = infoPartida.dinero;

        if ( _inputFieldnombre.text != "" )
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("ope", "1"));
            //formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));
            //string param = "{'username':'aaa','app_key':'webGLTesting','password':'aaa'}";

            WWWForm form = new WWWForm();
            form.AddField("NOMBRE", _inputFieldnombre.text);
            form.AddField("FINAL", _final);
            form.AddField("DECISIONES", _decisiones.ToString());
            form.AddField("DINERO", _dinero);

            UnityWebRequest www = UnityWebRequest.Post("https://thelegacyoftheforest.herokuapp.com//api/newproduct", form);
         //   UnityWebRequest www = UnityWebRequest.Post("http://localhost:52910/api/Home", form);
        
            // www.SetRequestHeader("content-type", "application/json");
            www.SetRequestHeader("accept", "application/json");
            www.SetRequestHeader("Content-Type", "application/json");
            var asyncOperation = www.SendWebRequest();
            textDisplay.text = "Cargando";
            var contador = 0;
            while (!asyncOperation.isDone)
            {
                contador++;
                if (contador % 11 != 0)
                {
                    textDisplay.text += ".";
                }
                else
                {
                    textDisplay.text = "Cargando";
                }
                // wherever you want to show the progress:

                float progress = www.downloadProgress;
                Debug.Log("Cargando " + progress);
                yield return null;
            }

            while (!www.isDone)
                yield return null; // this worked for me
                                   // print(www.downloadHandler.text);s

            //  Debug.Log(jsonObject.TRIVIAS_ASIGNADAS1.ToString());

            //yield return www.SendWebRequest();
            //Debug.Log(www.GetResponseHeaders());
            //if (www.result != UnityWebRequest.Result.Success)
            //{
            //    Debug.Log(www.error);
            //}
            //else
            //{
            //    var textorespuesta = www.downloadHandler.ToString();

            //    Debug.Log("Form upload complete!");
            //    Debug.Log(textorespuesta);
            //}
        }
        else
        {
            textDisplay.text = "Debe rellenar todos los campos del registro";

        }
    }
}
