using SampleApp.FreshMVVM.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class CarouselWithSVGPageModel : BasePageModel
    {
        private ObservableCollection<string> _list;
        public ObservableCollection<string> List
        {
            get { return _list; }
            set { SetPropertyValue(ref _list, value); }
        }
        private bool _leftBtnVisible;
        public bool LeftBtnVisible
        {
            get { return _leftBtnVisible; }
            set
            {
                _leftBtnVisible = value;
                RaisePropertyChanged();
            }
        }
        private bool _rightBtnVisible;
        public bool RightBtnVisible
        {
            get { return _rightBtnVisible; }
            set
            {
                _rightBtnVisible = value;
                RaisePropertyChanged();
            }
        }

        private bool _isSwipeEnable;
        public bool IsSwipeEnable
        {
            get { return _isSwipeEnable; }
            set
            {
                _isSwipeEnable = value;
                RaisePropertyChanged();
            }
        }

        private int _currenrtImagePosition;
        public int CurrenrtImagePosition
        {
            get { return _currenrtImagePosition; }
            set
            {
                _currenrtImagePosition = value;
                RaisePropertyChanged();
                SetBtnStatus(value);
            }
        }

        private void SetBtnStatus(int Position)
        {
            try
            {
                if (List != null && List.Any())
                {
                    var itemcount = List.Count - 1;

                    if (Position == 0)
                    {
                        LeftBtnVisible = false;
                        RightBtnVisible = true;
                    }

                    else if (Position == itemcount)
                    {
                        LeftBtnVisible = true;
                        RightBtnVisible = false;

                    }
                    else
                    {
                        LeftBtnVisible = true;
                        RightBtnVisible = true;
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        public ICommand RightCommand { get; set; }

        public ICommand LeftCommand { get; set; }
        public CarouselWithSVGPageModel()
        {
            RightCommand = new Command(RightClicked);

            LeftCommand = new Command(LeftClicked);
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            List = new ObservableCollection<string>();

            List.Add("https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/410.svg");
            List.Add("https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/android.svg");
            List.Add("https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/alphachannel.svg");

            CurrenrtImagePosition = 0;
            SetBtnStatus(0);

            IsSwipeEnable = true;


            //enable swipe on double tap
            MessagingCenter.Subscribe<CustomPanPinchToZoomContainer>(this, "Reset", (sender) =>
            {
                IsSwipeEnable = true;
            });


            //disable swipe on pan and pinch
            MessagingCenter.Subscribe<CustomPanPinchToZoomContainer>(this, "Zooming", (sender) =>
            {
                IsSwipeEnable = false;
            });


        }


        private void LeftClicked(object obj)
        {
            try
            {
                if (List != null && List.Any())
                {
                    CurrenrtImagePosition = CurrenrtImagePosition - 1;

                    //send message to reset image
                }
            }
            catch (Exception)
            {

            }

        }

        private void RightClicked(object obj)
        {
            try
            {
                if (List != null && List.Any())
                {
                    CurrenrtImagePosition = CurrenrtImagePosition + 1;
                    //send message to reset image

                }

            }
            catch (Exception)
            {

            }

        }
    }
}
