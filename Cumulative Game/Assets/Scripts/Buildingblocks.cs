using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Collections.Specialized;


public class Buildingblocks : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    //public GameObject myText;
    private Vector3 Cubes;
    private Vector3 Txt;
    private float radius = 1;
    private int numCubes = 33;
    private static System.Random random = new System.Random(); 
    public static List<string> list_of_strings = new List<string>();
    //public static int CP;
    public static int CountParenthesis;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        CountParenthesis = 0;
        List<string> results = RandomString();
        int i = 0;
        while (numCubes > 0)
        {



            Cubes = new Vector3(UnityEngine.Random.Range(-9, 9), UnityEngine.Random.Range(1.2f, 1.2f), UnityEngine.Random.Range(-9, 9));

            if (Physics.CheckSphere(Cubes, radius))
            {
            }
            else
            {
                Instantiate(myPrefab, Cubes, Quaternion.identity);
                Txt = new Vector3(Cubes.x, Cubes.y + 1.3f, Cubes.z);
                myPrefab.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = results[i];
                i++;
                numCubes = numCubes - 1;
            }

        }

    }

    public static List<string> RandomString()
    {
        int x;
        List<string> list_of_strings = new List<string>();
        for (int i = 0; i <= 33; i++)
        {
            const string chars = "XM3()";
            x = UnityEngine.Random.Range(9, 15);
            string val = new string(Enumerable.Repeat(chars, x)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            list_of_strings.Add(val);


        }
        for (int i = 0; i < list_of_strings.Count; i++)
        {
            if (IsBalanced(list_of_strings[i]))
            {
                CountParenthesis = CountParenthesis + 1;
            }
        }
        List<string> test = createBalancedParenthesis(list_of_strings, CountParenthesis);

        return test;
    }

    public static List<string> createBalancedParenthesis(List<string> val, int count)
    {
        //int length_before;
        //int length_after;
        //int length_difference;
        //int brackets_count;
        string open_string;
        string close_string;
        int parenthesis_c;

        parenthesis_c = 11 - count;
        List<string> value = val;
        for (int i = 0; i < parenthesis_c; i++)
        {
            CountParenthesis = CountParenthesis + 1;
           // int length_before = 0;
            int length_after = 0;
            int length_difference = 0;
            int brackets_count = 0;
            open_string = "";
            close_string = "";

            int length_before = val[i].Length;
            val[i] = val[i].Replace("(", "").Replace(")", "");
            length_after = val[i].Length;
            length_difference = length_before - length_after;
            if (length_difference % 2 == 0)
            {
                brackets_count = length_difference / 2;
            }
            else
            {
                length_difference = length_difference + 1;
                brackets_count = length_difference / 2;

            }
            for (int j = 0; j < brackets_count; j++)
            {
                open_string = "(" + open_string;
                close_string = ")" + close_string;
            }
            val[i] = open_string + val[i] + close_string;

            //   string first = val[i].Substring(0, val[i].Length / 2);
            //   string second = val[i].Substring(val[i].Length / 2 + 1, val[i].Length - 1);

            value[i] = val[i];
        }
        return value;
    }

    public static bool IsBalanced(string input)
    {

        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' }
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // check if the character is one of the 'opening' brackets
                if (bracketPairs.Keys.Contains(c))
                {
                    // if yes, push to stack
                    brackets.Push(c);
                }
                else
                // check if the character is one of the 'closing' brackets
                    if (bracketPairs.Values.Contains(c))
                {
                    // check if the closing bracket matches the 'latest' 'opening' bracket
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        // if not, its an unbalanced string
                        return false;
                }
                else
                    // continue looking
                    continue;
            }
        }
        catch
        {
            // an exception will be caught in case a closing bracket is found, 
            // before any opening bracket.
            // that implies, the string is not balanced. Return false
            return false;
        }

        // Ensure all brackets are closed
        return brackets.Count() == 0 ? true : false;
    }
}
