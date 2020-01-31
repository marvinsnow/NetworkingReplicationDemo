using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// just like Main() in C++
public class Gameplay : MonoBehaviour
{
	float startZPos = -8.0f;
	const float zInterval = 3.0f; // each client instance's z axis distance
	static public float xInterval = 3.0f;
	static public float yInterval = 4.0f;

	Server server;
	List<Client> clients;

	// Use this for initialization
	void Start()
	{
		// set up server
		server = new Server(startZPos);
		startZPos += yInterval;

		clients = new List<Client>();

		// add client #1
		Client client1 = new Client();
		client1.Init(0.5f, startZPos, KeyCode.D, KeyCode.A); // 500ms latency
		client1.ConnectTo(server);
		clients.Add(client1);
		startZPos += yInterval;

		// add client #2
		Client client2 = new Client();
		client2.Init(0.5f, startZPos, KeyCode.RightArrow, KeyCode.LeftArrow); // 0ms latency
		client2.ConnectTo(server);
		clients.Add(client2);
		startZPos += yInterval;

		// start the game
		server.Start();
	}
	
	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < clients.Count; ++i)
		{
			clients[i].Update();
		}

		server.Update();
	}
}
