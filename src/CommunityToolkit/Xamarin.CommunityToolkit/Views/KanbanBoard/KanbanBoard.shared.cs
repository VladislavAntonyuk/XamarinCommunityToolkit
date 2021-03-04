using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Views
{
	public class KanbanBoard : ContentView
	{
		public static readonly BindableProperty BoardTitleProperty =
			BindableProperty.Create(nameof(BoardTitle), typeof(string), typeof(KanbanBoard), string.Empty);

		public static readonly BindableProperty BoardTitleFontSizeProperty =
			BindableProperty.Create(nameof(BoardTitleFontSize), typeof(double), typeof(KanbanBoard), 14d);

		public static readonly BindableProperty BoardTitleTextColorProperty =
			BindableProperty.Create(nameof(BoardTitleTextColor), typeof(Color), typeof(KanbanBoard), Color.White);

		public static readonly BindableProperty ColumnsProperty =
			BindableProperty.Create(nameof(BoardTitleTextColor), typeof(ICollection<Column>), typeof(KanbanBoard), Enumerable.Empty<Column>());

		public ICollection<Column> Columns
		{
			get => (ICollection<Column>)GetValue(ColumnsProperty);
			set => SetValue(ColumnsProperty, value);
		}
		public string BoardTitle
		{
			get => (string)GetValue(BoardTitleProperty);
			set => SetValue(BoardTitleProperty, value);
		}

		public double BoardTitleFontSize
		{
			get => (double)GetValue(BoardTitleFontSizeProperty);
			set => SetValue(BoardTitleFontSizeProperty, value);
		}

		public Color BoardTitleTextColor
		{
			get => (Color)GetValue(BoardTitleTextColorProperty);
			set => SetValue(BoardTitleTextColorProperty, value);
		}
		
		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == "Parent")
			{
				BatchBegin();
				var mainLayout = new StackLayout() { Background = Background };
				var title = new Label { Text = BoardTitle, FontSize = BoardTitleFontSize, TextColor = BoardTitleTextColor, HorizontalOptions = LayoutOptions.Center };
				mainLayout.Children.Add(title);
				var columns = new CarouselView(){Loop=false,PeekAreaInsets = 10,Position=0,EmptyView = "Empty", ItemsSource = Columns, ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal){ItemSpacing = 10}};
				mainLayout.Children.Add(columns);
				var addColumnButton = new Button { Text = BoardTitle, FontSize = BoardTitleFontSize, TextColor = BoardTitleTextColor, Command=null, HorizontalOptions = LayoutOptions.Center };
				mainLayout.Children.Add(addColumnButton);
				Content = mainLayout;
				BatchCommit();
			}
		}
	}
}
