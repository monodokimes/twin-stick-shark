﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour, IAgent {
    
    public Weapon weapon {
        get {
            return _mount.currentWeapon;
        }
    }
    public bool isShielded {
        get {
            return _shield != null;
        }
    }
    public IAgentController controller {
        get {
            return _input;
        }
    }

    private PlayerInput _input;
    private WeaponMount _mount;
    private Shield _shield;

    void Awake() {
        _mount = GetComponentInChildren<WeaponMount>();
    }

    void Start() {
        _input = GameObject.FindGameObjectWithTag(GameTags.Input).GetComponent<PlayerInput>();
    }
    
    public void PowerupWeapon(GameObject weapon, int shots) {
        _mount.SetPowerupWeapon(weapon, shots);
    }

    public void SetShield(Shield shield) {
        _shield = shield;
    }

    public void DestroyShield() {
        Destroy(_shield.gameObject);
        _shield = null;
    }
}
