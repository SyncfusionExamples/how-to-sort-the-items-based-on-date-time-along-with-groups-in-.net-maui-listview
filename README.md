# How to sort items datetime with grouping in .NET MAUI ListView?

The [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) supports [Sorting](https://help.syncfusion.com/maui/listview/sorting) and [Grouping](https://help.syncfusion.com/maui/listview/grouping) items based on the DateTime property. This guide provides two examples: grouping with sorting by year and grouping with sorting by month and year.

Grouping with sorting by Year

Sort and group the items using [KeySelector](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataSource.GroupDescriptor.html#Syncfusion_DataSource_GroupDescriptor_KeySelector) based on returning the year value of the DateTime property.

The following code, sample explains how to sort the items along with the group header in ascending order based on the DateTime property.

XAML

Define the [SfListView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html) with the [GroupHeaderTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_GroupHeaderTemplate).

<listView:SfListView x:Name="listView" ItemsSource="{Binding Items}" IsStickyGroupHeader="False" ItemSize="50">
                <listView:SfListView.GroupHeaderTemplate>
                    <DataTemplate>
                        <Label Text= "{Binding Key}" BackgroundColor="Teal" FontSize="22" FontAttributes="Bold" TextColor="White"/>
                    </DataTemplate>
                </listView:SfListView.GroupHeaderTemplate>
     </listView:SfListView>
C#

public class Behavior:Behavior<ContentPage>
    {
         #region Fields
         private Syncfusion.Maui.ListView.SfListView listView;
         #endregion
     
         #region Overrides
         protected override void OnAttachedTo(ContentPage bindable)
         {
           listView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
           listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
           {
             PropertyName = "DateOfBirth",
             KeySelector = (object obj1) =>
             {
                var item = (obj1 as Contacts);
                return item.DateOfBirth.Year;
             },
           });
     
           this.listView.DataSource.SortDescriptors.Add(new SortDescriptor()
           {
              PropertyName = "DateOfBirth",
               Direction = ListSortDirection.Ascending
           });
           base.OnAttachedTo(bindable);
         }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            listView = null;
            base.OnDetachingFrom(bindable);
         }
         #endregion
    }
Grouping with sorting by Month and Year

Create groups using [KeySelector](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataSource.GroupDescriptor.html#Syncfusion_DataSource_GroupDescriptor_KeySelector) based on returning the year and month value of the DateTime property while sorting the items, and groups are sorted based on the year and months of the DateTime property by using Comparer.

C#

class CustomGroupComparer : IComparer<GroupResult>, ISortDirection
    {
        public CustomGroupComparer()
        {
            this.SortDirection = ListSortDirection.Ascending;
        }
    
        public ListSortDirection SortDirection { get; set; }
    
        public int Compare(GroupResult x, GroupResult y)
        {
            DateTime xValue = Convert.ToDateTime(x.Key);
            DateTime yValue = Convert.ToDateTime(y.Key);
    
            // Compare group results and return based on SortDirection
            if (xValue.CompareTo(yValue) > 0)
            {
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            }
            else if (xValue.CompareTo(yValue) < 0)
            {
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            }
            else
            {
                return 0;
            }
        }
    }
C#

public class Behavior:Behavior<ContentPage>
    {
       #region Fields
        private Syncfusion.Maui.ListView.SfListView listView;  
       #endregion
     
       #region Overrides
         protected override void OnAttachedTo(ContentPage bindable)
         {
            listView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
              PropertyName = "DateOfBirth",
              KeySelector = (object obj1) =>
              {
                 var item = (obj1 as Contacts);
                 return item.DateOfBirth.Month + "/" + item.DateOfBirth.Year;
               },
                Comparer = new CustomGroupComparer()
            });
     
            listView.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
               PropertyName = "DateOfBirth",
               Direction = ListSortDirection.Ascending
            });
           base.OnAttachedTo(bindable);
        }
       protected override void OnDetachingFrom(ContentPage bindable)
       {
         listView = null;
         base.OnDetachingFrom(bindable);
       }
      #endregion
    }**Output**  

The following screenshots illustrate how to sort, and group based on year and month/year.

![How to sort the items by datetime property along with Grouping in .Net Maui Listview](https://www.syncfusion.com/uploads/user/kb/maui/maui-4054/maui-4054_img1.jpeg)


**Conclusion**

I hope you enjoyed learning about how to sort items by DateTime with grouping in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature
representations. Explore our [.NET MAUI ListView
documentation](https://help.syncfusion.com/maui/listview/getting-started) to understand
how to present and manipulate data.

For current customers, check out
our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion®, try
our 30-day [free
trial](https://www.syncfusion.com/downloads/maui) to check out
our .NET MAUI ListView and other .NET MAUI components.

Please let us know in comments section if you have any queries or require clarification. Contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
