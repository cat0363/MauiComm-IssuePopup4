using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace MauiComm_IssuePopup4;

public partial class Indicator : Popup
{
	int pItemNo = 0;


	public Indicator(int itemNo)
	{
		InitializeComponent();
		pItemNo = itemNo;
		lblNumber.Text = pItemNo.ToString();

		Opened += new EventHandler<CommunityToolkit.Maui.Core.PopupOpenedEventArgs>(popup_OnOpned);
	}

	void popup_OnOpned(object? sender, PopupOpenedEventArgs e)
	{
		System.Diagnostics.Debug.WriteLine("itemNo:" +pItemNo);
	}
}