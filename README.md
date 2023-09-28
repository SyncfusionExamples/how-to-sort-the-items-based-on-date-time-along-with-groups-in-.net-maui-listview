# how-to-sort-the-items-based-on-date-time-along-with-groups-in-.net-maui-listview

This example demonstrates how to sort the items based on date time along with the groups in .NET MAUI ListView

## XAML 

<listView:SfListView x:Name="listView" ItemsSource="{Binding Items}" IsStickyGroupHeader="False" ItemSize="50">
    <listView:SfListView.ItemTemplate>
        <DataTemplate>
            <StackLayout>
                <Grid Padding="10,0,0,0">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>
                    <Label LineBreakMode="NoWrap" 
            VerticalTextAlignment="End"
            Text="{Binding ContactName}"/>
                    <Label Grid.Row="1"
            VerticalTextAlignment="Start"
            Text="{Binding DateOfBirth, StringFormat='{0:dd/MM/yyyy}', Mode=TwoWay}"/>
                </Grid>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="1" />
                    </Grid.RowDefinitions>
                    <StackLayout BackgroundColor="Gray"/>
                </Grid>
            </StackLayout>
        </DataTemplate>
    </listView:SfListView.ItemTemplate>
    <listView:SfListView.GroupHeaderTemplate>
        <DataTemplate>
            <Label Text= "{Binding Key}" BackgroundColor="Teal" FontSize="22" FontAttributes="Bold" TextColor="White"/>
        </DataTemplate>
    </listView:SfListView.GroupHeaderTemplate>
</listView:SfListView>

## C# 
    class CustomGroupComparer : IComparer<GroupResult>, ISortDirection
    {
        public CustomGroupComparer()
        {
            this.SortDirection = ListSortDirection.Ascending;
        }

        public ListSortDirection SortDirection
        {
            get;
            set;
        }

        public int Compare(GroupResult x, GroupResult y)
        {
            DateTime xvalue = Convert.ToDateTime(x.Key);
            DateTime yvalue = Convert.ToDateTime(y.Key);

            // Group results are compared and return the SortDirection
            if (xvalue.CompareTo(yvalue) > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            else if (xvalue.CompareTo(yvalue) == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            else
                return 0;
        }
    }

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.