using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using xamApp4.Models;
using Xamarin.Forms.Maps;

namespace xamApp4.ViewModels
{
	public class PinItemViewModel
	{
		int _pinCreatedCount = 0;
		readonly ObservableCollection<Location> _locations;

		public IEnumerable StoreLocations => _locations; 

		public PinItemViewModel()
		{
			_locations = new ObservableCollection<Location>()
			{
				new Location(1,"8 1st Ave S, Buffalo, MN 55313", "Ritzy Replay", new Position(45.170633, -93.874608),"RitzyReplay"),
				new Location(2,"8 1st Ave S, Buffalo, MN 55313", "Evelyns Winebar", new Position(45.172654, -93.876058),"RitzyReplay"),
				new Location(3,"8 1st Ave S, Buffalo, MN 55313", "A Wreath Of Franklin", new Position(45.172654, -93.876058),"RitzyReplay")
			};
		}
	}
}
