using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text;

	private enum States
	{
		intro,
		cell,
		mirror,
		prisoner_0,
		prisoner_1,
		sheets,
		lock_0,
		cell_mirror,
		cell_hangar,
		sheets_1,
		lock_1,
		freedom,
		sheets_mirror,
		cell_hangar_mirror,
		lock_mirror
	};

	private States myState;
	private bool mirror = false;
	private bool hangar = false;

	// Use this for initialization
	void Start ()
	{
		myState = States.intro;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if (myState == States.intro)
			state_intro ();
		else if (myState == States.cell) {
			if (mirror && hangar)
				state_cell_mirror_hangar ();
			else if (mirror)
				state_cell_mirror ();
			else if (hangar)
				state_cell_hangar ();
		} else if (myState == States.mirror)
			state_mirror ();
		else if (myState == States.prisoner_0)
			state_prisoner_0 ();
		else if (myState == States.prisoner_1)
			state_prisoner_1 ();
		else if (myState == States.sheets) {
			if (hangar)
				state_sheets_hangar ();
			state_sheets ();
		} else if (myState == States.lock_0) {
			if (mirror && hangar)
				state_lock_mirror_hangar ();
			else if (mirror)
				state_lock_mirror ();
			else if (hangar)
				state_lock_hangar ();
			state_lock_0 ();
		}
		// cell mirror
		else if (myState == States.cell_hangar)
			state_cell_hangar ();
		// sheets 1
		// lock 1
		// freedom
		// sheets mirror
		// cell hangar mirror
		else if (myState == States.lock_mirror)
			state_lock_mirror ();
	}

	#region no_items

	void state_intro ()
	{
		text.text = "You wake up looking at gray, just gray. you look to the left and there are some " +
		"bars. Just outside of the bars is a light, which gives just enough light to see what it looks " +
		"like around you. You are laying on a very uncomfortable bed, and as you look around you realize " +
		"that you are in a cell.\n\n" +

		"Press Space to continue";
		if (Input.GetKeyDown (KeyCode.Space)) {
			myState = States.cell;
		}
	}

	void state_cell ()
	{
		text.text = "There are some dirty sheets on the bed, a mirror on the wall, a prisoner in the cell next to yours, " +
		"and the door is locked.\n\n" +
		"Press S to view Sheets, M to view Mirror, T to Talk to prisoner, and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S))
			myState = States.sheets;
		else if (Input.GetKeyDown (KeyCode.M))
			myState = States.mirror;
		else if (Input.GetKeyDown (KeyCode.T))
			myState = States.prisoner_0;
		else if (Input.GetKeyDown (KeyCode.L))
			myState = States.lock;
	}

	void state_lock_0 ()
	{
		text.text = "You mess with the lock a little and realize you aren't getting anywhere.\n\n " +
		"Press R to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
	}

	void state_mirror ()
	{
		text.text = "The mirror is just hanging on a nail in the wall. You can easily take the mirror, but it would be awkward to carry.\n\n " +
		"Press T to Take the mirror, R to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
		else if (Input.GetKeyDown (KeyCode.T))
			myState = States.cell_mirror;
	}

	void state_prisoner_0 ()
	{
		text.text = "You ask the prisoner next to you if he knows a way out.\nI\'ve tried everything, I once got out, but blew my only chance of escaping. \n\n " +
		"Press H to ask him how he got out, I to Ignore him";
		if (Input.GetKeyDown (KeyCode.H))
			myState = States.prisoner_1;
		else if (Input.GetKeyDown (KeyCode.I))
			myState = States.cell;
	}

	void state_sheets ()
	{
		text.text = "You check under the sheets and there is a metal hangar sitting under them, no wonder the bed was so unconfortable.\n\n " +
		"Press T to Take the hangar, R to Return to cell";
		if (Input.GetKeyDown (KeyCode.T))
			myState = States.cell_hangar;
		else if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
	}

	void state_prisoner_1 ()
	{
		text.text = "I got out because the person in your cell found a way out and helped me out. After that we split was and I never saw him again. \n\n " +
		"Press R to Return to cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
	}

	#endregion

	#region hangar, no mirror

	void state_cell_hangar ()
	{
		text.text = "Everything is the same, but now you have a hangar.\n\n" +
		"Press S to view Sheets, M to view Mirror, T to Talk to prisoner, and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S))
			myState = States.sheets;
		else if (Input.GetKeyDown (KeyCode.M))
			myState = States.mirror;
		else if (Input.GetKeyDown (KeyCode.T))
			myState = States.prisoner_0;
		else if (Input.GetKeyDown (KeyCode.L))
			myState = States.lock_0;
	}

	void state_sheets_hangar() {
		text.text = "There is nothing under the sheets.\n\n " +
			"R to Return to cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
	}

	void state_lock_hangar () {
		text.text = "You try picking the lock with the hangar, but you can't see the lock.\n\n " +
			"Press R to Return to your cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell;
	}

	#endregion

	#region mirror, no hangar

	void state_cell_mirror ()
	{
		text.text = "Everything is the same, but now you have a mirror.\n\n" +
		"Press S to view Sheets, T to Talk to prisoner, and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S))
			myState = States.sheets_mirror;
		else if (Input.GetKeyDown (KeyCode.T))
			myState = States.prisoner_0;
		else if (Input.GetKeyDown (KeyCode.L))
			myState = States.lock_mirror;
	}

	void state_lock_mirror ()
	{
		text.text = "You can see the lock but you have nothing to pick it with..\n\n" +
			"Press R to Return to cell";
		if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell_mirror;
	}

	void state_sheets_mirror() {
		text.text = "You check under the sheets and there is a metal hangar sitting under them, no wonder the bed was so unconfortable.\n\n " +
			"Press T to Take the hangar, R to Return to cell";
		if (Input.GetKeyDown (KeyCode.T))
			myState = States.cell_hangar_mirror;
		else if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell_mirror;
	}

	#endregion

	#region mirror hangar
	void state_cell_mirror_hangar () {
		text.text = "You feel like you are getting somewhere, but the lock is still there.\n\n" +
			"Press S to view Sheets, T to Talk to prisoner, and L to view Lock";
		if (Input.GetKeyDown (KeyCode.S))
			myState = States.sheets_mirror;
		else if (Input.GetKeyDown (KeyCode.T))
			myState = States.prisoner_0;
		else if (Input.GetKeyDown (KeyCode.L))
			myState = States.lock_mirror;
	}

	void state_lock_mirror_hangar () {
		text.text = "You hold up the mirror so that you can see the lock. You put the hangar in and with a little struggle you hear a click.\n " +
			"You find yourself in a hallway.\n\n" +
			"Press Space to continue";
		if (Input.GetKeyDown (KeyCode.T))
			myState = States.cell_hangar_mirror;
		else if (Input.GetKeyDown (KeyCode.R))
			myState = States.cell_mirror;
	}

	#endregion
}
