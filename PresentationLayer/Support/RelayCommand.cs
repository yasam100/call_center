using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.Support
{
    public sealed class RelayCommand : ICommand, IDisposable
    {
        #region | Events |
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion | Events |

        #region | Fields |
        private bool _disposedValue = false; // To detect redundant calls

        private Action<object> _relayAction = null;
        private Predicate<object> _relayPredicate = null;
        #endregion | Fields |

        #region | Constructors |
        public RelayCommand(Action<object> relayAction, Predicate<object> relayPredicate = null)
        {
            _relayAction = relayAction;
            _relayPredicate = relayPredicate;
        }
        #endregion | Constructors |

        #region | Methods |

        #region | ICommand Support |
        public bool CanExecute(object parameter)
        {
            bool canExecute = true;

            if (_relayPredicate != null)
                canExecute = _relayPredicate(parameter);
                        
            return canExecute;
        }

        public void Execute(object parameter)
        {
            if (_relayAction != null)
                _relayAction(parameter);
        }
        #endregion | ICommand Support |

        #region | IDisposable Support |


        void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects).
                    _relayAction = null;
                    _relayPredicate = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RelayCommand() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion | IDisposable Support |

        #endregion | Methods |
    }
}
