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

    public readonly string title;
    public readonly Color color;

    public List<Unit> units;
    public List<City> cities;

    /// <summary>
    /// Constructs a new Team.
    /// </summary>
    /// <param name="owner">The owner of the team.</param>
    /// <param name="name">The name of the team.</param>
    /// <param name="color">The team's color.</param>
    public Team (string name = "NULL", Color color = default(Color))
    {
        this.title = name;
        this.color = color;
        units = new List<Unit>();
        cities = new List<City>();
    }

    public Team(string name, Color color, List<Unit> units, List<City> cities)
    {
        this.title = name;
        this.color = color;
        this.units = units;
        this.cities = cities;
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
