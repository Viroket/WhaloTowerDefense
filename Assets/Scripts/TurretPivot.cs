using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class TurretPivot : MonoBehaviour
{
    public float hoverColor;
    public Vector3 positionOffcet;
    private Renderer rend;
    private Behaviour halo;

    [Header("Optional")]
    public GameObject turret;

    private bool enteredShop = false;

    BuildManager buildManager;
    // public GameObject turretOptions;
    // public GameObject camera;

    private void Start()
    {
        // ShopScreen = GameObject.FindWithTag("Shop");
        buildManager = BuildManager.instance;
        halo = (Behaviour)gameObject.GetComponent("Halo");
        halo.enabled = false;
    }

    private void OnMouseDown()
    {
        enteredShop = true;
        // ShopScreen.transform.position = transform.position;
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("You cant build there - TODO dispay on screen");
            return;
        }
        // Debug.Log("Got the money: " + buildManager.GotTheMoney());
        // if (buildManager.GotTheMoney())
        // {
        //     gameObject.SetActive(false);
        // }
        // gameObject.SetActive(false);
        buildManager.BuildTurretOn(this, gameObject);
        

        // Instantiate(turretOptions, transform.position + positionOffcet, camera.transform.rotation);
        // gameObject.SetActive(false);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffcet;
    }

    private void OnMouseEnter()
    {
       if (!buildManager.CanBuild)
           return;
        halo.enabled = true;
    }

    private void OnMouseExit()
    {
        halo.enabled = false;
    }
}
