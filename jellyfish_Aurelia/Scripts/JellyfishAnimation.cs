using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class JellyfishAnimation : MonoBehaviour {
    //public Material Material_in, Material_out;
    //in the editor this is what you would set as the object you want to change

    private Material material_in, material_out;
    private GameObject aurelia_in_child, aurelia_out_child;

    [SerializeField] private bool automaticSize = true;

    [Header("Jellyfish Color")]
    [SerializeField] private bool Green = true;
    [SerializeField] private bool White = false, Purple = false, Blue = false;

    private int randomNumber = 0;


    // Use this for initialization
    void Start () {
        
        // Random animation
        randomNumber = Random.Range(0, 4);
        Animator anim = GetComponent<Animator>();

        if (randomNumber == 0)
            anim.Play("swim_long_slow", -1, Random.Range(0f, 2f));

        else if (randomNumber == 1)
            anim.Play("swim_long_normal", -1, Random.Range(0f, 2f));

       else  if (randomNumber == 2)
            anim.Play("swim_normal", -1, Random.Range(0f, 2f));

        else if (randomNumber == 3 || randomNumber == 4)
            anim.Play("swim_slow", -1, Random.Range(0f, 2f));


        // Random Jelly fish size (scale)

        if (automaticSize == true)
        {
            randomNumber = Random.Range(20, 48);
            this.transform.localScale = Vector3.one * randomNumber;
        }

    }

    void Update()
    {
        // Update is called once per frame

        // If in editor mode
        if (!Application.isPlaying)
        {

            aurelia_in_child = this.transform.Find("aurelia_in").gameObject;
            aurelia_out_child = this.transform.Find("aurelia_out").gameObject;

            // Defaults to blue
            if ((Blue == true) || (Green == false && Blue == false && White == false && Purple == false))
            {
                material_in = Resources.Load("jellyfish_in__1K", typeof(Material)) as Material;
                material_out = Resources.Load("jellyfish_out__1K", typeof(Material)) as Material;
            }
            
            // Green Jellyfish
            else if (Green == true)
            {
                material_in = Resources.Load("jellyfish_in__1K green", typeof(Material)) as Material;
                material_out = Resources.Load("jellyfish_out__1K green", typeof(Material)) as Material;
            }

            // White Jellyfish
            else if (White == true)
            {
                material_in = Resources.Load("jellyfish_in__1K white", typeof(Material)) as Material;
                material_out = Resources.Load("jellyfish_out__1K white", typeof(Material)) as Material;
            }

            // Purple Jellyfish
            else if (Purple == true)
            {
                material_in = Resources.Load("jellyfish_in__1K purple", typeof(Material)) as Material;
                material_out = Resources.Load("jellyfish_out__1K purple", typeof(Material)) as Material;
            }

            aurelia_in_child.GetComponent<Renderer>().material = material_in;
            aurelia_out_child.GetComponent<Renderer>().material = material_out;
        }

    }
}
