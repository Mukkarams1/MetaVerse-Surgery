using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    private float timerSciFi;
    public MeshRenderer mesh;
    public Color color;
    int run = 0;
    float aplha = 1;
    // Update is called once per frame
    void Update()
    {
        //if (timerSciFi > 1.2f)
        //    timerSciFi = 0;

        timerSciFi += Time.deltaTime / 10;

        Shader.SetGlobalFloat("_ShaderSciFi", timerSciFi);
        Shader.SetGlobalFloat("_ShaderDisplacement", timerSciFi);

        
        if (timerSciFi >= 0.35f && run == 0) 
        {
            shader2();
            run++;
            mesh.materials[1].shader = Shader.Find("Standard");
            mesh.materials[1].SetFloat("_Mode", 3);
            mesh.materials[1].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mesh.materials[1].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mesh.materials[1].SetInt("_ZWrite", 0);
            mesh.materials[1].DisableKeyword("_ALPHATEST_ON");
            mesh.materials[1].EnableKeyword("_ALPHABLEND_ON");
            mesh.materials[1].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mesh.materials[1].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

            Texture2D texture = Resources.Load<Texture2D>("Body");
            mesh.materials[1].mainTexture = texture;
            Color albedo = mesh.materials[1].GetColor("_Color");
            albedo.a = 1f;
            mesh.materials[1].SetColor("_Color", albedo);
            // StartCoroutine(SlowlyDesolveAlpha());
            mesh.materials[1].SetColor("_Color", color);
            mesh.materials[1].SetColor("_EmissionColor", Color.HSVToRGB(181, 44, 52));
            
        }

        IEnumerator SlowlyDesolveAlpha()
        {
            for(int i = 0; i < 500; i++)
            {
                yield return new WaitForSeconds(2f/500);
                aplha -=  0.05f/50f;
                Color albedo = mesh.materials[1].GetColor("_Color");
                albedo.a = aplha;
                mesh.materials[1].SetColor("_Color", albedo);
            }
            
        }

        void shader2()
        {
            mesh.materials[0].shader = Shader.Find("Standard");
            mesh.materials[0].SetFloat("_Mode", 3);
            mesh.materials[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mesh.materials[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mesh.materials[0].SetInt("_ZWrite", 0);
            mesh.materials[0].DisableKeyword("_ALPHATEST_ON");
            mesh.materials[0].EnableKeyword("_ALPHABLEND_ON");
            mesh.materials[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mesh.materials[0].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

            Texture2D texture = Resources.Load<Texture2D>("Body");
            mesh.materials[0].mainTexture = texture;
            Color albedo = mesh.materials[1].GetColor("_Color");
            albedo.a = 1f;
            mesh.materials[0].SetColor("_Color", albedo);
            // StartCoroutine(SlowlyDesolveAlpha());
            mesh.materials[0].SetColor("_Color", color);
            mesh.materials[0].SetColor("_EmissionColor", Color.HSVToRGB(181, 44, 52));
        }
       
    }
}
