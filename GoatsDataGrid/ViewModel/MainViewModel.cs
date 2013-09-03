using GalaSoft.MvvmLight;
using GoatsDataGrid.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace GoatsDataGrid.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IGoatService _goatService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IGoatService goatService)
        {
            _goatService = goatService;
            NumberGoatsToAdd = 0;

            Goats = new ObservableCollection<Goat>();
        }

        public int NumberGoatsToAdd { get; set; }

        public ObservableCollection<Goat> Goats { get; private set; }

        private RelayCommand _addGoatsCommand;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand AddGoatsCommand
        {
            get
            {
                return _addGoatsCommand
                    ?? (_addGoatsCommand = new RelayCommand(
                () =>
                {
                    if(NumberGoatsToAdd >= 0)
                    {
                        var newGoats = _goatService.CreateGoats(NumberGoatsToAdd);
                        for (int i = 0; i < newGoats.Count; i++)
                        {
                            Goats.Add(newGoats[i]);
                        }
                    }
                }));
            }
        }
    }
}