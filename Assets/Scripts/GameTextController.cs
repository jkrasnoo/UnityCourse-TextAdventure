using UnityEngine;
using UnityEngine.UI;

public class GameTextController : MonoBehaviour
{
	
	public Text gameText;
	private enum States
	{
		bedroom, bathroom, door, tv, dresser, bedStand1, bedStand2
	}

	private enum DresserState
	{
		left, right, neither
	}

	public struct Rooms
	{
		public Rooms (
			bool bedroom,
			bool bathroom,
			bool door,
			bool tv,
			bool dresser,
			bool bedstand1,
			bool bedstand2
		) {
			this.bedroom   = bedroom;
			this.bathroom  = bathroom;
			this.door      = door;
			this.tv        = tv;
			this.dresser   = dresser;
			this.bedstand1 = bedstand1;
			this.bedstand2 = bedstand2;
		}
		public bool bedroom;

		public bool bathroom;

		public bool door;

		public bool tv;

		public bool dresser;

		public bool bedstand1;

		public bool bedstand2;

		public bool isAllDone()
		{
			return this.bedroom && this.bathroom && this.door && this.tv
					&& this.dresser && this.bedstand1 && this.bedstand2;
		}
	}

	private Rooms visitedRooms = new Rooms (
		false,
		false,
		false,
		false,
		false,
		false,
		false
	);
	
	private States gameState;
	private DresserState whichDresser;

	// Use this for initialization
	void Start ()
	{
		gameState = States.bedroom;
		whichDresser = DresserState.neither;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (gameState)
		{
			case States.bathroom:
			{
				bathroom();
				break;
			}

			case States.door:
			{
				door();
				break;
			}

			case States.tv:
			{
				tv();
				break;
			}

			case States.dresser:
			{
				dresser();
				break;
			}

			case States.bedStand1:
			{
				bedstand_1();
				break;
			}

			case States.bedStand2:
			{
				bedstand_2();
				break;
			}

			case States.bedroom:
			default:
			{
				bedroom();
				break;
			}
		}
	}
	
	void bedroom()
	{
		string startingText = "You wake up in a room. It's not just any room though. "
					        + "It looks like a hotel room. You're on a queen sized bed "
					        + "with decent sheets. To both sides of the bed you see a "
					        + "bed stand with a light on each one. In front of you there's "
					        + "a flat screen TV mounted on the wall above a dresser. "
					        + "You also see a bathroom and a door to the room, that "
					        + "should be an exit. The room appears to be your typical "
					        + "hotel room, or that's what it's decked out to be.\n\n"
					        + "Press B to go in to the bathroom.\n"
					        + "Press D to go to the door.\n"
					        + "Press T to inspect the Tv.\n"
					        + "Press R to inspect the dresser\n"
					        + "Press S to inspect the bed stand to the left of the bed.\n"
					        + "Press N to inspect the bed stand to the right of the bed.\n";

		string allVisitedText = "You sit back down on the bed looking around and wondering "
		                      + "what to do. You notice that there's a problem with "
							  + "the bed. Part of the metal frame is broken and a piece is "
							  + "sticking out. You think you can break off that piece and "
							  + "it would be usefull somehow to excape this wreched place. "
							  + "You manage to break off the metal piece and stick it in your pocket. \n\n"
							  + "Press D to go back to the door to inspect it.\n"
							  + "Press B to go back to the bathroom to inspect it.\n";

		gameText.text = (visitedRooms.isAllDone()) ? allVisitedText : startingText;
		
		visitedRooms.bedroom = true;

		if (visitedRooms.isAllDone())
		{
			if (Input.GetKeyDown(KeyCode.D))
			{
				gameState = States.door;
			}
			else if (Input.GetKeyDown(KeyCode.B))
			{
				gameState = States.bathroom;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.B))
			{
				gameState = States.bathroom;
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				gameState = States.door;
			}
			else if (Input.GetKeyDown(KeyCode.T))
			{
				gameState = States.tv;
			}
			else if (Input.GetKeyDown(KeyCode.R))
			{
				gameState = States.dresser;
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				gameState = States.bedStand1;
			}
			else if (Input.GetKeyDown(KeyCode.N))
			{
				gameState = States.bedStand2;
			}
		}
	}
	
	void bathroom()
	{
		string startingText = "You're in the bathroom. You see the typical shower, "
					        + "toilet, and sink you would expect in a hotel room. "
					        + "You have a toothbrush, toothpaste, soap, shampoo and "
					        + "gear to shave with. There also happens to be a poster "
					        + "on the wall. Other than that, there's nothing special "
					        + "about the bathroom.\n\n"
					        + "Press B to return to the bedroom.";

		string allVisitedText = "You've gone back to the bathroom to take another look ";
		gameText.text = (visitedRooms.isAllDone()) ? allVisitedText : startingText;
		
		visitedRooms.bathroom = true;
		if (Input.GetKeyDown(KeyCode.B))
		{
			gameState = States.bedroom;
		}
	}
	
	void door()
	{
		gameText.text = "You inspect the door. There's a heavy duty lock on it. "
		              + "You tried the handle and the door appears to be locked "
					  + "from the outside. You can't get out. This isn't a hotel "
					  + "room! This is some sort of prison, and you're stuck in it! "
					  + "You notice that there's a tray on the floor with a meal on it. "
					  + "It's dimsum, some sort of dumplings. The tray appears "
					  + "to have been pushed through a hole at the bottom of the "
					  + "door. You're not really interested in the food. Only how "
					  + "you got there. You certainly can't get out this way.\n\n"
					  + "Press R to return to the bed.";
		
		visitedRooms.door = true;
		if (Input.GetKeyDown(KeyCode.R))
		{
			gameState = States.bedroom;
		}	  
	}
	
	void tv()
	{
		gameText.text = "You inspect the tv. It's a nice flatscreen Tv. You "
					  + "turn it on and see a pretty woman doing a show about "
					  + "the Thigh Master. You ty the other channels, but nothing "
					  + "else is playing. You quickly grow bored of the show and "
					  + "turn it off. You wonder to yourself why the only show on "
					  + "the Tv is a scantilly clad woman showing off the Thigh "
					  + "Master.\n\n"
					  + "Press R to return to the bed.\n";
		
		visitedRooms.tv = true;
		if (Input.GetKeyDown(KeyCode.R))
		{
			gameState = States.bedroom;
		}
	}
	
	void dresser()
	{
		gameText.text = "You inspect the dresser and go through its drawers. There's "
					  + "nothing on top of the dresser. You look through the drawers "
					  + "and find they were at least nice enough to provide you with "
					  + "some generic sweats, t-shirts and socks to wear, all perfectly "
					  + "sized. Isn't that nice? Still, you find nothing of any use here. \n\n"
					  + "Press B to return to the bed.\n"
					  + "Press S to inspect the bedstand to the left of the bed.\n"
					  + "Press N to inspect the bedstand to the right of the bed.\n";

		visitedRooms.dresser = true;

		if (Input.GetKeyDown(KeyCode.B))
		{
			gameState = States.bedroom;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			gameState = States.bedStand1;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			gameState = States.bedStand2;
		}
	}
	
	void bedstand_1()
	{
		if (whichDresser == DresserState.neither)
		{
			whichDresser = DresserState.left;
		}

		string bedstandPlural = (whichDresser == DresserState.right) ? "also a" : "a";
		string bedstandMove = (whichDresser == DresserState.right) ? " too" : "";

		gameText.text = "You go over to the bedstand to the left of the bed. There's "
		              + bedstandPlural + " light on the stand. You tried to move it but it's bolted "
					  + "to the stand itself" + bedstandMove + ". Unfortunately, the only use it has is "
					  + "lighting up your life. You go through the drawer and find "
					  + "a bible and nothing else.\n\n"
					  + "Press B to return to the bed.\n"
					  + "Press N to inspect the bedstand on the right.\n";

		visitedRooms.bedstand1 = true;

		if (Input.GetKeyDown(KeyCode.B))
		{
			gameState = States.bedroom;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			gameState = States.bedStand2;
		}
	}
	
	void bedstand_2()
	{
		if (whichDresser == DresserState.neither)
		{
			whichDresser = DresserState.right;
		}

		string bedstandPlural = (whichDresser == DresserState.left) ? "also a" : "a";
		string bedstandMove = (whichDresser == DresserState.left) ? " too" : "";

		gameText.text = "You go over to the bedstand to the right of the bed. There's "
		              + bedstandPlural + " light on the stand. You tried to move it but "
					  + "it's bolted to the stand itself" + bedstandMove + ". Unfortunately, ";

		visitedRooms.bedstand2 = true;

		if (Input.GetKeyDown(KeyCode.B))
		{
			gameState = States.bedroom;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			gameState = States.bedStand1;
		}
	}
}
