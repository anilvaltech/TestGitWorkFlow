using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FormC.Popups.ViewModel
{
    public interface IRowViewModel : INotifyPropertyChanged
    {
    }

    public class RowViewModel : IRowViewModel
    {
        public IMainViewModel Parent { get; set; }

        public void Initialize(IMainViewModel mainViewModel)
        {
            Parent = mainViewModel;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                NotifyPropertyChanged("FirstName");
                if (Parent != null)
                    Parent.SetCustomerDetails(this);
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;
                _lastName = value;
                NotifyPropertyChanged("LastName");
                if (Parent != null)
                    Parent.SetCustomerDetails(this);
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value)
                    return;
                _age = value;
                NotifyPropertyChanged("Age");
                if (Parent != null)
                    Parent.SetCustomerDetails(this);
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address == value)
                    return;
                _address = value;
                NotifyPropertyChanged("Address");
                if (Parent != null)
                    Parent.SetCustomerDetails(this);
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if(_city == value)
                    return;
                
                _city = value;
                NotifyPropertyChanged("City");
                if (Parent != null)
                    Parent.SetCustomerDetails(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
