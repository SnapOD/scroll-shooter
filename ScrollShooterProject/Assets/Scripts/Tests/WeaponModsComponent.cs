using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModsComponent : MonoBehaviour
{
    public AutomaticShooting automaticShooting;
    public SniperShooting sniperShooting;
    public ShotgunShooting shotgunShooting;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateAutomatic()
    {
        DisableSniper();
        DisableShotgun();
        automaticShooting.enabled = true;
    }
    void DisableAutomatic() { automaticShooting.enabled = false; }

    public void ActivateSniper()
    {
        DisableAutomatic();
        DisableShotgun();
        sniperShooting.enabled = true;
    }
    void DisableSniper() { sniperShooting.enabled = false; }

    public void ActivateShotgun()
    {
        DisableSniper();
        DisableAutomatic();
        shotgunShooting.enabled = true;
    }
    void DisableShotgun() { shotgunShooting.enabled = false; }

}
