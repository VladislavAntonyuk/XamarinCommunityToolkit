using System.Collections.Generic;
using Xamarin.CommunityToolkit.Views;

namespace Xamarin.CommunityToolkit.Sample.Pages.Views
{
	public partial class KanbanBoardPage
	{
		public KanbanBoardPage()
		{
			InitializeComponent();
			Board.Columns = new List<Column>() {new Column(), new Column(), new Column(),};
		}
	}
}