using PresentationLayer.Models;
using PresentationLayer.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Models.ContentLayerDummy;
using System.ComponentModel;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class DetailVM : ViewModelBase
    {
        #region | Event |

        #endregion | Event |

        #region | Fields |
        private IContentProvider<Customer> _customersContentProvider;
        private IContentProvider<Employee> _staffContentProvider;

        private ServiceCall _cacheModel;
        private ServiceCall _model;
        private int _selectedEmployeeIndex;
        private ICommand _cmdCustomerFind;
        private ICommand _cmdCustomerCreate;
        private ICommand _cmdCustomerEdit;
        #endregion | Fields |

        #region | Properties |
        public bool IsDirty
        {
            get
            {
                return ServiceCall.Dirty(_model, _cacheModel);
            }
        }

        public ServiceCall Model
        {
            get
            {
                return _model;
            }
            set
            {
                if(!ServiceCall.Equals(_model, value))
                {
                    _model = value;
                    _cacheModel = new ServiceCall(_model);
                    SelectedStatus = _model.Status.ToString();
                    SelectedPriority = _model.Priority.ToString();

                    BackgroundWorker bw = new BackgroundWorker();
                    bw.RunWorkerCompleted += (s, e) =>
                    {
                        int pos = (int)e.Result;
                        SelectedEmployeeIndex = pos;
                    };
                    bw.DoWork += (s, e) =>
                      {
                          int pos = -1;
                          int cntr = 0;
                          int qty = Staff.Count;
                          if (_model.CloseByAgent != null)
                          {
                              for (; cntr < qty; cntr++)
                              {
                                  if (Staff.ElementAt(cntr).Id == _model.CloseByAgent.Id)
                                  {
                                      pos = cntr;
                                      break;
                                  }
                              }
                          }
                          e.Result = pos;
                      };
                    bw.RunWorkerAsync();

                    RaisePropertyChanged();
                    RaisePropertyChanged("CustomerId");
                    RaisePropertyChanged("Issue");
                    RaisePropertyChanged("Solution");
                }
            }
        }

        public Nullable<int> CustomerId
        {
            get
            {
                return Model == null ? null : Model.CustomerId;
            }
            set
            {
                if ((Model != null && !Nullable.Equals(Model.CustomerId, value)))
                {
                    Model.CustomerId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string CustomerFirstName
        {
            get
            {
                return Model == null || Model.Caller == null ? null : Model.Caller.FirstName;
            }
            set
            {
                if (Model == null)
                    Model = new ServiceCall();
            }
        }

        public string CustomerLastName
        {
            get
            {
                return Model == null || Model.Caller == null ? null : Model.Caller.LastName;
            }
            set
            {
                if (Model == null)
                    Model = new ServiceCall();
            }
        }

        public string Issue
        {
            get
            {
                return Model == null ? null : Model.Issue;
            }
            set
            {
                if ((Model != null && string.Compare(Model.Issue, value) != 0))
                {
                    Model.Issue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Solution
        {
            get
            {
                return Model == null ? null : Model.Solution;
            }
            set
            {
                if((Model != null && string.Compare(Model.Solution, value) != 0))
                {
                    Model.Solution = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICollection<string> Statuses
        {
            get
            {
                return Enum.GetNames(typeof(StatusType));
            }
        }

        public ICollection<string> Priorities
        {
            get
            {
                return Enum.GetNames(typeof(PriorityType));
            }
        }

        public ICollection<Employee> Staff
        {
            get
            {
                return _staffContentProvider.Query().OrderBy(e => e.FullName).ToList();
            }
        }



        public string SelectedStatus
        {
            get
            {
                return Model == null || Model.Status == null ? null : Model.Status.ToString();
            }
            set
            {
                if(Model!=null)
                {
                    if(!string.Equals(Model.Status, value) && !string.IsNullOrEmpty(value))
                    {
                        Model.Status = (StatusType)Enum.Parse(typeof(StatusType), value);
                        RaisePropertyChanged();
                    }
                }
            }
        }
        public string SelectedPriority
        {
            get
            {
                return Model == null || Model.Priority == null ? null : Model.Priority.ToString();
            }
            set
            {
                if (Model != null)
                {
                    if (!string.Equals(Model.Priority, value) && !string.IsNullOrEmpty(value))
                    {
                        Model.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), value);
    
                        RaisePropertyChanged();
                    }
                }
            }
        }
        public Employee SelectedEmployee
        {
            get
            {
                return Model == null ? null : Model.CloseByAgent;
            }
            set
            {
                if (Model != null)
                {
                    if (!Employee.Equals(Model.CloseByAgent, value))
                    {
                        Model.CloseByAgent = value;

                        if (Model.CloseByAgent == null)
                            Model.CloseByAgentId = null;
                        else
                            Model.CloseByAgentId = Model.CloseByAgent.Id;

                        RaisePropertyChanged();
                    }
                }
            }
        }

        public int SelectedEmployeeIndex
        {
            get
            {
                return _selectedEmployeeIndex;
            }
            set
            {
                if(_selectedEmployeeIndex!=value)
                {
                    _selectedEmployeeIndex = value;
                    RaisePropertyChanged();
                }
            }

        }


        public ICommand CmdCustomerFind
        {
            get
            {
                return _cmdCustomerFind ?? (_cmdCustomerFind = new RelayCommand(ExecCmdCustomerFind, CanExecCmdCustomerFind));
            }
        }

        public ICommand CmdCustomerCreate
        {
            get
            {
                return _cmdCustomerCreate ?? (_cmdCustomerCreate = new RelayCommand(ExecCmdCustomerCreate));
            }
        }
        public ICommand CmdCustomerEdit
        {
            get
            {
                return _cmdCustomerEdit ?? (_cmdCustomerEdit = new RelayCommand(ExecCmdCustomerEdit, CanExecCmdCustomerEdit));
            }
        }
        #endregion | Properties |

        #region | Constructors |
        public DetailVM(IContentProvider<Customer> customersContentProvider, IContentProvider<Employee> staffContentProvider)
        {
            _customersContentProvider = customersContentProvider;
            _staffContentProvider = staffContentProvider;
            Model = new ServiceCall();
        }
        #endregion | Constructors |

        #region | Methods |
        private void ExecCmdCustomerFind(object p)
        {

        }

        private bool CanExecCmdCustomerFind(object p)
        {
            bool canExecute = false;
            if (CustomerId != null && CustomerId.HasValue)
                canExecute = true;
            if(Model!=null && Model.Caller!=null && canExecute && CustomerId == Model.Caller.Id)
            {
                canExecute = false;
            }
            return canExecute;
        }

        private void ExecCmdCustomerCreate(object p)
        {

        }
        
        private void ExecCmdCustomerEdit(object p)
        {

        }

        private bool CanExecCmdCustomerEdit(object p)
        {
            bool canExecute = false;
            if (Model != null && Model.Caller != null)
                canExecute = true;
            return canExecute;
        }
        #endregion | Methods |

    }
}
