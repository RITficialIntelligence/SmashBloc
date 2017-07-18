﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Paul Galatic
 * 
 * A struct that contains all relevant information denoting to which team a
 * unit or city belongs.
 * **/
public class Team {

    // The name of the team.
    public readonly string title;
    // The color, or "uniform," of the team.
    public readonly Color color;
    // The Players that make up the team.
    public readonly List<Player> members;
    // The mobile units owned by the team.
    public List<MobileUnit> mobiles;
    // The cities owned by the team.
    public List<City> cities;

    private bool active = true;
    /// <summary>
    /// Constructs a new Team.
    /// </summary>
    public Team (string title = "NULL", Color color = default(Color))
    {
        this.title = title;
        this.color = color;
        members = new List<Player>();
        mobiles = new List<MobileUnit>();
        cities = new List<City>();
    }

    public Team(string title, Color color, List<Player> members, List<MobileUnit> mobiles, List<City> cities)
    {
        this.title = title;
        this.color = color;
        this.members = members;
        this.mobiles = mobiles;
        this.cities = cities;
    }


    public void Activate()
    {
        foreach (Player p in members)
        {
            p.Activate();
        }

        active = true;
    }

    /// <summary>
    /// Kills all units in a team, returns all its cities, and deactivates
    /// all its members.
    /// </summary>
    public void Deactivate()
    {
        foreach (MobileUnit m in mobiles)
        {
            m.ForceKill();
        };
        foreach (City c in cities)
        {
            c.gameObject.SetActive(false);
            Toolbox.CityPool.Return(c);
        }
        foreach (Player p in members)
        {
            p.Deactivate();
        }

        mobiles.Clear();
        cities.Clear();

        active = false;

    }

    public bool IsActive
    {
        get { return active; }
    }

    public static bool operator ==(Team t1, Team t2)
    {
        return t1.Equals(t2);
    }

    public static bool operator !=(Team t1, Team t2)
    {
        return !(t1.Equals(t2));
    }

    public override bool Equals(object other) {
        if (!(other is Team)) { return false; }
        Team another = (Team)other;
        return (title == another.title) && (color == another.color);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}