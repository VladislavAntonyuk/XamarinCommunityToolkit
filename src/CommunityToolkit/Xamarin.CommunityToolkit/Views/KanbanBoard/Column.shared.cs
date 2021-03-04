using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xamarin.CommunityToolkit.Views
{
	public class Column
	{
		public Column() => Cards = new ObservableCollection<Card>();

		public string Name { get; set; }
		public int Wip { get; set; } = int.MaxValue;
		public ICollection<Card> Cards { get; set; }
		public int Order { get; set; }
		public virtual bool IsWipReached => Cards.Count >= Wip;
	}
}