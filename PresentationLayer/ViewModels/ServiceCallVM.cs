using PresentationLayer.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.ViewModels
{
    public class ServiceCallVM : ViewModelBase
    {
        #region | Field |
        private ServiceCall _model;
        #endregion | Field |


        #region | Properties |
        public ServiceCall Model { get
            {
                return _model;
            }
            internal set
            {
                if(!ServiceCall.Equals(_model, value))
                {
                    _model = value;
                    RaisePropertyChanged("CustomerFullName");
                    RaisePropertyChanged("CustomerPhone");

                    RaisePropertyChanged("OpenByFullName");
                    RaisePropertyChanged("Status");
                    RaisePropertyChanged("Priority");
                    RaisePropertyChanged("CloseByFullName");
                }
            }
        }
        public string CustomerFullName
        {
            get
            {
                return Model == null ? null : Model.Caller.FullName;
            }
        }

        public string CustomerPhone
        {
            get
            {
                return Model == null ? null : Model.Caller.Phone;
            }
        }

        //Model.OpenDate
        public string OpenByFullName
        {
            get
            {
                return Model == null || Model.OpenByAgent == null ? null : Model.OpenByAgent.FullName;
            }
        }

        public string Status
        {
            get
            {
                return Model == null || !Model.Status.HasValue ? null : Model.Status.Value.ToString("G");
            }
        }

        public string Priority
        {
            get
            {
                return Model == null || !Model.Priority.HasValue ? null : Model.Priority.Value.ToString("G");
            }
        }
        
        //Model.CloseDate
        public string CloseByFullName
        {
            get
            {
                return Model == null || Model.CloseByAgent==null ? null : Model.CloseByAgent.FullName;
            }
        }
        
        //Model.Issue
        //Model.Solution
        #endregion | Properties |

    }
}
