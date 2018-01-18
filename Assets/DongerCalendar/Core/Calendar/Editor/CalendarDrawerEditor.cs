using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Donger.BuckeyeEngine{
	public class CalendarDrawerEditor : Editor {

        public ICalendarDrawer _calendarDrawer;
		

        public CalendarDrawerEditor(ICalendarDrawer calendarDrawer){
            _calendarDrawer = calendarDrawer;
        }

        public void Draw()
        {
            _calendarDrawer.Draw();
        }
    }
}

