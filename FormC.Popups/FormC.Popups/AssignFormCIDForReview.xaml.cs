using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FormC.Popups
{
    public partial class AssignFormCidForReview : ChildWindow
    {
        public  ObservableCollection<Review> Reviews { get; set; }
        public AssignFormCidForReview()
        {
            InitializeComponent();

            Reviews = new ObservableCollection<Review>();
            for (int i = 1; i <= 3; i++)
            {

                Reviews.Add(new Review()
                                 {
                                     ReviewerOrdinal = "Reviewer " + i,
                                     Reviewers = new ObservableCollection<Reviewer>
                                                     {
                                                         new Reviewer
                                                             {
                                                                 Decision = "...",
                                                                 ReviewerName = "Mike"
                                                             },
                                                         new Reviewer
                                                             {
                                                                 Decision = "Pending",
                                                                 ReviewerName = "Mathew"
                                                             }
                                                     }

                                 });

            }
            this.DataContext = this;

        }
    }

    public class Review : INotifyPropertyChanged
    {
        private string _reviewerOrdinal;
        public string ReviewerOrdinal
        {
            get { return _reviewerOrdinal; }
            set
            {
                _reviewerOrdinal = value;
                NotifyPropertyChanged("ReviewerOrdinal");
            }
        }

        private ObservableCollection<Reviewer> _reviewers;
        public ObservableCollection<Reviewer> Reviewers
        {
            get { return _reviewers; }
            set
            {
                _reviewers = value;
                NotifyPropertyChanged("Reviewers");
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

