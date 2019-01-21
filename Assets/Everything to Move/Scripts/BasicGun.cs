using System.Collections;
using System.Collections.Generic;
using Segritude.Interaction;
using Segritude.Inventory.Items;
using UnityEngine;

public class BasicGun : InteractableItemBehaviour
{

    public Gun gun => base.Item as Gun;

    public int Clip;
    public Camera fpsCam;
    public GameObject Barrel;
    public bool isReloading;

    protected override InteractionType InteractionTypes => InteractionType.Left;

    protected override float InteractionTime => gun.FireRate;

    protected override bool ImidiateInteraction => true;

    protected override bool RepeatInteraction => gun.Automatic;
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && Clip < gun.MaxClip)
        {
            if (Clip < gun.MaxClip)
            {
                Reload();
            }
        }

    }

    void Reload()
    {
        Clip = gun.MaxClip;
        Debug.Log("Clip: " + Clip);
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 forward = fpsCam.transform.TransformDirection(Vector3.forward) * gun.Range;
        Debug.DrawRay(Barrel.transform.position, forward, Color.red);



        if (Physics.Raycast(Barrel.transform.position, fpsCam.transform.forward, out hit, gun.Range))
        {
            Debug.Log(hit.transform.name);

            Damage target = hit.transform.GetComponent<Damage>();
            if (target != null)
            {
                target.TakeDamage(gun.Damage);
            }
        }
        
    }

    public override void OnInteract(InteractionType type)
    {
        Debug.Log(type);
        Shoot();
    }

    public override void OnSelectItem()
    {
        base.OnSelectItem();
        Clip = gun.MaxClip;
    }

    public override bool ValidateInteraction(InteractionType type)
    {
        Debug.Log(type);
        return base.ValidateInteraction(type) && !isReloading;
    }
}
