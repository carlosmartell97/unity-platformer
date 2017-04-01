using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

	public static List<Node> depthFirst(Node start,Node end){
		Stack<Node> work = new Stack<Node> ();
		List<Node> visited = new List<Node> ();
		work.Push (start);
		visited.Add (start);
		start.history = new List<Node> ();
		while(work.Count > 0){
			Node current = work.Pop ();
			if (current == end) {
				List<Node> result = current.history;
				result.Add (current);
				return result;
			} else {
				for(int i = 0; i < current.neighbors.Count; i++){
					Node currentChild = current.neighbors [i];
					if(!visited.Contains(currentChild)){
						work.Push (currentChild);
						visited.Add (currentChild);
						currentChild.history = new List<Node> (current.history);
						currentChild.history.Add (current);
					}
				}	
			}
		}
		// no available path
		return null;
	}

	public static List<Node> breathFirst(Node start,Node end){

		Queue<Node> work = new Queue<Node>();
		List<Node> visited = new List<Node>();

		work.Enqueue(start);
		visited.Add(start);
		start.history = new List<Node>();

		while(work.Count>0){
			Node current = work.Dequeue();
			if (current == end) {
				// path found!
				List<Node> result = current.history;
				result.Add(current);
				return result;
			} else {
				for(int i=0; i<current.neighbors.Count; i++){
					Node currentChild = current.neighbors[i];
					if(!visited.Contains(currentChild)){
						work.Enqueue(currentChild);
						visited.Add(currentChild);
						currentChild.history = new List<Node>(current.history);
						currentChild.history.Add(current);
					}
				}
			}
		}

		// no available path
		return null;
	}

	public static List<Node> aStar(Node start,Node end){
		List<Node> visited = new List<Node>();
		List<Node> work = new List<Node>();

		start.history = new List<Node> ();
		start.g = 0;
		start.h = Vector3.Distance (start.transform.position, end.transform.position);

		visited.Add(start);
		work.Add(start);

		while(work.Count>0){
			// get the current one
			Node current = work[0];
			for(int i=0; i<work.Count; i++){
				// check if answer is here
				if (work [i] == end) {
					//return path
					List<Node> result = work[i].history;
					result.Add(work[i]);
					return result;
				}
				if(work[i].F<current.F){
					current = work [i];
				}
			}
			work.Remove(current);

			// traverse children
			for(int i=0; i<current.neighbors.Count; i++){
				Node currentChild = current.neighbors [i];
				if(!visited.Contains(currentChild)){
					visited.Add(currentChild);
					currentChild.history = new List<Node>(current.history);
					currentChild.history.Add(current);

					// g - certain, accurate
					currentChild.g=current.g+Vector3.Distance(current.transform.position, currentChild.transform.position);

					// h -heuristic, educated guess
					currentChild.h=Vector3.Distance(currentChild.transform.position, end.transform.position);

					work.Add(currentChild);
				}
			}
		}

		return null;
	}
}
