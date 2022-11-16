/*
Brennon Hahs
The string: “Midterm #2”
Today’s date: November 8, 2021
course number: CPSC 223N-1


*/

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.Media;

public class speedChangerUI: Form { 
    private Panel header = new Panel();
    private Graphicpanel display = new Graphicpanel();
    private Panel buttons = new Panel();
    private Label title = new Label();
    private Label author = new Label();
    private Label xLabel = new Label();
    private Label yLabel = new Label();
    private Label speedLabel = new Label();
    private Label directionLabel = new Label();
    private Label invalidInput = new Label();
    private static Button start = new Button();
    private Button initialize = new Button();
    private Button exit = new Button();
    private Button plus = new Button();
    private Button minus = new Button();
    private TextBox xCoordinate = new TextBox();
    private TextBox yCoordinate = new TextBox();
    private TextBox currentSpeed = new TextBox();
    private TextBox enterDirection = new TextBox();
    private Size minimumSize = new Size(1295,850);
    private Size maximumSize = new Size(1920,1080);
    private static double direction;
    private static double radians;
    private static double circSpeed;
    private const double animationClockSpeed = 144;
    private static double deltaX;
    private static double deltaY;
    private static double animationInterval = 1000/animationClockSpeed;
    private int convertedAnInterval = (int)System.Math.Round(animationInterval);
    private const double refreshClockSpeed = 144;
    private static double refreshInterval = 1000/refreshClockSpeed;
    private int convertedReInterval = (int)System.Math.Round(refreshInterval);
    private const double radius = 10;
    private const double initX = 640;
    private const double initY = 287.5;
    private static double x;
    private static double y;
    private static bool initialized = false;
    private static double storeDeltaX = 0;
    private static double storeDeltaY = 0;
    private static System.Timers.Timer refreshClock = new System.Timers.Timer();
    private static System.Timers.Timer ballClock = new System.Timers.Timer();

    public speedChangerUI() {
        MinimumSize = minimumSize;
        MaximumSize = maximumSize;

        xCoordinate.Multiline = true;
        yCoordinate.Multiline = true;

        this.Size = new Size(1280,850);
        header.Size = new Size(1280,60);
        display.Size = new Size(1280,575);
        buttons.Size = new Size(1280,236);
        title.Size = new Size(200,30);
        author.Size = new Size(200,20);
        start.Size = new Size(140,140);
        initialize.Size = new Size(140,140);
        exit.Size = new Size(70,40);
        xCoordinate.Size = new Size(70,40);
        yCoordinate.Size = new Size(70,40);
        currentSpeed.Size = new Size(70,40);
        enterDirection.Size = new Size(70,40);
        xLabel.Size = new Size(70,20);
        yLabel.Size = new Size(100,20);
        speedLabel.Size = new Size(100,20);
        directionLabel.Size = new Size(110,20);
        invalidInput.Size = new Size(200,85);
        plus.Size = new Size(40,40);
        minus.Size = new Size(40,40);

        header.BackColor = Color.Goldenrod;
        display.BackColor = Color.Thistle;
        buttons.BackColor = Color.RoyalBlue;
        start.BackColor = Color.Maroon;
        initialize.BackColor = Color.Maroon;
        exit.BackColor = Color.Maroon;
        plus.BackColor = Color.Maroon;
        minus.BackColor = Color.Maroon;
        xCoordinate.BackColor = Color.White;
        yCoordinate.BackColor = Color.White;
        currentSpeed.BackColor = Color.White;
        enterDirection.BackColor = Color.White;

        header.Location = new Point(0,0);
        display.Location = new Point(0,60);
        buttons.Location = new Point(0,635);
        title.Location = new Point(540,0);
        author.Location = new Point(540,35);
        start.Location = new Point(28,20);
        initialize.Location = new Point(239,20);
        exit.Location = new Point(1172,120);
        xCoordinate.Location = new Point(608,120);
        yCoordinate.Location = new Point(872,120);
        currentSpeed.Location = new Point(608,30);
        plus.Location = new Point(688,30);
        minus.Location = new Point(688,80);
        enterDirection.Location = new Point(872,30);
        xLabel.Location = new Point(608,100);
        yLabel.Location = new Point(872,100);
        speedLabel.Location = new Point(608,10);
        directionLabel.Location = new Point(872,10);
        invalidInput.Location = new Point(405,45);

        xCoordinate.ReadOnly = true;
        yCoordinate.ReadOnly = true;
        currentSpeed.ReadOnly = true;

        Text = "Speed Changer";
        title.Text = "Speed Changer";
        author.Text = "By Brennon Hahs";
        start.Text = "Start";
        initialize.Text = "Initialize";
        exit.Text = "Exit";
        xCoordinate.Text = "N/A";
        yCoordinate.Text = "N/A";
        //currentSpeed.Text = "N/A";
        //enterDirection.Text = "N/A";
        xLabel.Text = "X Coord.";
        yLabel.Text = "Y Coord.";
        speedLabel.Text = "Current Speed";
        directionLabel.Text = "Enter Direction";
        invalidInput.Text = "";
        plus.Text = "+";
        minus.Text = "-";

        title.Font = new Font("Times New Roman",20,FontStyle.Bold);
        author.Font = new Font("Times New Roman",10,FontStyle.Regular);
        start.Font = new Font("Arial",10,FontStyle.Bold);
        initialize.Font = new Font("Arial",10,FontStyle.Bold);
        exit.Font = new Font("Arial",10,FontStyle.Bold);
        xCoordinate.Font = new Font("Arial",10,FontStyle.Bold);
        yCoordinate.Font = new Font("Arial",10,FontStyle.Bold);
        currentSpeed.Font = new Font("Arial",10,FontStyle.Bold);
        enterDirection.Font = new Font("Arial",10,FontStyle.Bold);
        xLabel.Font = new Font("Arial",10,FontStyle.Bold);
        yLabel.Font = new Font("Arial",10,FontStyle.Bold);
        speedLabel.Font = new Font("Arial",10,FontStyle.Bold);
        directionLabel.Font = new Font("Arial",10,FontStyle.Bold);
        invalidInput.Font = new Font("Arial",14,FontStyle.Bold);
        plus.Font = new Font("Arial",14,FontStyle.Bold);
        minus.Font = new Font("Arial",14,FontStyle.Bold);

        title.TextAlign = ContentAlignment.MiddleCenter;
        author.TextAlign = ContentAlignment.MiddleCenter;
        start.TextAlign = ContentAlignment.MiddleCenter;
        initialize.TextAlign = ContentAlignment.MiddleCenter;
        exit.TextAlign = ContentAlignment.MiddleCenter;
        xCoordinate.TextAlign = HorizontalAlignment.Center;
        yCoordinate.TextAlign = HorizontalAlignment.Center;
        plus.TextAlign = ContentAlignment.MiddleCenter;
        minus.TextAlign = ContentAlignment.MiddleCenter;

        Controls.Add(header);
        header.Controls.Add(title);
        header.Controls.Add(author);
        Controls.Add(display);
        Controls.Add(buttons);
        buttons.Controls.Add(start);
        buttons.Controls.Add(initialize);
        buttons.Controls.Add(exit);
        buttons.Controls.Add(xCoordinate);
        buttons.Controls.Add(yCoordinate);
        buttons.Controls.Add(currentSpeed);
        buttons.Controls.Add(enterDirection);
        buttons.Controls.Add(xLabel);
        buttons.Controls.Add(yLabel);
        buttons.Controls.Add(speedLabel);
        buttons.Controls.Add(directionLabel);
        buttons.Controls.Add(invalidInput);
        buttons.Controls.Add(plus);
        buttons.Controls.Add(minus);

        refreshClock.Enabled = false;
        refreshClock.Interval = convertedReInterval;
        refreshClock.Elapsed += new ElapsedEventHandler(refreshInterface);

        ballClock.Enabled = false;
        ballClock.Interval = convertedAnInterval;
        ballClock.Elapsed += new ElapsedEventHandler(updateCoordinates);
        
        start.Click += new EventHandler(startPause);
        exit.Click += new EventHandler(exitProgram);
        initialize.Click += new EventHandler(initializeFunct);
        plus.Click += new EventHandler(increaseSpeed);
        minus.Click += new EventHandler(decreaseSpeed);

        start.Enabled = false;

        CenterToScreen();
    }

    void updateCoordinates(Object sender, EventArgs events) {
        x = x + deltaX;
        y = y + deltaY;
        if (y <= 0) {
            y = 0;
            deltaY = -deltaY;
        }
        if (x <= 0) {
            x = 0;
            deltaX = -deltaX;
        }
        if (y + (2*radius) >= 575) {
            y = 575 - (2*radius);
            deltaY = -deltaY;
        }
        if ((x + (2*radius)) >= 1280) {
            x = 1280 - (2*radius);
            deltaX = -deltaX;
        }
        xCoordinate.Text = (x + radius).ToString();
        yCoordinate.Text = (y + radius).ToString();
    }

    void refreshInterface(Object sender, EventArgs events) {
        display.Invalidate();
    }

    void increaseSpeed(Object sender, EventArgs events) {
        minus.Enabled = true;
        if ((circSpeed + 10) > 350) {
            plus.Enabled = false;
        }
        if ((circSpeed + 10) == 10) {
            deltaX = storeDeltaX;
            deltaY = storeDeltaY;
        }
        circSpeed = circSpeed + 10;
        currentSpeed.Text = circSpeed.ToString();
        if (deltaX < 0 && deltaY > 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = -(circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX < 0 && deltaY < 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX > 0 && deltaY > 0) {
            deltaX = (circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = -(circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX < 0 && deltaY == 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        //else if (deltaX == 0 && deltaY == 0) {
        //}
        else {
            deltaX = (circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
    }

    void decreaseSpeed(Object sender, EventArgs events) {
        plus.Enabled = true;
        if ((circSpeed - 10) < 10) {
            minus.Enabled = false;
        }
        if ((circSpeed - 10) == 0) {
            storeDeltaX = deltaX;
            storeDeltaY = deltaY;
        }
        circSpeed = circSpeed - 10;
        currentSpeed.Text = circSpeed.ToString();
        if (deltaX < 0 && deltaY > 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = -(circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX < 0 && deltaY < 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX > 0 && deltaY > 0) {
            deltaX = (circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = -(circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        else if (deltaX < 0 && deltaY == 0) {
            deltaX = -(circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
        //else if (deltaX == 0 && deltaY == 0) {
        //}
        else {
            deltaX = (circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
        }
    }

    void initializeFunct(Object sender, EventArgs events) {
        bool isException = false;
        initialized = true;
        ballClock.Enabled = false;
        refreshClock.Enabled = false;

        if (enterDirection.Text == "") {
            direction = -45;
            enterDirection.Text = "45";
        }
        if (currentSpeed.Text == "") {
            circSpeed = 80;
            currentSpeed.Text = circSpeed.ToString();
        }

        try {
            circSpeed = float.Parse(currentSpeed.Text);
            direction = -float.Parse(enterDirection.Text);
        }
        catch (FormatException) {
            start.Text = "Start";
            start.Enabled = false;
            isException = true;
            invalidInput.Text = "Invalid Input: No Letters Or Special Characters Are Allowed";
            x = 640 - radius;
            y = 287.5 - radius;
        }
        if (isException == false) {
            start.Text = "Start";
            start.Enabled = true;
            invalidInput.Text = "";
            radians = direction * (Math.PI/180);
            deltaX = (circSpeed/animationClockSpeed) * Math.Cos(radians);
            deltaY = (circSpeed/animationClockSpeed) * Math.Sin(radians);
            x = 640 - radius;
            y = 287.5 - radius;
        }
        display.Invalidate();
        xCoordinate.Text = (x + radius).ToString();
        yCoordinate.Text = (y + radius).ToString();
    }

    void startPause(Object sender, EventArgs events) {
        if (refreshClock.Enabled == false && ballClock.Enabled == false) {
            ballClock.Enabled = true;
            refreshClock.Enabled = true;
            start.Text = "Pause";
        }
        else {
            ballClock.Enabled = false;
            refreshClock.Enabled = false;
            start.Text = "Start";
        }
    }

    void exitProgram(Object sender, EventArgs events) {
        Close();
    }


    public class Graphicpanel: Panel {
        private Brush greenBrush = new SolidBrush(Color.Green);

        public Graphicpanel() {
            Console.WriteLine("A graphic enabled panel was created");
        }
        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;
            if (initialized == true) {
                g.FillEllipse(greenBrush, (float)x, (float)y, (float)(radius*2), (float)(radius*2));
            }
            base.OnPaint(e);
        }
    }
}