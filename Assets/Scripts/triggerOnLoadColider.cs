using System;
using UnityEngine;

public class triggerOnLoadColider : MonoBehaviour
{
    public BoxCollider myCollide;

    public BoxCollider myCollideTrigger;
    public Color color;
    private bool beBlue;

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        myCollideTrigger = GetComponents<BoxCollider>()[0];
        myCollide = GetComponents<BoxCollider>()[1];
        myCollide.enabled = false;
        setColor();
        setTexture();
    }

    private void setTexture()
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void setColor()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", beBlue ? Color.blue : Color.white);
    }


    private void OnTriggerEnter(Collider other)
    {
        beBlue = true;
        setColor();        
    }

    private void OnTriggerExit(Collider other)
    {
        beBlue = false;
        setColor();
    }
    void onCollisionEnter(GameObject other)
    {
        
    }
}
