﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Proyecto26;
using System;
using UnityEngine;

public class FirebaseConnect : MonoBehaviour
{
    static string baseurl = "https://odyssey-80079.firebaseio.com";
    // Start is called before the first frame update
    //void Start()
    //{
    //    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://odyssey-80079.firebaseio.com/");
    //}

    //public DatabaseReference getDBReference()
    //{
    //    return FirebaseDatabase.DefaultInstance.RootReference;
    //}

    //public FirebaseDatabase getDB()
    //{
    //    return FirebaseDatabase.DefaultInstance;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public delegate void GetUserCallback(System.Object obj);
    public delegate void GetUserCallbackError(System.Object obj);

    public static void post(string child, object obj)
    {
        Debug.Log(baseurl + child + "/.json");
        try
        {
            RestClient.Post(baseurl + child + "/.json", obj).Then(response=>Debug.Log(response.ToString())).Catch(err => Debug.Log(err.Message)); ;
        }catch(Exception ex)
        {
            Debug.Log(ex.Message + " | " + ex.StackTrace);
        }
    }

    public static void put(string child, object obj)
    {
        RestClient.Put(baseurl + child + "/.json", obj);
    }

    public static void get<T>(string child, GetUserCallback callback)
    {
        RestClient.Get(baseurl + child + "/.json").Then(response =>
        {
            if (response.Text.Equals("null"))
            {
                callback(false);
            }
            else
            {
                callback(JsonUtility.FromJson<T>(response.Text));
            }
        });
    }

    public static void get(string child, GetUserCallback callback)
    {
        RestClient.Get(baseurl + child + "/.json").Then(response => {
            if (response.Text.Equals("null"))
            {
                callback(false);
            }
            else
            {
                callback(response.Text);
            }
        });
    }

    public static void get(string child, GetUserCallback callback, GetUserCallbackError callbackError)
    {
        RestClient.Get(baseurl + child + "/.json").Then(response => {
            if (response.Text.Equals("null"))
            {
                callback(false);
            }
            else
            {
                callback(response.Text);
            }
        }).Catch(err => callbackError(err.Message));
    }
}