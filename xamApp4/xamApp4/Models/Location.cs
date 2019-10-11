using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace xamApp4.Models
{
	public class Location// : INotifyPropertyChanged
	{
		Position _position;
		public int Id { get; set; }

		public string Address { get; }
		public string Description { get; }

		public Image StoreFrontImage { get; set; }





		public Position Position
		{
			get => _position;
			set
			{
				if (!_position.Equals(value))
				{
					_position = value;
					//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
				}
			}
		}

		public Location(int id, string address, string description, Position position, string image)
		{
			Id = id;
			Address = address;
			Description = description;
			StoreFrontImage = new Image() { Source = image };
			Position = position;
		}

		#region INotifyPropertyChanged

		//public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}

}
