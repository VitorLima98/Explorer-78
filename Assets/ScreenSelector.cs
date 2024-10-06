using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngineInternal;
public class ScreenSelector : MonoBehaviour
{

    public List<GameObject> Ui;
    public List<GameObject> monitores;
    public RaycastHit hit;
    public LayerMask mask;
    public Controls controles;
    public Vector2 MousePost;
    public GameObject origin;
    public bool isclicked;
    public Animator anim;

    private void Awake()
    {
        controles = new Controls();
        controles.PlayerFirstPerson.Enable();
        controles.PlayerFirstPerson.Look.performed += ctx => MousePost = ctx.ReadValue<Vector2>();
        controles.PlayerFirstPerson.Interact.performed += ctx => isclicked = true;
        controles.PlayerFirstPerson.Interact.canceled += ctx => isclicked = false;
    }

    void Update()
    {
        // Cria um raio baseado na posição do mouse
        Ray ray = Camera.main.ScreenPointToRay(MousePost);
        if (GameManager.instance.tableopen == false)
        {
            // Verifica se o raio atinge algo na camada definida
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                // Debug para mostrar o nome do objeto atingido
                Debug.Log("Hit: " + hit.transform.name);
                if (isclicked)
                {
                    int index = hit.transform.GetComponent<MyIndex>().i;
                    switch (index)
                    {

                        case 0:
                            anim.SetBool("trigger1", true);
                            desativacolisores(false);
                            break;
                        case 1:
                            anim.SetBool("trigger2", true);
                            desativacolisores(false);
                            break;
                        case 2:
                            anim.SetBool("trigger3", true);
                            desativacolisores(false);
                            break;
                    }
                }
            }
        }
        // Desenha o raio no editor para visualização
        Debug.DrawRay(origin.transform.position, ray.direction * 100, Color.red);
    }
    public void clickedui(int index)
    {
        Ui[index].SetActive(true);
    }
    public void desativacolisores(bool status)
    {
       
        for(int i = 0; i < 2; i++)
        {
            monitores[i].SetActive(status);
        }
  
    }
    public void desactiveui(int index)
    {
        switch (index)
        { 
            case 0:
                anim.SetBool("trigger1", false);
           
                isclicked = false;
                desativacolisores(true);
                Ui[index].SetActive(false);
                break;
            case 1:
                anim.SetBool("trigger2", false);
                Ui[index].SetActive(false);
                isclicked = false;
                desativacolisores(true);
                Ui[index].SetActive(false);
                break;
            case 2:
                anim.SetBool("trigger3", false);
                isclicked = false;
                Ui[index].SetActive(false);
                desativacolisores(true);
                Ui[index].SetActive(false);
                break;
        }
        
    }
}
