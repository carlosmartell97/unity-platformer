using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

	private string name;
	private Dictionary<Symbol,State> transitions;

	public State(string name){
		this.name = name;
		this.transitions = new Dictionary<Symbol, State> ();
	}

	public string Name{
		get{ return this.name; }
	}

	public Dictionary<Symbol,State> Transitions{
		get{ return this.transitions; }
	}

	public void AddNeighbor(Symbol key,State neighbor){
		this.transitions.Add(key,neighbor);
	}

	public State ApplySymbol(Symbol symbol){
		if(!transitions.ContainsKey(symbol)){
			return this;
		}
		return transitions[symbol];
	}
}
