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
			// TODO: read these from db?  sqlite or firebase?
			_locations = new ObservableCollection<Location>()
			{
				new Location(1,"8 1st Ave S, Buffalo, MN 55313", "Ritzy Replay", new Position(45.171716, -93.874632),"RitzyReplay"),
				new Location(2,"18 Central Ave, Buffalo, MN 55313", "Evelyns Winebar", new Position(45.172654, -93.876058),"EvelynsWineBar"),
				new Location(3,"11 Division Arc, Buffalo, MN 55313", "A Wreath Of Franklin", new Position(45.172138, -93.875817),"AWreathOfFranklin"),
				new Location(4,"112 1st St S, Buffalo, MN 55313", "Hayes Public House", new Position(45.170583, -93.874611),"HayesPublicHouse"),
	
			};
		}
	}
}
