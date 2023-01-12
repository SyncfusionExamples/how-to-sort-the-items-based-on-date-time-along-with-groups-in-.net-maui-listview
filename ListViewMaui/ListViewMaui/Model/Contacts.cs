using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{

    public class Contacts : INotifyPropertyChanged
    {
        private string contactName;
        private DateTimeOffset dateOfBirth;

        public Contacts(string name, DateTimeOffset number)
        {
            contactName = name;
            dateOfBirth = number;
        }
        public Contacts()
        {

        }
        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }
        public DateTimeOffset DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    this.RaisedOnPropertyChanged("DateOfBirth");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}
