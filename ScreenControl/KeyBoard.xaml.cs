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

namespace SreenControl
{
    /// <summary>
    /// KeyBoard.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoard : UserControl
    {
        public KeyBoard()
        {
            InitializeComponent();
            this.DataContext = this;
            SetCommandBinding();
            this.Width = WidthTouchKeyboard;
            this.Height = HeightTouchKeyboard;
        }
        static ButtonProperty ButtonProperty = new ButtonProperty();
        //键盘大小
        static Dictionary<FrameworkElement, bool> KeyMode = new Dictionary<FrameworkElement, bool>();
        //键盘按键圆角
        static Dictionary<FrameworkElement, CornerRadius> ButtonCorner = new Dictionary<FrameworkElement, CornerRadius>();
        //键盘圆角
        static Dictionary<FrameworkElement, CornerRadius> BoardCorner = new Dictionary<FrameworkElement, CornerRadius>();
        //键盘按键背景色
        static Dictionary<FrameworkElement, Brush> ButtonBackground = new Dictionary<FrameworkElement, Brush>();
        //键盘按键前景色
        static Dictionary<FrameworkElement, Brush> ButtonForeground = new Dictionary<FrameworkElement, Brush>();
        //阴影前景色
        static Dictionary<FrameworkElement, Brush> ShadowForeground = new Dictionary<FrameworkElement, Brush>();
        //悬停前景色
        static Dictionary<FrameworkElement, Brush> MouseOverForeground = new Dictionary<FrameworkElement, Brush>();
        //悬停背景色
        static Dictionary<FrameworkElement, Brush> MouseOverBackground = new Dictionary<FrameworkElement, Brush>();
        //点击背景色
        static Dictionary<FrameworkElement, Brush> PressedBackground = new Dictionary<FrameworkElement, Brush>();
        //键盘背景色
        static Dictionary<FrameworkElement, Brush> BoardBackground = new Dictionary<FrameworkElement, Brush>();
        #region Property & Variable & Constructor

        #region 键盘按钮样式
        public static Brush GetButtonBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ButtonBackgroundProperty);
        }

        public static void SetButtonBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ButtonBackgroundProperty, value);
        }
        /// <summary>
        /// 按钮背景色
        /// </summary>
        private static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.RegisterAttached("ButtonBackground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.Black, new PropertyChangedCallback(Callback_ChangeBackground)));

        private static void Callback_ChangeBackground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.ButtonBackground = (Brush)e.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!ButtonBackground.ContainsKey(frameworkElement))
                ButtonBackground.Add(frameworkElement, (Brush)e.NewValue);
        }

        public static Brush GetButtonForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ButtonForegroundProperty);
        }

        public static void SetButtonForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ButtonForegroundProperty, value);
        }
        /// <summary>
        /// 按钮前景色
        /// </summary>
        private static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.RegisterAttached("ButtonForeground", typeof(Brush), typeof(KeyBoard), new FrameworkPropertyMetadata(Brushes.White, new PropertyChangedCallback(CallBack_ButtonForeground)));

        private static void CallBack_ButtonForeground(DependencyObject d, DependencyPropertyChangedEventArgs baseValue)
        {
            ButtonProperty.ButtonForeground = (Brush)baseValue.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!ButtonForeground.ContainsKey(frameworkElement))
                ButtonForeground.Add(frameworkElement, (Brush)baseValue.NewValue);
        }

        public static Brush GetShadowForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ShadowForegroundProperty);
        }

        public static void SetShadowForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ShadowForegroundProperty, value);
        }
        /// <summary>
        /// 按钮前景色
        /// </summary>
        private static readonly DependencyProperty ShadowForegroundProperty =
            DependencyProperty.RegisterAttached("ShadowForeground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.Gray, new PropertyChangedCallback(CallBack_ShadowForeground)));

        private static void CallBack_ShadowForeground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.ShadowForeground = (Brush)e.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!ShadowForeground.ContainsKey(frameworkElement))
                ShadowForeground.Add(frameworkElement, (Brush)e.NewValue);
        }
        #region 弃用属性

        //public static Brush GetButtonBorderBrush(DependencyObject obj)
        //{
        //    return (Brush)obj.GetValue(ButtonBorderBrushProperty);
        //}

        //public static void SetButtonBorderBrush(DependencyObject obj, Brush value)
        //{
        //    obj.SetValue(ButtonBorderBrushProperty, value);
        //}
        ///// <summary>
        ///// 按钮边框颜色
        ///// </summary>
        //private static readonly DependencyProperty ButtonBorderBrushProperty =
        //    DependencyProperty.RegisterAttached("ButtonBorderBrush", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.Gray, new PropertyChangedCallback(CallBack_ButtonBorderBrush)));

        //private static void CallBack_ButtonBorderBrush(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ButtonProperty.ButtonBorderBrush = (Brush)e.NewValue;
        //}

        //public static Thickness GetButtonBorderThickness(DependencyObject obj)
        //{
        //    return (Thickness)obj.GetValue(ButtonBorderThicknessProperty);
        //}

        //public static void SetButtonBorderThickness(DependencyObject obj, Thickness value)
        //{
        //    obj.SetValue(ButtonBorderThicknessProperty, value);
        //}
        ///// <summary>
        ///// 按钮边框厚度
        ///// </summary>
        //private static readonly DependencyProperty ButtonBorderThicknessProperty =
        //    DependencyProperty.RegisterAttached("ButtonBorderThickness", typeof(Thickness), typeof(KeyBoard), new PropertyMetadata(new Thickness(0,0,0,0), new PropertyChangedCallback(CallBack_Thickness)));

        //private static void CallBack_Thickness(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ButtonProperty.ButtonBorderThickness = (double)e.NewValue;
        //}
        #endregion

        public static Brush GetMouseOverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverForegroundProperty);
        }

        public static void SetMouseOverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverForegroundProperty, value);
        }
        /// <summary>
        /// 悬停前景色
        /// </summary>
        private static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.DarkGray, new PropertyChangedCallback(CallBack_MouseOverForeground)));

        private static void CallBack_MouseOverForeground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.MouseOverForeground = (Brush)e.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!MouseOverForeground.ContainsKey(frameworkElement))
                MouseOverForeground.Add(frameworkElement, (Brush)e.NewValue);
        }

        public static Brush GetMouseOverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBackgroundProperty);
        }

        public static void SetMouseOverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBackgroundProperty, value);
        }
        /// <summary>
        /// 悬停背景色
        /// </summary>
        private static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.White, new PropertyChangedCallback(CallBack_MouseOverBackground)));

        private static void CallBack_MouseOverBackground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.MouseOverBackground = (Brush)e.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!MouseOverBackground.ContainsKey(frameworkElement))
                MouseOverBackground.Add(frameworkElement, (Brush)e.NewValue);
        }

        public static Brush GetPressedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PressedBackgroundProperty);
        }

        public static void SetPressedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PressedBackgroundProperty, value);
        }
        /// <summary>
        /// 按下背景色
        /// </summary>
        private static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.Gray, new PropertyChangedCallback(CallBack_PressedForeground)));

        private static void CallBack_PressedForeground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.PressedBackground = (Brush)e.NewValue;
            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!PressedBackground.ContainsKey(frameworkElement))
                PressedBackground.Add(frameworkElement, (Brush)e.NewValue);
        }

        public static Brush GetFocusedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedBorderBrushProperty, value);
        }
        /// <summary>
        /// 焦点边框色
        /// </summary>
        private static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.Gray, new PropertyChangedCallback(CallBack_FoucsedBorderBrush)));

        private static void CallBack_FoucsedBorderBrush(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.FocusedBorderBrush = (Brush)e.NewValue;
        }
        #endregion

        #region 键盘背景色
        public static Brush GetBoardBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BoardBackgroundProperty);
        }

        public static void SetBoardBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(BoardBackgroundProperty, value);
        }


        /// <summary>
        /// 键盘背景色
        /// </summary>
        public static readonly DependencyProperty BoardBackgroundProperty =
            DependencyProperty.RegisterAttached("BoardBackground", typeof(Brush), typeof(KeyBoard), new PropertyMetadata(Brushes.DarkGray, new PropertyChangedCallback(CallBack_BoardBackground)));

        private static void CallBack_BoardBackground(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonProperty.BoardBackground = (Brush)e.NewValue;

            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!BoardBackground.ContainsKey(frameworkElement))
                BoardBackground.Add(frameworkElement, (Brush)e.NewValue);
        }

        #endregion

        #region CornerRadius
        public static CornerRadius GetButtonCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(ButtonCornerRadiusProperty);
        }

        public static void SetButtonCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ButtonCornerRadiusProperty, value);
        }

        /// <summary>
        /// 按钮圆角设置
        /// </summary>
        public static readonly DependencyProperty ButtonCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ButtonCornerRadius", typeof(CornerRadius), typeof(KeyBoard), new PropertyMetadata(new CornerRadius(0), new PropertyChangedCallback(CallBack_CornerRadius)));

        private static void CallBack_CornerRadius(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!ButtonCorner.ContainsKey(frameworkElement))
                ButtonCorner.Add(frameworkElement, (CornerRadius)e.NewValue);
        }

        public static CornerRadius GetBoardCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(BoardCornerRadiusProperty);
        }

        public static void SetBoardCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ButtonCornerRadiusProperty, value);
        }

        /// <summary>
        /// 圆角设置
        /// </summary>
        public static readonly DependencyProperty BoardCornerRadiusProperty =
            DependencyProperty.RegisterAttached("BoardCornerRadius", typeof(CornerRadius), typeof(KeyBoard), new PropertyMetadata(new CornerRadius(0), new PropertyChangedCallback(CallBack_BoardCornerRadius)));

        private static void CallBack_BoardCornerRadius(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = d as FrameworkElement;
            if (!BoardCorner.ContainsKey(frameworkElement))
                BoardCorner.Add(frameworkElement, (CornerRadius)e.NewValue);
        }
        #endregion


        private static double _WidthTouchKeyboard = 830;

        private static double _heightTouchKeyboard = 300;

        public static double HeightTouchKeyboard
        {
            get { return _heightTouchKeyboard; }
            set { _heightTouchKeyboard = value; }
        }

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeyboard; }
            set { _WidthTouchKeyboard = value; }

        }
        private static bool _ShiftFlag;

        protected static bool ShiftFlag
        {
            get { return _ShiftFlag; }
            set { _ShiftFlag = value; }
        }

        private static bool _CapsLockFlag;

        protected static bool CapsLockFlag
        {
            get { return KeyBoard._CapsLockFlag; }
            set { KeyBoard._CapsLockFlag = value; }
        }

        private static Window _InstanceObject;
        private static UserControl _KeyBoard;

        private static Brush _PreviousTextBoxBorderBrush = null;
        private static Thickness _PreviousTextBoxBorderThickness;

        private static Control _CurrentControl;
        public static string TouchScreenText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox)_CurrentControl).Password;
                }
                else if (_CurrentControl is ComboBox)
                {
                    return ((ComboBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is DataGrid)
                {
                    return (((DataGrid)_CurrentControl).CurrentColumn.GetCellContent(((DataGrid)_CurrentControl).CurrentItem) as TextBlock).Text;
                }
                else if (_CurrentControl is RichTextBox)
                {
                    var run = (((RichTextBox)_CurrentControl).Selection.Start.Parent as Run);
                    string txt = string.Empty;
                    if (run != null)
                        txt = run.Text;
                    return txt;
                    //return new TextRange(((RichTextBox)_CurrentControl).Document.ContentStart, ((RichTextBox)_CurrentControl).Document.ContentEnd).Text;
                }
                else if (_CurrentControl is Button)
                {
                    return ((Button)_CurrentControl).Content.ToString();
                }
                else return "";


            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox)_CurrentControl).Password = value;
                }
                else if (_CurrentControl is ComboBox)
                {
                    ((ComboBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is DataGrid)
                {
                    (((DataGrid)_CurrentControl).CurrentColumn.GetCellContent(((DataGrid)_CurrentControl).CurrentItem) as TextBlock).Text = value;
                }
                else if (_CurrentControl is RichTextBox)
                {
                    ((RichTextBox)_CurrentControl).Document.Blocks.Clear();
                    ((RichTextBox)_CurrentControl).AppendText(value);
                }
                else if (_CurrentControl is Button)
                {
                    ((Button)_CurrentControl).Content = value;
                }


            }

        }

        #region 绑定按钮命令

        #region 数字键盘

        public static RoutedUICommand PadCmd1 = new RoutedUICommand();
        public static RoutedUICommand PadCmd2 = new RoutedUICommand();
        public static RoutedUICommand PadCmd3 = new RoutedUICommand();
        public static RoutedUICommand PadCmd4 = new RoutedUICommand();
        public static RoutedUICommand PadCmd5 = new RoutedUICommand();
        public static RoutedUICommand PadCmd6 = new RoutedUICommand();
        public static RoutedUICommand PadCmd7 = new RoutedUICommand();
        public static RoutedUICommand PadCmd8 = new RoutedUICommand();
        public static RoutedUICommand PadCmd9 = new RoutedUICommand();
        public static RoutedUICommand PadCmd0 = new RoutedUICommand();
        public static RoutedUICommand PadCmdDot = new RoutedUICommand();


        public static RoutedUICommand PadCmdEnter = new RoutedUICommand();

        public static RoutedUICommand PadCmdClear = new RoutedUICommand();
        public static RoutedUICommand PadCmdClose = new RoutedUICommand();
        #endregion

        #region 全键盘
        public static RoutedUICommand CmdTlide = new RoutedUICommand();
        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand CmdMinus = new RoutedUICommand();
        public static RoutedUICommand CmdPlus = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();
        public static RoutedUICommand CmdDot = new RoutedUICommand();


        public static RoutedUICommand CmdTab = new RoutedUICommand();
        public static RoutedUICommand CmdQ = new RoutedUICommand();
        public static RoutedUICommand Cmdw = new RoutedUICommand();
        public static RoutedUICommand CmdE = new RoutedUICommand();
        public static RoutedUICommand CmdR = new RoutedUICommand();
        public static RoutedUICommand CmdT = new RoutedUICommand();
        public static RoutedUICommand CmdY = new RoutedUICommand();
        public static RoutedUICommand CmdU = new RoutedUICommand();
        public static RoutedUICommand CmdI = new RoutedUICommand();
        public static RoutedUICommand CmdO = new RoutedUICommand();
        public static RoutedUICommand CmdP = new RoutedUICommand();
        public static RoutedUICommand CmdOpenCrulyBrace = new RoutedUICommand();
        public static RoutedUICommand CmdEndCrultBrace = new RoutedUICommand();
        public static RoutedUICommand CmdOR = new RoutedUICommand();

        public static RoutedUICommand CmdCapsLock = new RoutedUICommand();
        public static RoutedUICommand CmdA = new RoutedUICommand();
        public static RoutedUICommand CmdS = new RoutedUICommand();
        public static RoutedUICommand CmdD = new RoutedUICommand();
        public static RoutedUICommand CmdF = new RoutedUICommand();
        public static RoutedUICommand CmdG = new RoutedUICommand();
        public static RoutedUICommand CmdH = new RoutedUICommand();
        public static RoutedUICommand CmdJ = new RoutedUICommand();
        public static RoutedUICommand CmdK = new RoutedUICommand();
        public static RoutedUICommand CmdL = new RoutedUICommand();
        public static RoutedUICommand CmdColon = new RoutedUICommand();
        public static RoutedUICommand CmdDoubleInvertedComma = new RoutedUICommand();
        public static RoutedUICommand CmdEnter = new RoutedUICommand();

        public static RoutedUICommand CmdShift = new RoutedUICommand();
        public static RoutedUICommand CmdZ = new RoutedUICommand();
        public static RoutedUICommand CmdX = new RoutedUICommand();
        public static RoutedUICommand CmdC = new RoutedUICommand();
        public static RoutedUICommand CmdV = new RoutedUICommand();
        public static RoutedUICommand CmdB = new RoutedUICommand();
        public static RoutedUICommand CmdN = new RoutedUICommand();
        public static RoutedUICommand CmdM = new RoutedUICommand();
        public static RoutedUICommand CmdGreaterThan = new RoutedUICommand();
        public static RoutedUICommand CmdLessThan = new RoutedUICommand();
        public static RoutedUICommand CmdQuestion = new RoutedUICommand();



        public static RoutedUICommand CmdSpaceBar = new RoutedUICommand();
        public static RoutedUICommand CmdClear = new RoutedUICommand();
        public static RoutedUICommand CmdClose = new RoutedUICommand();
        #endregion
        #endregion

        #endregion
        #region CommandRelatedCode
        /// <summary>
        /// 设置按钮命令绑定
        /// </summary>
        private static void SetCommandBinding()
        {

            #region 小键盘
            CommandBinding PadCb1 = new CommandBinding(PadCmd1, RunCommand_Pad);
            CommandBinding PadCb2 = new CommandBinding(PadCmd2, RunCommand_Pad);
            CommandBinding PadCb3 = new CommandBinding(PadCmd3, RunCommand_Pad);
            CommandBinding PadCb4 = new CommandBinding(PadCmd4, RunCommand_Pad);
            CommandBinding PadCb5 = new CommandBinding(PadCmd5, RunCommand_Pad);
            CommandBinding PadCb6 = new CommandBinding(PadCmd6, RunCommand_Pad);
            CommandBinding PadCb7 = new CommandBinding(PadCmd7, RunCommand_Pad);
            CommandBinding PadCb8 = new CommandBinding(PadCmd8, RunCommand_Pad);
            CommandBinding PadCb9 = new CommandBinding(PadCmd9, RunCommand_Pad);
            CommandBinding PadCb0 = new CommandBinding(PadCmd0, RunCommand_Pad);
            CommandBinding PadCbDot = new CommandBinding(PadCmdDot, RunCommand_Pad);


            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb1);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb2);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb3);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb4);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb5);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb6);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb7);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb8);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb9);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCb0);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCbDot);


            CommandBinding PadCbEnter = new CommandBinding(PadCmdEnter, RunCommand_Pad);

            CommandBinding PadCbClear = new CommandBinding(PadCmdClear, RunCommand_Pad);
            CommandBinding PadCbClose = new CommandBinding(PadCmdClose, RunCommand_Pad);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCbEnter);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCbClear);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), PadCbClose);
            #endregion
            #region 全键盘
            CommandBinding CbTlide = new CommandBinding(CmdTlide, RunCommand);
            CommandBinding Cb1 = new CommandBinding(Cmd1, RunCommand);
            CommandBinding Cb2 = new CommandBinding(Cmd2, RunCommand);
            CommandBinding Cb3 = new CommandBinding(Cmd3, RunCommand);
            CommandBinding Cb4 = new CommandBinding(Cmd4, RunCommand);
            CommandBinding Cb5 = new CommandBinding(Cmd5, RunCommand);
            CommandBinding Cb6 = new CommandBinding(Cmd6, RunCommand);
            CommandBinding Cb7 = new CommandBinding(Cmd7, RunCommand);
            CommandBinding Cb8 = new CommandBinding(Cmd8, RunCommand);
            CommandBinding Cb9 = new CommandBinding(Cmd9, RunCommand);
            CommandBinding Cb0 = new CommandBinding(Cmd0, RunCommand);
            CommandBinding CbMinus = new CommandBinding(CmdMinus, RunCommand);
            CommandBinding CbPlus = new CommandBinding(CmdPlus, RunCommand);
            CommandBinding CbBackspace = new CommandBinding(CmdBackspace, RunCommand);
            CommandBinding CbDot = new CommandBinding(CmdDot, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbTlide);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb1);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb2);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb3);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb4);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb5);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb6);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb7);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb8);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb9);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cb0);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbDot);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbMinus);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbPlus);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbBackspace);


            CommandBinding CbTab = new CommandBinding(CmdTab, RunCommand);
            CommandBinding CbQ = new CommandBinding(CmdQ, RunCommand);
            CommandBinding Cbw = new CommandBinding(Cmdw, RunCommand);
            CommandBinding CbE = new CommandBinding(CmdE, RunCommand);
            CommandBinding CbR = new CommandBinding(CmdR, RunCommand);
            CommandBinding CbT = new CommandBinding(CmdT, RunCommand);
            CommandBinding CbY = new CommandBinding(CmdY, RunCommand);
            CommandBinding CbU = new CommandBinding(CmdU, RunCommand);
            CommandBinding CbI = new CommandBinding(CmdI, RunCommand);
            CommandBinding Cbo = new CommandBinding(CmdO, RunCommand);
            CommandBinding CbP = new CommandBinding(CmdP, RunCommand);
            CommandBinding CbOpenCrulyBrace = new CommandBinding(CmdOpenCrulyBrace, RunCommand);
            CommandBinding CbEndCrultBrace = new CommandBinding(CmdEndCrultBrace, RunCommand);
            CommandBinding CbOR = new CommandBinding(CmdOR, RunCommand);

            CommandBinding CbCapsLock = new CommandBinding(CmdCapsLock, RunCommand);
            CommandBinding CbA = new CommandBinding(CmdA, RunCommand);
            CommandBinding CbS = new CommandBinding(CmdS, RunCommand);
            CommandBinding CbD = new CommandBinding(CmdD, RunCommand);
            CommandBinding CbF = new CommandBinding(CmdF, RunCommand);
            CommandBinding CbG = new CommandBinding(CmdG, RunCommand);
            CommandBinding CbH = new CommandBinding(CmdH, RunCommand);
            CommandBinding CbJ = new CommandBinding(CmdJ, RunCommand);
            CommandBinding CbK = new CommandBinding(CmdK, RunCommand);
            CommandBinding CbL = new CommandBinding(CmdL, RunCommand);
            CommandBinding CbColon = new CommandBinding(CmdColon, RunCommand);
            CommandBinding CbDoubleInvertedComma = new CommandBinding(CmdDoubleInvertedComma, RunCommand);
            CommandBinding CbEnter = new CommandBinding(CmdEnter, RunCommand);

            CommandBinding CbShift = new CommandBinding(CmdShift, RunCommand);
            CommandBinding CbZ = new CommandBinding(CmdZ, RunCommand);
            CommandBinding CbX = new CommandBinding(CmdX, RunCommand);
            CommandBinding CbC = new CommandBinding(CmdC, RunCommand);
            CommandBinding CbV = new CommandBinding(CmdV, RunCommand);
            CommandBinding CbB = new CommandBinding(CmdB, RunCommand);
            CommandBinding CbN = new CommandBinding(CmdN, RunCommand);
            CommandBinding CbM = new CommandBinding(CmdM, RunCommand);
            CommandBinding CbGreaterThan = new CommandBinding(CmdGreaterThan, RunCommand);
            CommandBinding CbLessThan = new CommandBinding(CmdLessThan, RunCommand);
            CommandBinding CbQuestion = new CommandBinding(CmdQuestion, RunCommand);



            CommandBinding CbSpaceBar = new CommandBinding(CmdSpaceBar, RunCommand);
            CommandBinding CbClear = new CommandBinding(CmdClear, RunCommand);
            CommandBinding CbClose = new CommandBinding(CmdClose, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbTab);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbQ);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cbw);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbE);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbR);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbT);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbY);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbU);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbI);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), Cbo);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbP);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbOpenCrulyBrace);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbEndCrultBrace);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbOR);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbCapsLock);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbA);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbS);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbD);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbF);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbG);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbH);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbJ);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbK);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbL);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbColon);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbDoubleInvertedComma);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbEnter);

            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbShift);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbZ);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbX);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbC);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbV);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbB);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbN);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbM);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbGreaterThan);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbLessThan);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbQuestion);



            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbSpaceBar);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbClear);
            CommandManager.RegisterClassCommandBinding(typeof(KeyBoard), CbClose);
            #endregion
        }
        /// <summary>
        /// 小键盘点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void RunCommand_Pad(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == PadCmd1)
            {
                KeyBoard.TouchScreenText += "1";
            }
            else if (e.Command == PadCmd2)
            {
                KeyBoard.TouchScreenText += "2";

            }
            else if (e.Command == PadCmd3)
            {
                KeyBoard.TouchScreenText += "3";

            }
            else if (e.Command == PadCmd4)
            {
                KeyBoard.TouchScreenText += "4";
            }
            else if (e.Command == PadCmd5)
            {
                KeyBoard.TouchScreenText += "5";
            }
            else if (e.Command == PadCmd6)
            {
                KeyBoard.TouchScreenText += "6";
            }
            else if (e.Command == PadCmd7)
            {
                KeyBoard.TouchScreenText += "7";
            }
            else if (e.Command == PadCmd8)
            {
                KeyBoard.TouchScreenText += "8";
            }
            else if (e.Command == PadCmd9)
            {
                KeyBoard.TouchScreenText += "9";
            }
            else if (e.Command == PadCmd0)
            {
                KeyBoard.TouchScreenText += "0";
            }
            else if (e.Command == PadCmdDot)
            {
                TouchScreenText += ".";
            }
            else if (e.Command == PadCmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //System.Windows.Input.Keyboard.ClearFocus();

            }
            else if (e.Command == PadCmdClear)//Last row
            {
                KeyBoard.TouchScreenText = null;
            }
            else if (e.Command == PadCmdClose)
            {
                //OnLostFocus(_CurrentControl, null);
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
        //按钮点击事件
        static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Command == CmdTlide)  //First Row
            {


                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "`";
                }
                else
                {
                    KeyBoard.TouchScreenText += "~";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == Cmd1)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "1";
                }
                else
                {
                    KeyBoard.TouchScreenText += "!";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd2)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "2";
                }
                else
                {
                    KeyBoard.TouchScreenText += "@";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd3)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "3";
                }
                else
                {
                    KeyBoard.TouchScreenText += "#";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd4)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "4";
                }
                else
                {
                    KeyBoard.TouchScreenText += "$";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd5)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "5";
                }
                else
                {
                    KeyBoard.TouchScreenText += "%";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd6)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "6";
                }
                else
                {
                    KeyBoard.TouchScreenText += "^";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd7)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "7";
                }
                else
                {
                    KeyBoard.TouchScreenText += "&";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd8)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "8";
                }
                else
                {
                    KeyBoard.TouchScreenText += "*";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd9)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "9";
                }
                else
                {
                    KeyBoard.TouchScreenText += "(";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd0)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "0";
                }
                else
                {
                    KeyBoard.TouchScreenText += ")";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdMinus)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "-";
                }
                else
                {
                    KeyBoard.TouchScreenText += "_";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdPlus)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "=";
                }
                else
                {
                    KeyBoard.TouchScreenText += "+";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdDot)
            {
                TouchScreenText += ".";
            }
            else if (e.Command == CmdBackspace)
            {
                if (!string.IsNullOrEmpty(KeyBoard.TouchScreenText))
                {
                    KeyBoard.TouchScreenText = KeyBoard.TouchScreenText.Substring(0, KeyBoard.TouchScreenText.Length - 1);
                }

            }
            else if (e.Command == CmdTab)  //Second Row
            {
                KeyBoard.TouchScreenText += "     ";
            }
            else if (e.Command == CmdQ)
            {
                AddKeyBoardINput('Q');
            }
            else if (e.Command == Cmdw)
            {
                AddKeyBoardINput('w');
            }
            else if (e.Command == CmdE)
            {
                AddKeyBoardINput('E');
            }
            else if (e.Command == CmdR)
            {
                AddKeyBoardINput('R');
            }
            else if (e.Command == CmdT)
            {
                AddKeyBoardINput('T');
            }
            else if (e.Command == CmdY)
            {
                AddKeyBoardINput('Y');
            }
            else if (e.Command == CmdU)
            {
                AddKeyBoardINput('U');

            }
            else if (e.Command == CmdI)
            {
                AddKeyBoardINput('I');
            }
            else if (e.Command == CmdO)
            {
                AddKeyBoardINput('O');
            }
            else if (e.Command == CmdP)
            {
                AddKeyBoardINput('P');
            }
            else if (e.Command == CmdOpenCrulyBrace)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "[";
                }
                else
                {
                    KeyBoard.TouchScreenText += "{";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdEndCrultBrace)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "]";
                }
                else
                {
                    KeyBoard.TouchScreenText += "}";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdOR)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += @"\";
                }
                else
                {
                    KeyBoard.TouchScreenText += "|";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdCapsLock)  ///Third ROw
            {

                if (!CapsLockFlag)
                {
                    CapsLockFlag = true;
                }
                else
                {
                    CapsLockFlag = false;

                }
            }
            else if (e.Command == CmdA)
            {
                AddKeyBoardINput('A');
            }
            else if (e.Command == CmdS)
            {
                AddKeyBoardINput('S');
            }
            else if (e.Command == CmdD)
            {
                AddKeyBoardINput('D');
            }
            else if (e.Command == CmdF)
            {
                AddKeyBoardINput('F');
            }
            else if (e.Command == CmdG)
            {
                AddKeyBoardINput('G');
            }
            else if (e.Command == CmdH)
            {
                AddKeyBoardINput('H');
            }
            else if (e.Command == CmdJ)
            {
                AddKeyBoardINput('J');
            }
            else if (e.Command == CmdK)
            {
                AddKeyBoardINput('K');
            }
            else if (e.Command == CmdL)
            {
                AddKeyBoardINput('L');

            }
            else if (e.Command == CmdColon)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += ";";
                }
                else
                {
                    KeyBoard.TouchScreenText += ":";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdDoubleInvertedComma)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "'";
                }
                else
                {
                    KeyBoard.TouchScreenText += Char.ConvertFromUtf32(34);
                    ShiftFlag = false;
                }


            }
            else if (e.Command == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //System.Windows.Input.Keyboard.ClearFocus();

            }
            else if (e.Command == CmdShift) //Fourth Row
            {

                ShiftFlag = true; ;


            }
            else if (e.Command == CmdZ)
            {
                AddKeyBoardINput('Z');

            }
            else if (e.Command == CmdX)
            {
                AddKeyBoardINput('X');

            }
            else if (e.Command == CmdC)
            {
                AddKeyBoardINput('C');

            }
            else if (e.Command == CmdV)
            {
                AddKeyBoardINput('V');

            }
            else if (e.Command == CmdB)
            {
                AddKeyBoardINput('B');

            }
            else if (e.Command == CmdN)
            {
                AddKeyBoardINput('N');

            }
            else if (e.Command == CmdM)
            {
                AddKeyBoardINput('M');

            }
            else if (e.Command == CmdLessThan)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += ",";
                }
                else
                {
                    KeyBoard.TouchScreenText += "<";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdGreaterThan)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += ".";
                }
                else
                {
                    KeyBoard.TouchScreenText += ">";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdQuestion)
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += "/";
                }
                else
                {
                    KeyBoard.TouchScreenText += "?";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdSpaceBar)//Last row
            {

                KeyBoard.TouchScreenText += " ";
            }
            else if (e.Command == CmdClear)//Last row
            {
                KeyBoard.TouchScreenText = null;
            }
            else if (e.Command == CmdClose)
            {
                OnLostFocus(_CurrentControl, null);
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                // _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Last));
            }
        }
        #endregion
        #region Main Functionality
        private static void AddKeyBoardINput(char input)
        {
            if (CapsLockFlag)
            {
                if (ShiftFlag)
                {
                    KeyBoard.TouchScreenText += char.ToLower(input).ToString();
                    ShiftFlag = false;

                }
                else
                {
                    KeyBoard.TouchScreenText += char.ToUpper(input).ToString();
                }
            }
            else
            {
                if (!ShiftFlag)
                {
                    KeyBoard.TouchScreenText += char.ToLower(input).ToString();
                }
                else
                {
                    KeyBoard.TouchScreenText += char.ToUpper(input).ToString();
                    ShiftFlag = false;
                }
            }
        }


        private static void syncchild()
        {
            if (_CurrentControl != null && _InstanceObject != null)
            {
                double h = _CurrentControl.ActualHeight;
                Point virtualpoint = new Point(0, h / 5);
                Point Actualpoint = _CurrentControl.PointToScreen(virtualpoint);
                if (WidthTouchKeyboard + Actualpoint.X > SystemParameters.VirtualScreenWidth)
                {
                    double difference = WidthTouchKeyboard + Actualpoint.X - SystemParameters.VirtualScreenWidth;
                    _InstanceObject.Left = Actualpoint.X - difference;
                }
                else if (!(Actualpoint.X > 1))
                {
                    _InstanceObject.Left = 1;
                }
                else
                {
                    _InstanceObject.Left = Actualpoint.X;
                }

                if (HeightTouchKeyboard + Actualpoint.Y > SystemParameters.VirtualScreenHeight)
                {
                    _InstanceObject.Top = _CurrentControl.PointToScreen(new Point(0, 0)).Y - HeightTouchKeyboard - 3;
                }
                else
                {
                    _InstanceObject.Top = Actualpoint.Y;
                }
                
                //_InstanceObject.Show();
            }


        }

        public static bool GetKeyBoard(DependencyObject obj)
        {
            return (bool)obj.GetValue(KeyBoardProperty);
        }

        public static void SetKeyBoard(DependencyObject obj, bool value)
        {
            obj.SetValue(KeyBoardProperty, value);
        }
        /// <summary>
        /// 全键盘
        /// </summary>
        public static readonly DependencyProperty KeyBoardProperty =
            DependencyProperty.RegisterAttached("KeyBoard", typeof(bool), typeof(KeyBoard), new UIPropertyMetadata(default(bool), KeyBoardPropertyChanged));

        static void KeyBoardPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            KeyMode.Add(host, true);
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
            }

        }
        public static bool GetKeyPadControl(DependencyObject obj)
        {
            return (bool)obj.GetValue(KeyBoardProperty);
        }

        public static void SetKeyPadControl(DependencyObject obj, bool value)
        {
            obj.SetValue(KeyBoardProperty, value);
        }
        /// <summary>
        /// 小键盘
        /// </summary>
        public static readonly DependencyProperty KeyPadControlProperty =
            DependencyProperty.RegisterAttached("KeyPadControl", typeof(bool), typeof(KeyBoard), new UIPropertyMetadata(default(bool), KeyPadControlPropertyChanged));

        static void KeyPadControlPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            KeyMode.Add(host, false);
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
            }

        }





        static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control host = sender as Control;

            //_PreviousTextBoxBackgroundBrush = host.Background;
            _PreviousTextBoxBorderBrush = host.BorderBrush;
            _PreviousTextBoxBorderThickness = host.BorderThickness;

            //host.Background = Brushes.Cyan;
            host.BorderBrush = Brushes.Blue;
            host.BorderThickness = new Thickness(2);


            _CurrentControl = host;
            //FrameworkElement _parent = _CurrentControl.Parent as FrameworkElement;
            //while (_parent != null)
            //{
            //    _parent = _parent.Parent as FrameworkElement;
            //    if (_parent.Parent == null) break;
            //}
            //Window win = _parent as Window;
            //win.MouseUp += Win_MouseUp;

            if (_InstanceObject == null)
            {
                FrameworkElement ct = host;
                while (ct != null)
                {
                    if (ct is Window)
                    {
                        ((Window)ct).LocationChanged += new EventHandler(KeyBoard_LocationChanged);
                        ((Window)ct).Activated += new EventHandler(KeyBoard_Activated);
                        ((Window)ct).Deactivated += new EventHandler(KeyBoard_Deactivated);
                        break;
                    }
                    ct = (FrameworkElement)ct.Parent;
                }

                if (ct == null)
                {
                    host.GotFocus += new RoutedEventHandler(KeyBoard_Activated);
                    host.LostFocus += new RoutedEventHandler(KeyBoard_Deactivated);
                }

                //_InstanceObject = new KeyBoard();
                _InstanceObject.AllowsTransparency = true;
                _InstanceObject.WindowStyle = WindowStyle.None;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.Topmost = true;

                host.LayoutUpdated += new EventHandler(tb_LayoutUpdated);
            }



        }


        static void KeyBoard_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }
        static void KeyBoard_Deactivated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        static void KeyBoard_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }

        static void KeyBoard_Activated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }


        static void KeyBoard_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }

        static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            syncchild();
        }



        static void OnLostFocus(object sender, RoutedEventArgs e)
        {

            Control host = sender as Control;
            //host.Background = _PreviousTextBoxBackgroundBrush;
            host.BorderBrush = _PreviousTextBoxBorderBrush;
            host.BorderThickness = _PreviousTextBoxBorderThickness;

            if (_InstanceObject != null)
            {
                _InstanceObject.Close();
                _InstanceObject = null;
            }



        }

        #endregion

        /// <summary>
        /// 用于设置界面样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window win = sender as Window;
            //使用全键盘模式
            if (KeyMode[_CurrentControl])
            {
                Grid g = win.FindName("main_grid") as Grid;
                ColumnDefinitionCollection columns = g.ColumnDefinitions;
                columns[1].Width = new GridLength(0);
                columns[0].Width = GridLength.Auto;
            }
            else
            {
                //小键盘模式
                win.Width = 300;
                Grid g = win.FindName("main_grid") as Grid;
                ColumnDefinitionCollection columns = g.ColumnDefinitions;
                columns[0].Width = new GridLength(0);

            }
            Border border = win.FindName("border_Win") as Border;
            Grid grid = win.FindName("btn_grid") as Grid;
            //设置背景和圆角
            if (BoardBackground.ContainsKey(_CurrentControl))
            {
                border.Background = BoardBackground[_CurrentControl];
                grid.Background = BoardBackground[_CurrentControl];
            }
            if (BoardCorner.ContainsKey(_CurrentControl))
                border.CornerRadius = BoardCorner[_CurrentControl];
            //获取样式
            Style shadow = win.Resources["ShadowStyle"] as Style;
            Style buttonStyle = win.Resources["InformButton"] as Style;
            Style borderstyle = win.Resources["ButtonBorderStyle"] as Style;
            #region 设置按钮样式

            #region 设置按钮边框

            Style newBorder = new Style();
            for (int i = borderstyle.Setters.Count - 1; i > 0; i--)
            {
                Setter set = borderstyle.Setters[i] as Setter;
                Setter newsetter = new Setter();
                newsetter.Property = set.Property;
                newsetter.Value = set.Value;
                newsetter.TargetName = set.TargetName;
                if (newsetter.Property.Name == "CornerRadius" && ButtonCorner.ContainsKey(_CurrentControl)) newsetter.Value = ButtonCorner[_CurrentControl];
                borderstyle.Setters.RemoveAt(i);
                borderstyle.Setters.Add(newsetter);
            }

            #endregion
            //设置样式
            foreach (Setter set in shadow.Setters)
            {
                if (set.Property.Name == "Control.Foreground" && ShadowForeground.ContainsKey(_CurrentControl)) set.Value = ShadowForeground[_CurrentControl];
            }
            foreach (Setter set in buttonStyle.Setters)
            {
                if (set.Property.Name == "Foreground" && ButtonForeground.ContainsKey(_CurrentControl)) set.Value = ButtonForeground[_CurrentControl];
                if (set.Property.Name == "Background" && ButtonBackground.ContainsKey(_CurrentControl)) set.Value = ButtonBackground[_CurrentControl];
                if (set.Property.Name == "Template")
                {
                    ControlTemplate triggers = (ControlTemplate)set.Value;
                    foreach (Trigger trigger in triggers.Triggers)
                    {
                        if (trigger.Property.Name == "IsMouseOver")
                        {
                            foreach (Setter setter in trigger.Setters)
                            {
                                //if (setter.Property.Name == "BorderBrush" && MouseOverForeground[_CurrentControl] != null) setter.Value = ButtonProperty.ButtonBorderBrush;
                                if (setter.Property.Name == "Foreground" && MouseOverForeground.ContainsKey(_CurrentControl)) setter.Value = MouseOverForeground[_CurrentControl];
                                if (setter.Property.Name == "Background" && MouseOverBackground.ContainsKey(_CurrentControl)) setter.Value = MouseOverBackground[_CurrentControl];
                            }
                        }
                        if (trigger.Property.Name == "IsPressed")
                        {
                            foreach (Setter setter in trigger.Setters)
                            {
                                if (setter.Property.Name == "Background" && PressedBackground.ContainsKey(_CurrentControl)) setter.Value = PressedBackground[_CurrentControl];
                            }
                        }
                    }
                }
            }
            //获取按钮
            StackPanel stackPanel = win.FindName("btn_collect_num") as StackPanel;
            StackPanel stackPanel_q = win.FindName("btn_collect_q") as StackPanel;
            StackPanel stackPanel_a = win.FindName("btn_collect_a") as StackPanel;
            StackPanel stackPanel_z = win.FindName("btn_collect_z") as StackPanel;
            StackPanel stackPanel_func = win.FindName("btn_collect_func") as StackPanel;
            //设置按钮样式
            foreach (var control in stackPanel.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;

                }
            }
            foreach (var control in stackPanel_q.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;
                }
            }
            foreach (var control in stackPanel_a.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;
                }
            }
            foreach (var control in stackPanel_z.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;
                }
            }
            foreach (var control in stackPanel_func.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;
                }
            }
            foreach (var control in grid.Children)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = control as Button;
                    b.Style = buttonStyle;
                }
            }
            #endregion
        }

        private static void Win_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window win = sender as Window;
            Point p = e.GetPosition(win);
            if (win.CaptureMouse())
            {
                //鼠标不在键盘范围内
                if (!_InstanceObject.CaptureMouse())
                {
                    //不在控件内 
                    OnLostFocus(_CurrentControl, null);
                }
            }
        }
    }

}
