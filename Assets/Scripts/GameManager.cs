using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Planet[] planets;
    private Star[] stars;
    private Player player;

    private Planet activePlanet;

	// Use this for initialization
	void Awake () {
        updatePlanetsAndStars();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void updatePlanetsAndStars()
    {
        // Planets
        GameObject[] planetGOs = GameObject.FindGameObjectsWithTag("Planet");
        planets = new Planet[planetGOs.Length];

        for (int i = 0; i < planetGOs.Length; i++)
        {
            planets[i] = planetGOs[i].GetComponent<Planet>();
        }

        // Set activePlanet to the planet the player currently is on
        activePlanet = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Planet>();

        // Stars
        GameObject[] starGOs = GameObject.FindGameObjectsWithTag("Star");
        stars = new Star[starGOs.Length];

        for (int i = 0; i < starGOs.Length; i++)
        {
            stars[i] = starGOs[i].GetComponent<Star>();
        }
    }

    public Player getPlayer()
    {
        if (!player) player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        return player;
    }

    public Planet[] getPlanets()
    {
        return planets;
    }

    public Planet getActivePlanet()
    {
        return activePlanet;
    }

    public Star[] getStars()
    {
        return stars;
    }

    public static GameManager getGameManager()
    {
        return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
}
