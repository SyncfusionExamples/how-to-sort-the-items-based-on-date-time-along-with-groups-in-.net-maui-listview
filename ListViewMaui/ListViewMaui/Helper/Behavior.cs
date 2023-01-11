using ListViewMaui.Helper;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.DataSource.Extensions;
using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
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
}
