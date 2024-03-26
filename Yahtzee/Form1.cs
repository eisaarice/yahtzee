using System;
using System.DirectoryServices;
using static Yahtzee.Form1.YAHTZEE;

namespace Yahtzee {
    public partial class Form1 : Form {
        // main class to hold data
        public class YAHTZEE {
            // six die
            public class Dice {
                // dice value
                public int one = 1;
                public int two = 2;
                public int three = 3;
                public int four = 4;
                public int five = 5;

                // temp lock
                public bool dice1IsLocked = false;
                public bool dice2IsLocked = false;
                public bool dice3IsLocked = false;
                public bool dice4IsLocked = false;
                public bool dice5IsLocked = false;

                // perma lock, after rolling
                public bool dice1PermaLock = false;
                public bool dice2PermaLock = false;
                public bool dice3PermaLock = false;
                public bool dice4PermaLock = false;
                public bool dice5PermaLock = false;
            }

            // scorecharts
            public class Player {
                public int rolls = 2;
                public bool hasRolled = false;

                public class Scores {
                    public int ones = 0;
                    public int twos = 0;
                    public int threes = 0;
                    public int fours = 0;
                    public int fives = 0;
                    public int sixes = 0;

                    public int sum = 0;
                    public int bonus = 0;

                    public int threeOfAKind = 0;
                    public int fourOfAKind = 0;
                    public int fullHouse = 0;
                    public int smallStraight = 0;
                    public int largeStraight = 0;
                    public int chance = 0;
                    public int yahtzee = 0;

                    public int total = 0;

                    public bool onesLocked = false;
                    public bool twosLocked = false;
                    public bool threesLocked = false;
                    public bool foursLocked = false;
                    public bool fivesLocked = false;
                    public bool sixesLocked = false;

                    public bool threeOfAKindLocked = false;
                    public bool fourOfAKindLocked = false;
                    public bool fullHouseLocked = false;
                    public bool smallStraightLocked = false;
                    public bool largeStraightLocked = false;
                    public bool chanceLocked = false;
                    public bool yahtzeeLocked = false;

                    public bool onesCalculated = false;
                    public bool twosCalculated = false;
                    public bool threesCalculated = false;
                    public bool foursCalculated = false;
                    public bool fivesCalculated = false;
                    public bool sixesCalculated = false;
                }

                public Scores scores = new Scores();
            }

            // true for P1, false for P2
            public bool currentPlayerTurn = true;

            public Dice dice = new Dice();
            public Player player1 = new Player();
            public Player player2 = new Player();
        }

        public Form1() {
            InitializeComponent();
        }

        // GLOBALS
        private YAHTZEE yaht = new YAHTZEE();
        const int DICE_MOVE_DIST = 520;
        const int DICE_ROLL_MOVE_DIST = 625;
        const int ROLLS_LABEL_MOVE_DIST = 710;
        const int BONUS = 35;

        // GAME FUNCTIONALITY BELOW
        private void diceClick(object sender, EventArgs e) {
            // make sure player has rolled the dice before locking them in
            if (yaht.currentPlayerTurn == true && yaht.player1.hasRolled == true) {
                if (sender is Control clickedDice) {
                    int index = Convert.ToInt32(clickedDice.Tag);

                    if (index == 1) {
                        // flip lock to opposite
                        yaht.dice.dice1IsLocked = !yaht.dice.dice1IsLocked;

                        // cannot be perma locked
                        if (!yaht.dice.dice1PermaLock) {
                            if (yaht.dice.dice1IsLocked) {
                                dice1.BackColor = Color.LightGray;
                            }
                            else {
                                dice1.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 2) {
                        // flip lock to opposite
                        yaht.dice.dice2IsLocked = !yaht.dice.dice2IsLocked;

                        if (!yaht.dice.dice2PermaLock) {
                            if (yaht.dice.dice2IsLocked) {
                                dice2.BackColor = Color.LightGray;
                            }
                            else {
                                dice2.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 3) {
                        // flip lock to opposite
                        yaht.dice.dice3IsLocked = !yaht.dice.dice3IsLocked;

                        if (!yaht.dice.dice3PermaLock) {
                            if (yaht.dice.dice3IsLocked) {
                                dice3.BackColor = Color.LightGray;
                            }
                            else {
                                dice3.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 4) {
                        // flip lock to opposite
                        yaht.dice.dice4IsLocked = !yaht.dice.dice4IsLocked;

                        if (!yaht.dice.dice4PermaLock) {
                            if (yaht.dice.dice4IsLocked) {
                                dice4.BackColor = Color.LightGray;
                            }
                            else {
                                dice4.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 5) {
                        // flip lock to opposite
                        yaht.dice.dice5IsLocked = !yaht.dice.dice5IsLocked;

                        if (!yaht.dice.dice5PermaLock) {
                            if (yaht.dice.dice5IsLocked) {
                                dice5.BackColor = Color.LightGray;
                            }
                            else {
                                dice5.BackColor = Color.White;
                            }
                        }
                    }
                }

            }
            else if (yaht.currentPlayerTurn == false && yaht.player2.hasRolled == true) {
                if (sender is Control clickedDice) {
                    int index = Convert.ToInt32(clickedDice.Tag);

                    if (index == 1) {
                        // flip lock to opposite
                        yaht.dice.dice1IsLocked = !yaht.dice.dice1IsLocked;

                        // cannot be perma locked
                        if (!yaht.dice.dice1PermaLock) {
                            if (yaht.dice.dice1IsLocked) {
                                dice1.BackColor = Color.LightGray;
                            }
                            else {
                                dice1.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 2) {
                        // flip lock to opposite
                        yaht.dice.dice2IsLocked = !yaht.dice.dice2IsLocked;

                        if (!yaht.dice.dice2PermaLock) {
                            if (yaht.dice.dice2IsLocked) {
                                dice2.BackColor = Color.LightGray;
                            }
                            else {
                                dice2.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 3) {
                        // flip lock to opposite
                        yaht.dice.dice3IsLocked = !yaht.dice.dice3IsLocked;

                        if (!yaht.dice.dice3PermaLock) {
                            if (yaht.dice.dice3IsLocked) {
                                dice3.BackColor = Color.LightGray;
                            }
                            else {
                                dice3.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 4) {
                        // flip lock to opposite
                        yaht.dice.dice4IsLocked = !yaht.dice.dice4IsLocked;

                        if (!yaht.dice.dice4PermaLock) {
                            if (yaht.dice.dice4IsLocked) {
                                dice4.BackColor = Color.LightGray;
                            }
                            else {
                                dice4.BackColor = Color.White;
                            }
                        }
                    }
                    else if (index == 5) {
                        // flip lock to opposite
                        yaht.dice.dice5IsLocked = !yaht.dice.dice5IsLocked;

                        if (!yaht.dice.dice5PermaLock) {
                            if (yaht.dice.dice5IsLocked) {
                                dice5.BackColor = Color.LightGray;
                            }
                            else {
                                dice5.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void rollDice(object sender, EventArgs e) {
            Random rnd = new Random();

            if (!yaht.dice.dice1IsLocked && !yaht.dice.dice1PermaLock) {
                yaht.dice.one = rnd.Next(1, 7);

                dice1.Text = $"{yaht.dice.one}";
            }

            if (!yaht.dice.dice2IsLocked && !yaht.dice.dice2PermaLock) {
                yaht.dice.two = rnd.Next(1, 7);

                dice2.Text = $"{yaht.dice.two}";
            }

            if (!yaht.dice.dice3IsLocked && !yaht.dice.dice3PermaLock) {
                yaht.dice.three = rnd.Next(1, 7);

                dice3.Text = $"{yaht.dice.three}";
            }

            if (!yaht.dice.dice4IsLocked && !yaht.dice.dice4PermaLock) {
                yaht.dice.four = rnd.Next(1, 7);

                dice4.Text = $"{yaht.dice.four}";
            }

            if (!yaht.dice.dice5IsLocked && !yaht.dice.dice5PermaLock) {
                yaht.dice.five = rnd.Next(1, 7);

                dice5.Text = $"{yaht.dice.five}";
            }

            // current turn handling and calculations
            handleTurns();

            checkSingles();
        }

        private void handleTurns() {
            if (yaht.currentPlayerTurn == true && yaht.player1.rolls > -1) { // P1 turn
                if (yaht.player1.rolls == 0) { // player has to choose a spot
                    rollsLeftValueLabel.Text = "0";

                    lockAll();
                }
                else {
                    yaht.player1.rolls -= 1;

                    int.TryParse(rollsLeftValueLabel.Text, out int x);
                    x -= 1;

                    rollsLeftValueLabel.Text = $"{x}";
                }

                yaht.player1.hasRolled = true;

            }
            else if (yaht.currentPlayerTurn == false && yaht.player2.rolls > -1) { //P2 turn
                if (yaht.player2.rolls == 0) { // player has to choose a spot
                    rollsLeftValueLabel.Text = "0";

                    lockAll();
                }
                else {
                    yaht.player2.rolls -= 1;

                    int.TryParse(rollsLeftValueLabel.Text, out int x);
                    x -= 1;

                    rollsLeftValueLabel.Text = $"{x}";
                }

                yaht.player2.hasRolled = true;
            }
            else { // swap turns
                yaht.currentPlayerTurn = !yaht.currentPlayerTurn;

                moveElements();
                resetValues();
            }
        }

        private void swapTurns() {
            // turn swap after decision is made
            if (yaht.currentPlayerTurn) {
                yaht.player1.rolls = -1;
            }
            else {
                yaht.player2.rolls = -1;
            }

            checkBonus();
            handleTurns();
        }

        private void moveElements() {
            if (yaht.currentPlayerTurn == true) {
                yaht.player1.rolls = 2;
                rollsLeftValueLabel.Text = "3";

                // move everything down
                dice1.Location = new System.Drawing.Point(dice1.Location.X, dice1.Location.Y - DICE_MOVE_DIST);
                dice2.Location = new System.Drawing.Point(dice2.Location.X, dice2.Location.Y - DICE_MOVE_DIST);
                dice3.Location = new System.Drawing.Point(dice3.Location.X, dice3.Location.Y - DICE_MOVE_DIST);
                dice4.Location = new System.Drawing.Point(dice4.Location.X, dice4.Location.Y - DICE_MOVE_DIST);
                dice5.Location = new System.Drawing.Point(dice5.Location.X, dice5.Location.Y - DICE_MOVE_DIST);

                diceRollButton.Location = new System.Drawing.Point(diceRollButton.Location.X, diceRollButton.Location.Y - DICE_ROLL_MOVE_DIST);


                rollsLeftLabel.Location = new System.Drawing.Point(rollsLeftLabel.Location.X, rollsLeftLabel.Location.Y - ROLLS_LABEL_MOVE_DIST);
                rollsLeftValueLabel.Location = new System.Drawing.Point(rollsLeftValueLabel.Location.X, rollsLeftValueLabel.Location.Y - ROLLS_LABEL_MOVE_DIST);
            }
            else {
                yaht.player2.rolls = 2;
                rollsLeftValueLabel.Text = "3";

                // move everything up
                dice1.Location = new System.Drawing.Point(dice1.Location.X, dice1.Location.Y + DICE_MOVE_DIST);
                dice2.Location = new System.Drawing.Point(dice2.Location.X, dice2.Location.Y + DICE_MOVE_DIST);
                dice3.Location = new System.Drawing.Point(dice3.Location.X, dice3.Location.Y + DICE_MOVE_DIST);
                dice4.Location = new System.Drawing.Point(dice4.Location.X, dice4.Location.Y + DICE_MOVE_DIST);
                dice5.Location = new System.Drawing.Point(dice5.Location.X, dice5.Location.Y + DICE_MOVE_DIST);

                diceRollButton.Location = new System.Drawing.Point(diceRollButton.Location.X, diceRollButton.Location.Y + DICE_ROLL_MOVE_DIST);

                rollsLeftLabel.Location = new System.Drawing.Point(rollsLeftLabel.Location.X, rollsLeftLabel.Location.Y + ROLLS_LABEL_MOVE_DIST);
                rollsLeftValueLabel.Location = new System.Drawing.Point(rollsLeftValueLabel.Location.X, rollsLeftValueLabel.Location.Y + ROLLS_LABEL_MOVE_DIST);
            }
        }

        private void lockAll() {
            // turn on perma locks
            yaht.dice.dice1IsLocked = true;
            yaht.dice.dice2IsLocked = true;
            yaht.dice.dice3IsLocked = true;
            yaht.dice.dice4IsLocked = true;
            yaht.dice.dice5IsLocked = true;

            // turn on locks
            yaht.dice.dice1PermaLock = true;
            yaht.dice.dice2PermaLock = true;
            yaht.dice.dice3PermaLock = true;
            yaht.dice.dice4PermaLock = true;
            yaht.dice.dice5PermaLock = true;

            // darken all background colors
            dice1.BackColor = Color.DarkGray;
            dice2.BackColor = Color.DarkGray;
            dice3.BackColor = Color.DarkGray;
            dice4.BackColor = Color.DarkGray;
            dice5.BackColor = Color.DarkGray;
        }

        private void resetValues() {
            yaht.player1.rolls = 2;
            yaht.player2.rolls = 2;

            // turn off perma locks
            yaht.dice.dice1IsLocked = false;
            yaht.dice.dice2IsLocked = false;
            yaht.dice.dice3IsLocked = false;
            yaht.dice.dice4IsLocked = false;
            yaht.dice.dice5IsLocked = false;

            // turn off locks
            yaht.dice.dice1PermaLock = false;
            yaht.dice.dice2PermaLock = false;
            yaht.dice.dice3PermaLock = false;
            yaht.dice.dice4PermaLock = false;
            yaht.dice.dice5PermaLock = false;

            // reset dice background colors
            dice1.BackColor = Color.White;
            dice2.BackColor = Color.White;
            dice3.BackColor = Color.White;
            dice4.BackColor = Color.White;
            dice5.BackColor = Color.White;

            // reset rolled satii
            yaht.player1.hasRolled = false;
            yaht.player2.hasRolled = false;
        }

        private void selectSpotP1(object sender, MouseEventArgs e) {
            // make sure its P1 turn
            if (yaht.currentPlayerTurn && yaht.player1.hasRolled == true) {
                // check which box called function
                if (sender is Control clickedBox) {
                    int index = Convert.ToInt32(clickedBox.Tag);

                    if (index == 1 && yaht.player1.scores.onesLocked == false) { // ones
                        int.TryParse(onesP1.Text, out int x);
                        onesP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.onesLocked = true;
                        onesP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.onesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 2 && yaht.player1.scores.twosLocked == false) { // twos
                        int.TryParse(twosP1.Text, out int x);
                        twosP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.twosLocked = true;
                        twosP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.twosCalculated = true;
                        swapTurns();
                    }
                    else if (index == 3 && yaht.player1.scores.threesLocked == false) { // threes
                        int.TryParse(threesP1.Text, out int x);
                        threesP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.threesLocked = true;
                        threesP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.threesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 4 && yaht.player1.scores.foursLocked == false) { // fours
                        int.TryParse(foursP1.Text, out int x);
                        foursP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.foursLocked = true;
                        foursP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.foursCalculated = true;
                        swapTurns();
                    }
                    else if (index == 5 && yaht.player1.scores.fivesLocked == false) { // fives
                        int.TryParse(fivesP1.Text, out int x);
                        fivesP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.fivesLocked = true;
                        fivesP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.fivesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 6 && yaht.player1.scores.sixesLocked == false) { // sixes
                        int.TryParse(sixesP1.Text, out int x);
                        sixesP1.Text = $"{x}";

                        yaht.player1.scores.sum += x;
                        sumP1.Text = $"{yaht.player1.scores.sum}";

                        yaht.player1.scores.sixesLocked = true;
                        sixesP1.BackColor = Color.DarkGray;

                        yaht.player1.scores.sixesCalculated = true;
                        swapTurns();
                    }
                }
            }
        }

        private void selectSpotP2(object sender, MouseEventArgs e) {
            // make sure its P2 turn
            if (!yaht.currentPlayerTurn && yaht.player2.hasRolled == true) {
                // check which box called function
                if (sender is Control clickedBox) {
                    int index = Convert.ToInt32(clickedBox.Tag);

                    if (index == 1 && yaht.player2.scores.onesLocked == false) { // ones
                        int.TryParse(onesP2.Text, out int x);
                        onesP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.onesLocked = true;
                        onesP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.onesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 2 && yaht.player2.scores.twosLocked == false) { // twos
                        int.TryParse(twosP2.Text, out int x);
                        twosP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.twosLocked = true;
                        twosP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.twosCalculated = true;
                        swapTurns();
                    }
                    else if (index == 3 && yaht.player2.scores.threesLocked == false) { // threes
                        int.TryParse(threesP2.Text, out int x);
                        threesP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.threesLocked = true;
                        threesP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.threesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 4 && yaht.player2.scores.foursLocked == false) { // fours
                        int.TryParse(foursP2.Text, out int x);
                        foursP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.foursLocked = true;
                        foursP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.foursCalculated = true;
                        swapTurns();
                    }
                    else if (index == 5 && yaht.player2.scores.fivesLocked == false) { // fives
                        int.TryParse(fivesP2.Text, out int x);
                        fivesP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.fivesLocked = true;
                        fivesP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.fivesCalculated = true;
                        swapTurns();
                    }
                    else if (index == 6 && yaht.player2.scores.sixesLocked == false) { // sixes
                        int.TryParse(sixesP1.Text, out int x);
                        sixesP2.Text = $"{x}";

                        yaht.player2.scores.sum += x;
                        sumP2.Text = $"{yaht.player2.scores.sum}";

                        yaht.player2.scores.sixesLocked = true;
                        sixesP2.BackColor = Color.DarkGray;

                        yaht.player2.scores.sixesCalculated = true;
                        swapTurns();
                    }
                }
            }
        }

        private void checkSingles() {
            if (yaht.currentPlayerTurn) { // P1 TURN 
                // ONES
                if (!yaht.player1.scores.onesLocked) {
                    if (yaht.dice.one == 1) {
                        yaht.player1.scores.ones += 1;
                    }
                    if (yaht.dice.two == 1) {
                        yaht.player1.scores.ones += 1;
                    }
                    if (yaht.dice.three == 1) {
                        yaht.player1.scores.ones += 1;
                    }
                    if (yaht.dice.four == 1) {
                        yaht.player1.scores.ones += 1;
                    }
                    if (yaht.dice.five == 1) {
                        yaht.player1.scores.ones += 1;
                    }
                }

                // TWOS
                if (!yaht.player1.scores.twosLocked) {
                    if (yaht.dice.one == 2) {
                        yaht.player1.scores.twos += 2;
                    }
                    if (yaht.dice.two == 2) {
                        yaht.player1.scores.twos += 2;
                    }
                    if (yaht.dice.three == 2) {
                        yaht.player1.scores.twos += 2;
                    }
                    if (yaht.dice.four == 2) {
                        yaht.player1.scores.twos += 2;
                    }
                    if (yaht.dice.five == 2) {
                        yaht.player1.scores.twos += 2;
                    }
                }

                // THREES
                if (!yaht.player1.scores.threesLocked) {
                    if (yaht.dice.one == 3) {
                        yaht.player1.scores.threes += 3;
                    }
                    if (yaht.dice.two == 3) {
                        yaht.player1.scores.threes += 3;
                    }
                    if (yaht.dice.three == 3) {
                        yaht.player1.scores.threes += 3;
                    }
                    if (yaht.dice.four == 3) {
                        yaht.player1.scores.threes += 3;
                    }
                    if (yaht.dice.five == 3) {
                        yaht.player1.scores.threes += 3;
                    }
                }

                // FOURS
                if (!yaht.player1.scores.foursLocked) {
                    if (yaht.dice.one == 4) {
                        yaht.player1.scores.fours += 4;
                    }
                    if (yaht.dice.two == 4) {
                        yaht.player1.scores.fours += 4;
                    }
                    if (yaht.dice.three == 4) {
                        yaht.player1.scores.fours += 4;
                    }
                    if (yaht.dice.four == 4) {
                        yaht.player1.scores.fours += 4;
                    }
                    if (yaht.dice.five == 4) {
                        yaht.player1.scores.fours += 4;
                    }
                }

                // FIVES
                if (!yaht.player1.scores.fivesLocked) {
                    if (yaht.dice.one == 5) {
                        yaht.player1.scores.fives += 5;
                    }
                    if (yaht.dice.two == 5) {
                        yaht.player1.scores.fives += 5;
                    }
                    if (yaht.dice.three == 5) {
                        yaht.player1.scores.fives += 5;
                    }
                    if (yaht.dice.four == 5) {
                        yaht.player1.scores.fives += 5;
                    }
                    if (yaht.dice.five == 5) {
                        yaht.player1.scores.fives += 5;
                    }
                }

                // SIXES
                if (!yaht.player1.scores.sixesLocked) {
                    if (yaht.dice.one == 6) {
                        yaht.player1.scores.sixes += 6;
                    }
                    if (yaht.dice.two == 6) {
                        yaht.player1.scores.sixes += 6;
                    }
                    if (yaht.dice.three == 6) {
                        yaht.player1.scores.sixes += 6;
                    }
                    if (yaht.dice.four == 6) {
                        yaht.player1.scores.sixes += 6;
                    }
                    if (yaht.dice.five == 6) {
                        yaht.player1.scores.sixes += 6;
                    }
                }

                // UPDATE BOXES
                if (!yaht.player1.scores.onesLocked) {
                    onesP1.Text = $"{yaht.player1.scores.ones}";
                    yaht.player1.scores.ones = 0;
                }

                if (!yaht.player1.scores.twosLocked) {
                    twosP1.Text = $"{yaht.player1.scores.twos}";
                    yaht.player1.scores.twos = 0;
                }

                if (!yaht.player1.scores.threesLocked) {
                    threesP1.Text = $"{yaht.player1.scores.threes}";
                    yaht.player1.scores.threes = 0;
                }

                if (!yaht.player1.scores.foursLocked) {
                    foursP1.Text = $"{yaht.player1.scores.fours}";
                    yaht.player1.scores.fours = 0;
                }

                if (!yaht.player1.scores.fivesLocked) {
                    fivesP1.Text = $"{yaht.player1.scores.fives}";
                    yaht.player1.scores.fives = 0;
                }

                if (!yaht.player1.scores.sixesLocked) {
                    sixesP1.Text = $"{yaht.player1.scores.sixes}";
                    yaht.player1.scores.sixes = 0;
                }
            }
            else { // P2 TURN
                // ONES
                if (!yaht.player2.scores.onesLocked) {
                    if (yaht.dice.one == 1) {
                        yaht.player2.scores.ones += 1;
                    }
                    if (yaht.dice.two == 1) {
                        yaht.player2.scores.ones += 1;
                    }
                    if (yaht.dice.three == 1) {
                        yaht.player2.scores.ones += 1;
                    }
                    if (yaht.dice.four == 1) {
                        yaht.player2.scores.ones += 1;
                    }
                    if (yaht.dice.five == 1) {
                        yaht.player2.scores.ones += 1;
                    }
                }

                // TWOS
                if (!yaht.player2.scores.twosLocked) {
                    if (yaht.dice.one == 2) {
                        yaht.player2.scores.twos += 2;
                    }
                    if (yaht.dice.two == 2) {
                        yaht.player2.scores.twos += 2;
                    }
                    if (yaht.dice.three == 2) {
                        yaht.player2.scores.twos += 2;
                    }
                    if (yaht.dice.four == 2) {
                        yaht.player2.scores.twos += 2;
                    }
                    if (yaht.dice.five == 2) {
                        yaht.player2.scores.twos += 2;
                    }
                }

                // THREES
                if (!yaht.player2.scores.threesLocked) {
                    if (yaht.dice.one == 3) {
                        yaht.player2.scores.threes += 3;
                    }
                    if (yaht.dice.two == 3) {
                        yaht.player2.scores.threes += 3;
                    }
                    if (yaht.dice.three == 3) {
                        yaht.player2.scores.threes += 3;
                    }
                    if (yaht.dice.four == 3) {
                        yaht.player2.scores.threes += 3;
                    }
                    if (yaht.dice.five == 3) {
                        yaht.player2.scores.threes += 3;
                    }
                }

                // FOURS
                if (!yaht.player2.scores.foursLocked) {
                    if (yaht.dice.one == 4) {
                        yaht.player2.scores.fours += 4;
                    }
                    if (yaht.dice.two == 4) {
                        yaht.player2.scores.fours += 4;
                    }
                    if (yaht.dice.three == 4) {
                        yaht.player2.scores.fours += 4;
                    }
                    if (yaht.dice.four == 4) {
                        yaht.player2.scores.fours += 4;
                    }
                    if (yaht.dice.five == 4) {
                        yaht.player2.scores.fours += 4;
                    }
                }

                // FIVES
                if (!yaht.player2.scores.fivesLocked) {
                    if (yaht.dice.one == 5) {
                        yaht.player2.scores.fives += 5;
                    }
                    if (yaht.dice.two == 5) {
                        yaht.player2.scores.fives += 5;
                    }
                    if (yaht.dice.three == 5) {
                        yaht.player2.scores.fives += 5;
                    }
                    if (yaht.dice.four == 5) {
                        yaht.player2.scores.fives += 5;
                    }
                    if (yaht.dice.five == 5) {
                        yaht.player2.scores.fives += 5;
                    }
                }

                // SIXES
                if (!yaht.player2.scores.sixesLocked) {
                    if (yaht.dice.one == 6) {
                        yaht.player2.scores.sixes += 6;
                    }
                    if (yaht.dice.two == 6) {
                        yaht.player2.scores.sixes += 6;
                    }
                    if (yaht.dice.three == 6) {
                        yaht.player2.scores.sixes += 6;
                    }
                    if (yaht.dice.four == 6) {
                        yaht.player2.scores.sixes += 6;
                    }
                    if (yaht.dice.five == 6) {
                        yaht.player2.scores.sixes += 6;
                    }
                }

                // UPDATE BOXES
                if (!yaht.player2.scores.onesLocked) {
                    onesP2.Text = $"{yaht.player2.scores.ones}";
                    yaht.player2.scores.ones = 0;
                }

                if (!yaht.player2.scores.twosLocked) {
                    twosP2.Text = $"{yaht.player2.scores.twos}";
                    yaht.player2.scores.twos = 0;
                }

                if (!yaht.player2.scores.threesLocked) {
                    threesP2.Text = $"{yaht.player2.scores.threes}";
                    yaht.player2.scores.threes = 0;
                }

                if (!yaht.player2.scores.foursLocked) {
                    foursP2.Text = $"{yaht.player2.scores.fours}";
                    yaht.player2.scores.fours = 0;
                }

                if (!yaht.player2.scores.fivesLocked) {
                    fivesP2.Text = $"{yaht.player2.scores.fives}";
                    yaht.player2.scores.fives = 0;
                }

                if (!yaht.player2.scores.sixesLocked) {
                    sixesP2.Text = $"{yaht.player2.scores.sixes}";
                    yaht.player2.scores.sixes = 0;
                }
            }
        }

        private void checkBonus() {
            if (yaht.player1.scores.sum >= 63) {
                yaht.player1.scores.bonus = BONUS;

                bonusP1.Text = $"{BONUS}";
            }
            else {
                yaht.player1.scores.bonus = 0;

                bonusP1.Text = $"0";
            }

            if (yaht.player2.scores.sum >= 63) {
                yaht.player2.scores.bonus = BONUS;

                bonusP2.Text = $"{BONUS}";
            }
            else {
                yaht.player2.scores.bonus = 0;

                bonusP2.Text = $"0";
            }
        }

        private void checkFancies() {

        }
    }
}