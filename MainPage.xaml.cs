using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MauiComm_IssuePopup4;

public partial class MainPage : ContentPage
{
    Indicator? pIndicator = null;
    int pItemNum = 0;
    ObservableCollection<TestItem> pTestItems = new ObservableCollection<TestItem>();

    public MainPage()
	{
		InitializeComponent();
    
        BindableLayout.SetItemsSource(slTestItems, pTestItems);
    }

    void GetTestItem()
    {
        for (int i = 0; i < 15; i++)
        {
            pTestItems.Add(new TestItem() { ItemName = "Item Name " + pItemNum });
        }
        pItemNum++;
    }

    void ShowIndicator()
    {
        if (pIndicator == null)
        {
            pIndicator = new Indicator(pItemNum);
            this.ShowPopup(pIndicator);
        }
    }

    void CloseIndicator()
    {
        if (pIndicator != null)
        {
            pIndicator.Close();
            pIndicator = null;
        }
    }

    void btnShow_Clicked(object sender, EventArgs e)
    {
        ShowIndicator();

        GetTestItem();

        CloseIndicator();

        ShowIndicator();

        GetTestItem();

        CloseIndicator();
    }

    void svTestItems_Scrolled(object sender, ScrolledEventArgs e)
    {
        if (Math.Abs((svTestItems.ContentSize.Height - svTestItems.Height) - svTestItems.ScrollY) <= 100)
        {
            svTestItems.Scrolled -= new EventHandler<ScrolledEventArgs>(svTestItems_Scrolled);

            ShowIndicator();

            GetTestItem();

            CloseIndicator();

            svTestItems.Scrolled += new EventHandler<ScrolledEventArgs>(svTestItems_Scrolled);
        }
    }

}

public class TestItem
{
    public string? ItemName { get; set; }
}

