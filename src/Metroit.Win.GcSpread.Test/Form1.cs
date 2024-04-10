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
            // Ctrl+F �Ō����_�C�A���O��\������
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
                        // ���ɕ\�����Ă�����A�N�e�B�u�ɂ���
                        metFpSpread1.SearchDialog.Activate();
                    }
                },
                (cell) => true
            ));
        }

        private void MetFpSpread1_SearchDialogClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Execute SearchDialogClosing");

            // �_�C�A���O�����̂����ۂ���
            //e.Cancel = true;
        }
    }
}
