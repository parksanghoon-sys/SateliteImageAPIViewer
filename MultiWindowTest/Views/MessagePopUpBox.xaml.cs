using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace MultiWindowTest.Views
{
    /// <summary>
    /// MessagePopUpBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MessagePopUpBox : UserControl
    {
        public enum EMessagePopUpBoxType
        {
            OK,
            YesNo,
            ConfirmDelete
        }
        public event RoutedEventHandler OKClick;
        public event RoutedEventHandler CancelClick;
        public event RoutedEventHandler DeleteClick;
        public MessagePopUpBox()
        {
            DefaultStyleKey= typeof(MessagePopUpBox);
            //InitializeComponent();
        }
        public static readonly DependencyProperty MessagePopUpTypeProperty =
            DependencyProperty.Register("MessagePopUpBoxType", typeof(EMessagePopUpBoxType), typeof(MessagePopUpBox), new PropertyMetadata());
        public EMessagePopUpBoxType MessagePopUpType
        {
            get { return (EMessagePopUpBoxType)this.GetValue(MessagePopUpTypeProperty); }
            set { this.SetValue(MessagePopUpTypeProperty, value); }
        }
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpenProperty", typeof(bool), typeof(MessagePopUpBox));
        public bool IsOpen
        {
            get => (bool)this.GetValue(IsOpenProperty);
            set => this.SetValue(IsOpenProperty, value);
        }
        public static readonly DependencyProperty IsBackgroundDisableProperty =
            DependencyProperty.Register("IsBackgroundDisable", typeof(bool), typeof(MessagePopUpBox), new PropertyMetadata(false));
        public bool IsBackgroundDisable
        {
            get { return (bool)this.GetValue(IsBackgroundDisableProperty); }
            set { this.SetValue(IsBackgroundDisableProperty, value); }
        }

        public static readonly DependencyProperty VAlignmentProperty =
            DependencyProperty.Register("VAlignment", typeof(VerticalAlignment), typeof(MessagePopUpBox), new PropertyMetadata(VerticalAlignment.Bottom));
        public VerticalAlignment VAlignment
        {
            get { return (VerticalAlignment)this.GetValue(VAlignmentProperty); }
            set { this.SetValue(VAlignmentProperty, value); }
        }
        public static readonly DependencyProperty HAlignmentProperty =
            DependencyProperty.Register("HAlignment", typeof(HorizontalAlignment), typeof(MessagePopUpBox), new PropertyMetadata(HorizontalAlignment.Right));
        public HorizontalAlignment HAlignment
        {
            get { return (HorizontalAlignment)this.GetValue(HAlignmentProperty); }
            set { this.SetValue(HAlignmentProperty, value); }
        }
        public ICommand CancelCommand
        {
            get => (ICommand)GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        public object CancelCommandParameter
        {
            get => (object)this.GetValue(CancelCommandParameterProperty);
            set => SetValue(CancelCommandParameterProperty, value);
        }
        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }
        public object DeleteCommandParameter
        {
            get => (object)this.GetValue(DeleteCommandParameterProperty);
            set => SetValue(DeleteCommandParameterProperty, value);
        }
        public ICommand OKCommand
        {
            get
            {
                return (ICommand)GetValue(OKCommandProperty);
            }
            set
            {
                SetValue(OKCommandProperty, value);
            }
        }

        public object OKCommandParameter
        {
            get { return (object)this.GetValue(OKCommandParameterProperty); }
            set { this.SetValue(OKCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(MessagePopUpBox), new UIPropertyMetadata(null));
        public static readonly DependencyProperty CancelCommandParameterProperty =
            DependencyProperty.Register("CancelCommandParameterProperty", typeof(object), typeof(MessagePopUpBox), new UIPropertyMetadata(null));

        public static readonly DependencyProperty OKCommandProperty =
            DependencyProperty.Register("OKCommandProperty", typeof(ICommand), typeof(MessagePopUpBox), new UIPropertyMetadata(null));
        public static readonly DependencyProperty OKCommandParameterProperty =
            DependencyProperty.Register("OKCommandParameterProperty", typeof(object), typeof(MessagePopUpBox), new UIPropertyMetadata(null));

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommandProperty", typeof(ICommand), typeof(MessagePopUpBox), new UIPropertyMetadata(null));
        public static readonly DependencyProperty DeleteCommandParameterProperty =
            DependencyProperty.Register("DeleteCommandParameterProperty", typeof(object), typeof(MessagePopUpBox), new UIPropertyMetadata(null));
    }
}
