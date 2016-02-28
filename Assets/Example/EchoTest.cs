﻿using UnityEngine;
using System.Collections;
using System;

public class EchoTest : MonoBehaviour {
    public static WebSocket w;

    // Use this for initialization
    IEnumerator Start () {
		w = new WebSocket(new Uri("ws://echo.websocket.org"));
		yield return StartCoroutine(w.Connect());
		w.SendString("WebSocket initialized.");
		int i=0;
		while (true)
		{
			string reply = w.RecvString();
			if (reply != null)
			{
				Debug.Log ("Received: "+reply);
			}
			if (w.error != null)
			{
				Debug.LogError ("Error: "+w.error);
				break;
			}
			yield return 0;
		}
		w.Close();
	}
}
