using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalMaterialBoard : UserControl
    {
        public List<NormalMagneticCard> SelectedCards = new List<NormalMagneticCard>();
        public enum WorkingModes
        {
            BoardTable,
            SingleSelectMode,
            MulitSelectMode,
        }

        private WorkingModes workingMode = WorkingModes.BoardTable;
        
        /// <summary>
        /// 
        /// </summary>
        [Category("行为")]
        [Description("设置工作模式")]
        [DefaultValue(typeof(WorkingModes), "BoardTable")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public WorkingModes WorkingMode
        {
            get
            {
                return workingMode;
            }
            set
            {
                workingMode = value;
                ChangeWorkingMode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("面板标题")]
        [DefaultValue(typeof(String), "Title")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get
            {
                return labTitle.Text;
            }
            set
            {
                labTitle.Text = value;
            }
        }



        public List<NormalMagneticCard> listCard = new List<NormalMagneticCard>();

        public int DisplayCardRowsCount = 3;

        public NormalMaterialBoard()
        {
            InitializeComponent();
        }

        private void normalLayoutGrid1_Load(object sender, EventArgs e)
        {

        }

        private void normalMagneticCard1_Button1Click(object sender, EventArgs e)
        {

        }

        public NormalMagneticCard AddCard(string Title, string SubTitle, string Message, string Button1Text, string Button2Text)
        {
            NormalMagneticCard card = new NormalMagneticCard();
            card.Title = Title;
            card.SubTitle = SubTitle;
            card.Message = Message;
            card.ButtonText1 = Button1Text;
            card.ButtonText2 = Button2Text;

            nLGridMain.AddControls(card, new Rectangle(
                GetCurrentPositon().X,
                GetCurrentPositon().Y,
                10,
                nLGridMain.GridSize.Height - 1 - 1
                ));
            card.Click += Card_Click;
            listCard.Add(card);

            return card;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if(WorkingMode != WorkingModes.BoardTable)
            {
                if(SelectedCards.Contains(sender as NormalMagneticCard))
                {
                    SelectedCards.Remove(sender as NormalMagneticCard);
                    (sender as NormalMagneticCard).DisplaySelected(false);
                    (sender as NormalMagneticCard).Invalidate();
                }
                else
                {
                    if (WorkingMode == WorkingModes.SingleSelectMode)
                    {
                        foreach(NormalMagneticCard card in SelectedCards)
                        {
                            card.DisplaySelected(false);
                        }
                        SelectedCards.Clear();
                    }
                    SelectedCards.Add(sender as NormalMagneticCard);
                }
            }
        }

        public NormalMagneticCard AddCard(NormalMagneticCard card)
        {
            nLGridMain.AddControls(card, new Rectangle(
                GetCurrentPositon().X,
                GetCurrentPositon().Y,
                10,
                nLGridMain.GridSize.Height - 1 - 1
                ));
            card.Click += Card_Click;
            listCard.Add(card);

            return card;
        }
        public void RemoveCard(string Title,bool CleanAll = false)
        {
            try
            {
                if (CleanAll)
                {
                    nLGridMain.Controls.Clear();
                    nLGridMain.Refresh();
                    listCard.Clear();
                }
                else
                {
                    foreach (Control ctl in nLGridMain.Controls)
                    {
                        if (ctl.GetType().Name == "NormalMagneticCard" && (ctl as NormalMagneticCard).Title == Title)
                        {
                            nLGridMain.Controls.Remove(ctl);
                            listCard.Remove(ctl as NormalMagneticCard);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ChangeWorkingMode()
        {

        }

        public List<NormalMagneticCard> GetSelectedCards()
        {
            return SelectedCards;
        }

        private Point GetCurrentPositon()
        {
            try
            {
                int PositionX = (listCard.Count % DisplayCardRowsCount) * (1 + 10) + 1;

                int PositionY = (listCard.Count / DisplayCardRowsCount) * (nLGridMain.GridSize.Height) + 1;

                return new Point(PositionX, PositionY);
            }
            catch
            {
                return new Point(0, 0);
            }
            
        }
    }
}
