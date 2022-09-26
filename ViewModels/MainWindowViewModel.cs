using PruebaNivel;
using PruebaNivel.DAL;
using PruebaNivel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PruebaNivel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties
        private List<Measure> measures;

        public List<Measure> Measures
        {
            get
            {
                return measures;
            }
            set
            {
                if (measures == value)
                {
                    return;
                }
                measures = value;
                OnPropertyChanged("Measures");
            }
        }


        #endregion

        #region Commands
        private ICommand measureCommand;
        public ICommand MeasureCommand
        {
            get
            {
                if(null == measureCommand)
                {
                    measureCommand = new RelayCommand(param => this.MeasureCommandExecute(), null);
                }
                return measureCommand;
            }
        }
        #endregion

        public MainWindowViewModel()
        {

        }

        private void MeasureCommandExecute()
        {
            var readService = new ReadingService();
            var result = readService.GetMeasures();

            Measures = new List<Measure>(result);
        }

        private RelayCommand stopCommand;
        public ICommand StopCommand => stopCommand ??= new RelayCommand(Stop);

        private void Stop(object commandParameter)
        {
        }
    }
}
