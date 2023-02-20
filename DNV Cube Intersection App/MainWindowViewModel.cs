using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.ApplicationsServices.Interfaces;
using Application.DTOs;
using DNV_Cube_Intersection_App.Command;

namespace DNV_Cube_Intersection_App
{
    /// <summary>
    /// 
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region properties

        public int Cube1CenterXCoordinate { get; set; }
        public int Cube1CenterYCoordinate { get; set; }
        public int Cube1CenterZCoordinate { get; set; }
        public int Cube1Dimension { get; set; }

        public int Cube2CenterXCoordinate { get; set; }
        public int Cube2CenterYCoordinate { get; set; }
        public int Cube2CenterZCoordinate { get; set; }
        public int Cube2Dimension { get; set; }

        private string _response = "Response space";
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
            }
        }

        private readonly IIntersectionApplicationService? _intersectionApplicationService;

        #endregion

        #region Constructors

        public MainWindowViewModel(IIntersectionApplicationService intersectionApplicationService)
        {
            _intersectionApplicationService = intersectionApplicationService ?? throw new ArgumentNullException(nameof(intersectionApplicationService));
        }

        #endregion

        #region Commands

        private RelayCommand? _intersectionCommand;
        public RelayCommand IntersectionCommand 
        {
            get
            {
                _intersectionCommand ??= new RelayCommand(IntersectionAction);
                return _intersectionCommand;
            }
        }

        private async void IntersectionAction(object param)
        {
            try
            {
                CubeRequest cube1 = new CubeRequest()
                {
                    Center = new CoordinateRequest(Cube1CenterXCoordinate, Cube1CenterYCoordinate, Cube1CenterZCoordinate),
                    Dimension = Cube1Dimension
                };
                CubeRequest cube2 = new CubeRequest()
                {
                    Center = new CoordinateRequest(Cube2CenterXCoordinate, Cube2CenterYCoordinate, Cube2CenterZCoordinate),
                    Dimension = Cube2Dimension
                };
                var intersectionResult = await _intersectionApplicationService.IntersectsAsync(cube1, cube2);
                if (intersectionResult)
                {
                    var intersectionVolume = await _intersectionApplicationService.IntersectionVolumeAsync(cube1, cube2);
                    Response = $"The intersected volume is: {intersectionVolume} units"; ;
                }
                else
                {
                    Response = "Don't intersect";
                }
            }
            catch (Exception ex)
            {
                Response = $"Exception thrown: {ex.Message}";
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
