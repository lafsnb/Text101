using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { intro, cell, mirror, prisoner, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
    private States myState;


	// Use this for initialization
	void Start () {
        myState = States.intro;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.intro)
            state_intro();
        else if (myState == States.cell)
            state_cell();
        else if (myState == States.lock_0)
            state_lock_0();
    }

    void state_intro ()
    {
        text.text = "You wake up looking at gray, just gray. you look to the left and there are some " +
                "bars. Just outside of the bars is a light, which gives just enough light to see what it looks " +
                "like around you. You are laying on a very uncomfortable bed, and as you look around you realize " +
                "that you are in a cell.\n\n" +

                "Press Space to continue";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.cell;
        }
    }

    void state_cell ()
    {
        text.text = "There are some dirty sheets on the bed, a mirror on the wall, a prisoner in the cell next to yours, " +
                "and the door is locked.\n\n" +
                "Press S to view Sheets, M to view Mirror, T to Talk to prisoner, and L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
            myState = States.sheets_0;
        else if (Input.GetKeyDown(KeyCode.M))
            myState = States.mirror;
        else if (Input.GetKeyDown(KeyCode.T))
            myState = States.prisoner;
        else if (Input.GetKeyDown(KeyCode.L))
            myState = States.lock_0;
    }

    void state_lock_0()
    {
        // you can carry on with this game in the future,
        // but right now I just made it for practice.
    }
}
