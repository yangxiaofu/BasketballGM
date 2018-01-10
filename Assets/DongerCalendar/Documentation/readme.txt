Version 1.0
Directions for creating an EventManager GameObject.
    1. Create an empty gameobject
    2. Add the Calendar Component
    3. Add an Event Manager Component
    

UI BUILDER - The UI Builder is for creating UI elements in the game.
    In order to build a cell by code you must   
        1.) Setup the CellBuilder parameters by calling new CellBuilder.
        2.) Apply the CellBuilder Methods to the delegate. 
        3.) Make the call to the relevant DongerUI Methods
            a.)  Exaple ButtonDongerUIMethod

            Example: 
                //Setup the cellbuilder.
                var cellBuilder = new CellBuilder(Calendar.DaysInWeek[i].ToString());
                cellBuilder.SetFont(_font);
                cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);
                cellBuilder.SetTextAnchor(TextAnchor.MiddleCenter);
                cellBuilder.SetBackgroundImage(_uiBackground, 0f); //TODO: Background image needs set.
                cellBuilder.SetParent(row.transform);

                DongerUI.CellBuilderHandler cellBuilderHandler = cellBuilder.ApplyFont;
                cellBuilderHandler += cellBuilder.ApplyLayoutElement;
                cellBuilderHandler += cellBuilder.ApplyBackgroundImage;
                cellBuilderHandler += cellBuilder.ApplyParent;

                var textCell = new TextCellDongerUI(Calendar.DaysInWeek[i], cellBuilderHandler);
                var cell = new CellUI(textCell);
                cell.Build();

The Calendar will be a core feature that will also be used in other sports simulation.  It will contain features that allow 
Calendar Component
    -A calendar UI that comes by default. 
        -UI can click to the next day of the calendar.
        -Simulate thru multiple days while simulating all of the events of that day. 
        -Have the ability to go thru specific days.

    -A way to add events in each day of the calendar. 
    

Season Generator Component
    

    