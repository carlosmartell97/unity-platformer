﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol {

	private string name;

	public Symbol(string name){
		this.name = name;
	}

	public string Name {
		get {
			return this.name;
		}
	}
}
