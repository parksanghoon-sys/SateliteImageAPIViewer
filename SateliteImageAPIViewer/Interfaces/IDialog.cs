using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.enums;

namespace SateliteImageAPIViewer.Interfaces
{
    public interface IDialog
    {
        public string? Title { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        object? DataContext { get; set; }

        bool Activate();

        void Show();

        bool? ShowDialog();

        void Close();

        Action? CloseCallback { get; set; }
    }
    public interface IContext
    {
    }
    public interface IDialogContext // Window 가 사용할 ViewModel
    {
        IContext Context { get; set; }
    }
    public interface IDialogService
    {
        void Register(EDialogHostType dialogHostType, Type dialogWindowHostType);

        bool CheckActivate(string title);

        /// <summary>
        /// 팝업 컨텐츠 설정
        /// </summary>
        /// <param name="vm">컨텐츠 뷰모델</param>
        /// <param name="title">팝업창 타이틀</param>
        /// <param name="dialogHostType">컨텐츠가 표시될 팝업 다이얼로그 호스트 타입</param>
        void SetVM(ViewModelBase vm, string? title, double width, double height, EDialogHostType dialogHostType, bool isModal = true);

        /// <summary>
        /// 팝업 다이얼로그 정리
        /// </summary>
        void Clear();
    }

}
