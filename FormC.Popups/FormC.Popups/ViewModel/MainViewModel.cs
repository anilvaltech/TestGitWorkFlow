using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FormC.Popups.Model;
using System.Collections.Generic;
using System.Linq;

namespace FormC.Popups.ViewModel
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        void SetCustomerDetails(RowViewModel rowViewModel);
    }

    public class MainViewModel : IMainViewModel
    {
        private ObservableCollection<RowViewModel> _rowViewModels;
        public ObservableCollection<RowViewModel> RowViewModels
        {
            get { return _rowViewModels; }
            set { _rowViewModels = value; }
        }

        public List<CustomerDto> Customers { get; set; }

        private RowViewModel _selectedRowViewModel;
        public RowViewModel SelectedRowViewModel
        {
            get { return _selectedRowViewModel; }
            set
            {
                _selectedRowViewModel = value;
                NotifyPropertyChanged("SelectedRowViewModel");
            }
        }

        public MainViewModel()
        {
            RowViewModels = new ObservableCollection<RowViewModel>();
            QueryCustomerDTO();
            SelectedRowViewModel = RowViewModels.First();
            SelectedRowViewModel.Initialize(this);
        }

        private void QueryCustomerDTO()
        {
            Customers = new List<CustomerDto>{
                                        new CustomerDto
                                        {
                                            Id =  1,
                                            FirstName = "Mike",
                                            LastName = "Lancer",
                                            Age = 25,
                                            Address = "No 15, 11th Main",
                                            City = "Bangalore"
                                        },
                                        new CustomerDto
                                        {
                                            Id =  2,
                                            FirstName = "Mathew",
                                            LastName = "Paul",
                                            Age = 25,
                                            Address = "No 17, 25th Main",
                                            City = "Bangalore"
                                        },
                                        new CustomerDto
                                        {
                                            Id =  3,
                                            FirstName = "Andrus",
                                            LastName = "Roshan",
                                            Age = 25,
                                            Address = "No 17, 25th Main",
                                            City = "Bangalore"
                                        }
                                };
            foreach (var item in Customers)
            {
                RowViewModels.Add(new RowViewModel
                                      {
                                          Id = item.Id,
                                          FirstName = item.FirstName,
                                          Address = item.Address,
                                          Age = item.Age,
                                          City = item.City,
                                          LastName = item.LastName
                                      });
            }
        }

        public void SetCustomerDetails(RowViewModel rowViewModel)
        {
            var queryCustomer = Customers.SingleOrDefault(r => r.Id == rowViewModel.Id);
           
            if(queryCustomer!=null)
            {
                queryCustomer.Age = rowViewModel.Age;
                queryCustomer.City = rowViewModel.City;
                queryCustomer.FirstName = rowViewModel.FirstName;
                queryCustomer.LastName = rowViewModel.LastName;
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
