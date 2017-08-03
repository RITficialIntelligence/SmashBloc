﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Paul Galatic
 * 
 * Commands a MobileUnit to attack another Unit. Longer aim times will be more
 * accurate, but as Units stop while they take aim, they will also be more 
 * vulnerable to enemy fire.
 * **/
public class ShootCommand : MobileThought
{

    Unit target;
    float maxAimTime;

    public ShootCommand(Unit target, float maxAimTime)
    {
        this.target = target;
        this.maxAimTime = maxAimTime;
    }

    public override void Act()
    {
        body.Shoot(target, maxAimTime);
    }
}