using FarPoint.Win.Spread.CellType;
using GrapeCity.Win.Spread.InputMan.CellType;
using Metroit.Win.GcSpread.Extensions;

namespace Metroit.Win.GcSpread.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            metFpSpread1.KeyMapActionInitializing += MetFpSpread1_KeyMapActionInitializing;
            metFpSpread1.SearchDialogClosing += MetFpSpread1_SearchDialogClosing; ;
        }

        private void MetFpSpread1_KeyMapActionInitializing(object sender, KeyMapActionInitializingEventArgs e)
        {
            // Ctrl+F で検索ダイアログを表示する
            e.Manager.KeyMapActions.Add(new KeyMapAction(
                new[] { (Keys.Control | Keys.F) },
                (cell) =>
                {
                    if (metFpSpread1.SearchDialog == null)
                    {
                        metFpSpread1.SearchWithDialog("");
                    }
                    else
                    {
                        // 既に表示していたらアクティブにする
                        metFpSpread1.SearchDialog.Activate();
                    }
                },
                (cell) => true
            ));
        }

        private void MetFpSpread1_SearchDialogClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Execute SearchDialogClosing");

            // ダイアログを閉じるのを拒否する
            //e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(metFpSpread1.ActiveSheet.Cells[2, 7].GetCellType()?.ToString() ?? "null");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            metFpSpread1.ActiveSheet.Cells[6, 7].CellType = metFpSpread1.ActiveSheet.Cells[5, 7].CopyCellType();
        }
    }
}
