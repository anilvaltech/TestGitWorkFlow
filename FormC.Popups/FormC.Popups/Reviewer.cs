using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FormC.Popups
{
    public class Reviewer : INotifyPropertyChanged
    {
        private string _reviewerName;
        public string ReviewerName
        {
            get { return _reviewerName; }
            set 
            { 
                _reviewerName = value;
                NotifyPropertyChanged("ReviewerName");
            }
        }

        private string _decision;
        public string Decision
        {
            get { return _decision; }
            set
            {
                _decision = value;
                NotifyPropertyChanged("Decision");
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
