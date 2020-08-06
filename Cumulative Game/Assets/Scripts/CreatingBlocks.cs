using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CreatingBlocks : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    //public GameObject myText;
    private Vector3 Cubes;
    private Vector3 Txt;
    private float radius = 1;
    private int numCubes = 10;
    private static System.Random random = new System.Random(); public static List<string> list_of_strings = new List<string>();
    public static int CP;
    
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        List<string> results = RandomString();
        int i = 0;
        while (numCubes > 0)
        {



            Cubes = new Vector3(UnityEngine.Random.Range(-9, 9), UnityEngine.Random.Range(1.2f , 1.2f), UnityEngine.Random.Range(-9, 9));

            if (Physics.CheckSphere(Cubes, radius))
            {
            }
            else
            {
                Instantiate(myPrefab, Cubes, Quaternion.identity);
                Txt = new Vector3(Cubes.x,Cubes.y+1.3f,Cubes.z);
                myPrefab.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = results[i]; i++;
                numCubes = numCubes - 1;
            }
            
        }

    }

 
   
    public static List<string> RandomString()
    {
        int x;
        List<string> list_of_strings = new List<string>();
        for (int i = 0; i <= 10; i++)
        {
            const string chars = "XM3";
            x = UnityEngine.Random.Range(9, 15);
            string val = new string(Enumerable.Repeat(chars, x)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            list_of_strings.Add(val);


        }
        List<string> test = createPalindrome(list_of_strings);

        return test;
    }



    public static List<string> createPalindrome(List<string> val)
    {
        List<string> value = val;
        CP = UnityEngine.Random.Range(3, 9);
       
        for (int i = 0; i < CP; i++)
        {

            string first = val[i].Substring(0, val[i].Length / 2);
            char[] arr = first.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            val[i] = first + temp;
            value[i] = val[i];

        }

        return value;
    }

}
